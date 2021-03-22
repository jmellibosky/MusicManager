using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Musica.Database
{
    class AD_Canciones
    {
        public static DataTable CargarGrilla()
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT c.IdCancion AS ID, c.Nombre, (CAST(c.Minutos AS varchar) + ':' + CAST(c.Segundos AS varchar)) AS Duracion, b.Nombre AS Banda, a.Nombre AS Album, c.BPM FROM Canciones c INNER JOIN Bandas b ON (c.IdBanda = b.IdBanda) INNER JOIN Albumes a ON (c.IdAlbum = a.IdAlbum) ORDER BY c.Nombre";

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

        internal static DataTable BuscarTiempo(int minutos, int segundos)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT c.IdCancion AS ID, c.Nombre, (CAST(c.Minutos AS varchar) + ':' + CAST(c.Segundos AS varchar)) AS Duracion, b.Nombre AS Banda, a.Nombre AS Album, c.BPM FROM Canciones c INNER JOIN Bandas b ON (c.IdBanda = b.IdBanda) INNER JOIN Albumes a ON (c.IdAlbum = a.IdAlbum) WHERE c.Minutos = @m AND c.Segundos = @s";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@m", minutos);
            cmd.Parameters.AddWithValue("@s", segundos);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        internal static DataTable BuscarNombreBanda(string nombre, int idBanda)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT c.IdCancion AS ID, c.Nombre, (CAST(c.Minutos AS varchar) + ':' + CAST(c.Segundos AS varchar)) AS Duracion, b.Nombre AS Banda, a.Nombre AS Album, c.BPM FROM Canciones c INNER JOIN Bandas b ON (c.IdBanda = b.IdBanda) INNER JOIN Albumes a ON (c.IdAlbum = a.IdAlbum) WHERE c.Nombre = @n AND c.IdBanda = @b";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Parameters.AddWithValue("@b", idBanda);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        internal static DataTable BuscarBanda(string input)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT c.IdCancion AS ID, c.Nombre, (CAST(c.Minutos AS varchar) + ':' + CAST(c.Segundos AS varchar)) AS Duracion, b.Nombre AS Banda, a.Nombre AS Album, c.BPM FROM Canciones c INNER JOIN Bandas b ON (c.IdBanda = b.IdBanda) INNER JOIN Albumes a ON (c.IdAlbum = a.IdAlbum) WHERE b.Nombre LIKE '%" + input + "%'";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@m", input);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        internal static int ObtenerMinutos(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT Minutos FROM Canciones WHERE idCancion = @n";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@n", id);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            return (int)cmd.ExecuteScalar();
        }

        internal static int ObtenerSegundos(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT Segundos FROM Canciones WHERE idCancion = @n";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@n", id);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            return (int)cmd.ExecuteScalar();
        }

        internal static DataTable BuscarNombre(string input)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT c.IdCancion AS ID, c.Nombre, (CAST(c.Minutos AS varchar) + ':' + CAST(c.Segundos AS varchar)) AS Duracion, b.Nombre AS Banda, a.Nombre AS Album, c.BPM FROM Canciones c INNER JOIN Bandas b ON (c.IdBanda = b.IdBanda) INNER JOIN Albumes a ON (c.IdAlbum = a.IdAlbum) WHERE c.Nombre LIKE '%" + input + "%'";

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

        public static void CargarCombo(ref ComboBox combo)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "SELECT * FROM Canciones";

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
            combo.ValueMember = "IdCancion";
        }

        public static void NuevoRegistro(string nombre, int banda, int album, int minutos, int segundos, int bpm)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "INSERT INTO Canciones (Nombre, IdBanda, IdAlbum, Minutos, Segundos, BPM) VALUES (@n, @ib, @ia, @m, @s, @b)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ia", album);
            cmd.Parameters.AddWithValue("@ib", banda);
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Parameters.AddWithValue("@m", minutos);
            cmd.Parameters.AddWithValue("@s", segundos);
            cmd.Parameters.AddWithValue("@b", bpm);
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

            string consulta = "DELETE FROM Canciones WHERE IdCancion = " + id.ToString();

            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void ModificarRegistro(int id, string nombre, int minutos, int segundos, int banda, int album, int bpm)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CC"]);

            string consulta = "UPDATE Canciones SET IdAlbum = @ia, IdBanda = @ib, Nombre = @n, Minutos = @m, Segundos = @s, BPM = @b WHERE IdCancion = @id";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ia", album);
            cmd.Parameters.AddWithValue("@ib", banda);
            cmd.Parameters.AddWithValue("@m", minutos);
            cmd.Parameters.AddWithValue("@s", segundos);
            cmd.Parameters.AddWithValue("@b", bpm);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();

            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
