using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.Servicios;
using Negocio.Objetos;
using System.Security.Cryptography;
using Presentacion.Helpers;
using Negocio.Modelo;




//de pueba

namespace Presentacion.Formularios
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            //llamo a conexion.             
            string consulta = txtConsulta.Text;
            if (consulta.Trim()!= string.Empty)
            {
                consulta = txtConsulta.Text;
            } else
            {
                consulta = null;
            }
            ProductosServicio servicio = new ProductosServicio();
            List<DataProducto> list = servicio.ObtenerProductos(consulta);
            dgvProductos.DataSource = list;            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //abrir formulario  
            int indice = -1;
            try
            {
                indice = dgvProductos.CurrentRow.Index;
            }catch 
            {
                MessageBox.Show("seleccione un Producto a editar");
            }

            
            //hay un indice seleccionado
            
            if (indice >-1)
            {
                DataProducto prod = new DataProducto();
                DataGridViewRow fila = dgvProductos.CurrentRow;
                //prod.Id_productos = (long) fila.Cells[0].Value;
                prod.Id_productos = (long)fila.Cells[0].Value;
                prod.Codigo = (string)fila.Cells[1].Value;
                prod.Descripcion = (string)fila.Cells[2].Value;
                prod.Precio = (float)fila.Cells[3].Value;
                prod.Fecha = (DateTime)fila.Cells[4].Value;                
                Form form = new AgregarProducto(prod, Modo.Actualizar);
                form.Show();
            }
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form form = new AgregarProducto(Modo.Agregar);
            form.Show();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            List<DataProducto> list = new List<DataProducto>();
            DataProducto producto01 = new DataProducto();
            producto01.Codigo = "codigo001";
            producto01.Descripcion = "desc001";
            producto01.Precio = 12;
            producto01.Fecha = new DateTime(2019, 12, 10);
            DataProducto producto02 = new DataProducto();
            producto02.Codigo = "codigo002";
            producto02.Descripcion = "desc002";
            producto02.Precio = 12;
            producto02.Fecha = new DateTime(2019, 12, 10);
            DataProducto producto03 = new DataProducto();
            producto03.Codigo = "codigo003";
            producto03.Descripcion = "desc002";
            producto03.Precio = 12;
            producto03.Fecha = new DateTime(2019, 12, 10);
            list.Add(producto01);
            list.Add(producto02);
            list.Add(producto03);
            Producto modelo = new Producto();
            modelo.AgregarCscProductos(list);

        }

        /*private void btnAgregar_Click(object sender, EventArgs e)
        {
            //abrir formulario
            DataProducto prod = new DataProducto();
            DataGridViewRow fila = dgvProductos.CurrentRow;            
            //prod.Id_productos = (long) fila.Cells[0].Value;
            prod.Id_productos = (long) fila.Cells[0].Value;
            prod.Codigo = (string) fila.Cells[1].Value;
            prod.Descripcion = (string) fila.Cells[2].Value;
            prod.Precio = (float) fila.Cells[3].Value;
            prod.Fecha = (DateTime) fila.Cells[4].Value;
            Form form = new AgregarProducto(prod);
            form.Show();
        }*/
    }
}
