using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploPrueba
{
    internal class Conexion
    {
         public SqlConnection conexion = new SqlConnection("server = IQQ042MDALU0207; database = Registro; integrated security = true ");

        public  void conectar()
        {
            try
            {
                conexion.Open();
                MessageBox.Show("coneixon abierta");
                conexion.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }finally
            {
                conexion.Close();
            }
            
        }
    }
}
