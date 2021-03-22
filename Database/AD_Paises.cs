using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Musica.Database
{
    class AD_Paises
    {
        public static void CargarCombo(ref ComboBox combo)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT * FROM PaisesOrigen ORDER BY Nombre";

            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            combo.Items.Clear();
            combo.DataSource = dt;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdPaisOrigen";
        }

        public static int ObtenerId(string nombre)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT IdPaisOrigen FROM PaisesOrigen WHERE Nombre = @n";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            return (int)cmd.ExecuteScalar();
        }
    }
}
