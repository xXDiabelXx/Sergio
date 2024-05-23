using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploPrueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string nombre = txtNombre.Text;
            DateTime fecha = dateTimePicker1.Value.Date;

            string fechaformato = (fecha.Month + "-" + fecha.Day + "-" + fecha.Year);


            Conexion c = new Conexion();

            c.conectar();
            string query = "INSERT INTO dbo.alumnos (id , nombre , fecha) VALUES ("+ id +" , '"+ nombre +"' , '"+ fechaformato + "')";
            //MessageBox.Show(query);
            try
            {
                SqlConnection conexion = new SqlConnection("server = IQQ042MDALU0207; database = Registro; integrated security = true ");
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                int resultado = comando.ExecuteNonQuery();
                if (resultado == 0)
                {
                    MessageBox.Show("Registro no ingresado");
                }
                else
                {
                    MessageBox.Show("Registro agregado exitosamente");
                }
                conexion.Close();
                txtId.Text = "";
                txtNombre.Text = "";
                txtRol.Text = "";

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            string query = "DELETE FROM dbo.alumnos WHERE id = " + id;
            if (id.Length > 0)
            {

                try
                {
                    SqlConnection conexion = new SqlConnection("server = IQQ042MDALU0207; database = Registro ; integrated security = true ");
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);
                    int resultado = comando.ExecuteNonQuery();
                    if (resultado == 0)
                    {
                        MessageBox.Show("Registro no existe");
                    }else
                    {
                        MessageBox.Show("Registro eliminado exitosamente");
                    }
                    
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text; //id actualizar
            string nombre = txtNombre.Text;
            DateTime fecha = dateTimePicker1.Value.Date;
            string fechaformato = (fecha.Month + "-" + fecha.Day + "-" + fecha.Year);

            string query = "UPDATE dbo.alumnos SET nombre= '"+ nombre + "' , fecha = '" + fechaformato + "' WHERE id = "+ id;
            MessageBox.Show(query);
            try
            {
                SqlConnection conexion = new SqlConnection("server = IQQ042MDALU0207; database = Registro ; integrated security = true ");
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                int resultado = comando.ExecuteNonQuery();
                if (resultado == 0)
                {
                    MessageBox.Show("Registro no ha sido  actualizado");
                }
                else
                {
                    MessageBox.Show("Registro ha sido actualizado exitosamente");
                }
                conexion.Close();
                txtId.Text = "";
                txtNombre.Text = "";
                txtRol.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }
    }
}
