﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Persistencia.Repositorios
{
    public class ConexionDB
    {    
        public void Eliminar(int a)
        {
            int a = 15;
        }
        public static MySqlConnection GetConexion()
        {

            string cadenaConexion = "Database=test; Data Source=localhost; Port=3310; User Id=usuario1; Password=usuario1";
            MySqlConnection conexion = null;
            try
            {
                conexion = new MySqlConnection(cadenaConexion);
                Console.WriteLine("something is ");
            }catch (MySqlException ex){
                string mensaje = ex.ToString();
                Console.WriteLine("something is "+ex.ToString());
            }
            finally
            {
                Console.WriteLine("\n");
            }
            return conexion;        
        } 
    }
}
