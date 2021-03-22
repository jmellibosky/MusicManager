using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Musica.Database
{
    class AD_Bandas
    {
        public static DataTable CargarGrilla()
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT b.IdBanda as ID, b.Nombre, p.Nombre AS Pais FROM Bandas b INNER JOIN PaisesOrigen p ON (p.IdPaisOrigen = b.IdPaisOrigen)";

            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public static DataTable BuscarPais(int idPais)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT b.IdBanda as ID, b.Nombre, p.Nombre AS Pais FROM Bandas b INNER JOIN PaisesOrigen p ON (p.IdPaisOrigen = b.IdPaisOrigen) WHERE b.IdPaisOrigen =" + idPais;

            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public static DataTable BuscarNombre(string input)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT b.IdBanda as ID, b.Nombre, p.Nombre AS Pais FROM Bandas b INNER JOIN PaisesOrigen p ON (p.IdPaisOrigen = b.IdPaisOrigen) WHERE b.Nombre like '%" + input + "%'";

            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public static DataTable BuscarNombrePais(string nombre, int idPais)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT b.IdBanda as ID, b.Nombre, p.Nombre AS Pais FROM Bandas b INNER JOIN PaisesOrigen p ON (p.IdPaisOrigen = b.IdPaisOrigen) WHERE b.Nombre = @n AND p.IdPaisOrigen = @p";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Parameters.AddWithValue("@p", idPais);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public static void CargarCombo(ref ComboBox combo)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT Nombre, IdBanda FROM Bandas ORDER BY Nombre";

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
            combo.ValueMember = "IdBanda";
        }

        public static void NuevoRegistro(string nombre, int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "INSERT INTO Bandas (Nombre, IdPaisOrigen) VALUES (@n, @i)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Parameters.AddWithValue("@i", id);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void EliminarRegistro(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "DELETE FROM Bandas WHERE IdBanda = " + id.ToString();

            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void ModificarRegistro(int id, string nombre, int pais)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "UPDATE Bandas SET Nombre = @n, IdPaisOrigen = @ip WHERE IdBanda = @id";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ip", pais);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static int ObtenerId(string nombre)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT IdBanda FROM Bandas WHERE Nombre = @n";

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
