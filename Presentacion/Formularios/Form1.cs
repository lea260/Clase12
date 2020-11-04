using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.Objetos;

///llamada a presentacion 


using Presentacion.ViewModels;


namespace Presentacion.Formularios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.TextBox1.Size = new System.Drawing.Size(173, 100);
            


        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            UsuarioView usuarioView= new UsuarioView();
            List<DataUsuario> lista = usuarioView.listaUsuarios();
            dgv.DataSource = lista;
            /*foreach(DataUsuario usr in lista)
            {
                int n = dgv.Rows.Add(); //retorna el indice 
                dgv.Rows[n].Cells[0].Value = (string) usr.Nombre;
                dgv.Rows[n].Cells[1].Value = (string) usr.Apellido;                

            }*/

        }
        OpenFileDialog ofd = new OpenFileDialog();
        private void btnFile_Click(object sender, EventArgs e)
        {
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtName.Text = ofd.FileName;
                txtFullName.Text = ofd.SafeFileName;
                var lines = File.ReadAllLines(ofd.FileName);
                foreach (string line in lines)
                {
                    var values = line.Split(';');
                    string uno = values[0];
                    string dos = values[1];
                    string tres = values[0];
                }
            }
        }
    }
}
