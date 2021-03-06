﻿using MySql.Data.MySqlClient;
using Persistencia.Contratos;
using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Persistencia.Repositorios
{
    public class ProductosRepo : IProducto
    {
        public List<ProductoEntidad> ListarProductos(string consulta = null)
        {
            List<ProductoEntidad> list = new List<ProductoEntidad>();
            MySqlConnection conexion = null;
            try
            {
                MySqlDataReader reader = null;
                conexion = ConexionDB.GetConexion();
                conexion.Open();
                string sql;
                if (consulta == null)
                {
                    sql = "SELECT id_productos, codigo,descripcion,precio,fecha FROM productos";
                }
                else
                {
                    sql = "SELECT id_productos, codigo,descripcion,precio,fecha FROM productos " +
                        "WHERE codigo LIKE @consulta OR descripcion LIKE @consulta";

                }

                string searchTerm = string.Format("%{0}%", consulta);


                //Command.Parameters.Add(new SqlParameter("@name", searchTerm));

                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@consulta", searchTerm);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string id = reader.GetString(0);
                        /*string codigo = (reader[1] != DBNull.Value) ? reader.GetString(1) : ""; ;
                        if (reader[1] != DBNull.Value)
                        {
                            string codigo = reader.GetString(1)
                        }
                        else
                        {
                            codigo = "";
                        }*/
                        string codigo = (reader[1] != DBNull.Value) ? reader.GetString(1) : ""; ;
                        string descripcion = (reader[2] != DBNull.Value) ? reader.GetString(2) : "";
                        string precio = (reader[3] != DBNull.Value) ? reader.GetString(3) : "0";
                        string fecha = (reader[4] != DBNull.Value) ? reader.GetString(4) : "1/1/2000 0:00:00";
                        ProductoEntidad prod = new ProductoEntidad
                        {
                            Id_productos = long.Parse(id),
                            Codigo = codigo,
                            Descripcion = descripcion,
                            Precio = float.Parse(precio)
                        };
                        DateTime fechaD = DateTime.ParseExact(fecha, "d/M/yyyy H:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        prod.Fecha = fechaD;
                        list.Add(prod);
                    }
                }

            }
            catch (MySqlException ex)
            {
                string mensaje = ex.ToString();
                Console.WriteLine("hola" + mensaje);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return list;
        }
        public void AgregarProducto(ProductoEntidad entidad)
        {
            MySqlConnection conexion = null;
            try
            {
                conexion = ConexionDB.GetConexion();
                conexion.Open();
                string sql = "insert into productos (codigo, descripcion,precio,fecha) values " +
                        "(@codigo, @descripcion, @precio, @fecha)";
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@codigo", entidad.Codigo);
                comando.Parameters.AddWithValue("@descripcion", entidad.Descripcion);
                comando.Parameters.AddWithValue("@precio", entidad.Precio);
                comando.Parameters.AddWithValue("@fecha", entidad.Fecha);
                comando.ExecuteNonQuery();
                //obtiene el ultimo id ingresado
                long id = comando.LastInsertedId;
            }
            catch (MySqlException ex)
            {
                string mensaje = ex.ToString();
                Console.WriteLine("hola" + mensaje);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
        
        public void EditarProducto(ProductoEntidad entidad)
        {
            MySqlConnection conexion = null;
            try
            {
                conexion = ConexionDB.GetConexion();
                conexion.Open();

                string sql = "UPDATE productos SET codigo=@codigo, descripcion=@descripcion, " +
                    "precio= @precio, fecha= @fecha WHERE id_productos= @id";
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@codigo", entidad.Codigo);
                comando.Parameters.AddWithValue("@descripcion", entidad.Descripcion);
                comando.Parameters.AddWithValue("@precio", entidad.Precio);
                comando.Parameters.AddWithValue("@fecha", entidad.Fecha);
                comando.Parameters.AddWithValue("@id", entidad.Id_productos);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                string mensaje = ex.ToString();
                Console.WriteLine("hola" + mensaje);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void CSVToMySQL(List<ProductoEntidad> list)
        {
            MySqlConnection conexion = null;            
            MySqlTransaction trans = null;            
            try
            {
                conexion = ConexionDB.GetConexion();
                conexion.Open();
                string sql = "insert into productos (codigo, descripcion,precio,fecha) values " +
                        "(@codigo, @descripcion, @precio, @fecha)";
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                trans = conexion.BeginTransaction();                
                foreach (var entidad in list)
                {
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@codigo", entidad.Codigo);
                    comando.Parameters.AddWithValue("@descripcion", entidad.Descripcion);
                    comando.Parameters.AddWithValue("@precio", entidad.Precio);
                    comando.Parameters.AddWithValue("@fecha", entidad.Fecha);
                    comando.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (MySqlException ex)
            {
                string mensaje = ex.ToString();
                Console.WriteLine("hola" + mensaje);
                trans.Rollback();
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                    conexion.Dispose();
                }
                if (trans != null)
                {
                    trans.Dispose();
                }
            }
        }//end CSVToMySQL

        /*
        string Command = "INSERT INTO User (FirstName, LastName ) VALUES (@FirstName, @LastName);";
        using (MySqlConnection mConnection = new MySqlConnection(ConnectionString))
        {
            mConnection.Open();
            using (MySqlTransaction trans = mConnection.BeginTransaction())
            {
                using (MySqlCommand myCmd = new MySqlCommand(Command, mConnection, trans))
                {


                    myCmd.CommandType = CommandType.Text;
                    for (int i = 0; i <= 99999; i++)
                    {
                        //inserting 100k items
                        myCmd.Parameters.Clear();
                        myCmd.Parameters.AddWithValue("@FirstName", "test");
                        myCmd.Parameters.AddWithValue("@LastName", "test");
                        myCmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
            }
        }
    }*/

        public void EliminarProducto(long idproductos)
        {
            MySqlConnection conexion = null;
            try
            {
                conexion = ConexionDB.GetConexion();
                conexion.Open();
                string sql = "delete from productos where id_productos=@id";
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", idproductos);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                string mensaje = ex.ToString();
                Console.WriteLine("hola" + mensaje);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
    }//end clase
}//end namespace
