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
    class AD_Albumes
    {
        public static DataTable CargarGrilla()
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT a.IdAlbum AS ID, a.Nombre, a.Año, b.Nombre AS Banda FROM Albumes a INNER JOIN Bandas b ON (a.IdBanda = b.IdBanda)";

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

        public static DataTable BuscarNombreAlbum(string nombre, int año, int idBanda)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT a.IdAlbum AS ID, a.Nombre, a.Año, b.Nombre AS Banda FROM Albumes a INNER JOIN Bandas b ON (a.IdBanda = b.IdBanda) WHERE a.Nombre = @n AND a.Año = @a AND a.IdBanda = @b";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@a", año);
            cmd.Parameters.AddWithValue("@b", idBanda);
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        internal static int ObtenerId(string album)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT IdAlbum FROM Albumes WHERE Nombre = @n";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@n", album);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            return (int)cmd.ExecuteScalar();
        }

        public static void CargarCombo(ref ComboBox combo, int idBanda)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT * FROM Albumes WHERE IdBanda = @i ORDER BY Año DESC";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@i", idBanda);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            combo.DataSource = null;
            combo.Items.Clear();
            combo.DataSource = dt;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdAlbum";
        }

        public static void NuevoRegistro(string nombre, int año, int banda)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "INSERT INTO Albumes (Año, IdBanda, Nombre) VALUES (@a, @ib, @n)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@a", año);
            cmd.Parameters.AddWithValue("@ib", banda);
            cmd.Parameters.AddWithValue("@n", nombre);
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

            string consulta = "DELETE FROM Albumes WHERE IdAlbum = " + id.ToString();

            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void ModificarRegistro(int id, string nombre, int año, int banda)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "UPDATE Albumes SET Año = @a, IdBanda = @ib, Nombre = @n WHERE IdAlbum = @id";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@a", año);
            cmd.Parameters.AddWithValue("@ib", banda);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static DataTable BuscarNombre(string input)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT a.IdAlbum AS ID, a.Nombre, a.Año, b.Nombre AS Banda FROM Albumes a INNER JOIN Bandas b ON (a.IdBanda = b.IdBanda) WHERE a.Nombre like '%" + input + "%'";

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

        public static DataTable BuscarBanda(string input)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT a.IdAlbum AS ID, a.Nombre, a.Año, b.Nombre AS Banda FROM Albumes a INNER JOIN Bandas b ON (a.IdBanda = b.IdBanda) WHERE b.Nombre like '%" + input + "%'";

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

        public static DataTable BuscarEnPeriodo(int desde, int hasta)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT a.IdAlbum AS ID, a.Nombre, a.Año, b.Nombre AS Banda FROM Albumes a INNER JOIN Bandas b ON (a.IdBanda = b.IdBanda) WHERE a.Año BETWEEN @d AND @h";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@d", desde);
            cmd.Parameters.AddWithValue("@h", hasta);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
