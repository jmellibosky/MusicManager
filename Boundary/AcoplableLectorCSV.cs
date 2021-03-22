using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Musica.Boundary
{
    public partial class AcoplableLectorCSV : Form
    {
        string[] lines;
        string minutos;
        string segundos;
        string nombre;
        string banda;
        string album;

        public AcoplableLectorCSV()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            leerArchivo();
        }

        private void leerArchivo()
        {
            lines = File.ReadAllLines(@"C:\Users\Nestor\Desktop\Música - Hoja1 (2).csv");

            string filetext = File.ReadAllText(@"C:\Users\Nestor\Desktop\Música - Hoja1 (2).csv");
            txtArchivo.Text = filetext.ToString();

            foreach (string line in lines)
            {
                char[] characters = line.ToCharArray();

                txtArchivo.Text += "\n" + line;

                minutos = "" + characters[2] + characters[3];
                segundos = "" + characters[5] + characters[6];
                nombre = "";
                banda = "";
                album = "";

                int b = 0;

                foreach (char c in characters)
                {
                    if (c == ',')
                    {
                        b++;
                        continue;
                    }

                    if (b == 1)
                    {
                        nombre += c;
                    }
                    else if (b == 2)
                    {
                        banda += c;
                    }
                    else if (b == 3)
                    {
                        album += c;
                    }
                }

                int idBanda = ObtenerBanda(banda);
                int idAlbum = ObtenerAlbum(album);
                
                string aux = txtArchivo.Text;
                txtArchivo.Text = "Cancion " + nombre + " encontrada! \n" + aux;
                txtArchivo.Update();

                grillaLecturas.Rows.Add(minutos, segundos, nombre, banda, idBanda, album, idAlbum);
                lblTotal.Text = grillaLecturas.Rows.Count.ToString();
            }
        }
        
        private int ObtenerBanda(string banda)
        {
            try
            {
                return Database.AD_Bandas.ObtenerId(banda);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int ObtenerAlbum(string album)
        {
            try
            {
                return Database.AD_Albumes.ObtenerId(album);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grillaLecturas.Rows.RemoveAt(grillaLecturas.SelectedRows[0].Index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grillaLecturas.Rows)
            {
                string nombre = row.Cells[2].Value.ToString();
                int minutos = int.Parse(row.Cells[0].Value.ToString());
                int segundos = int.Parse(row.Cells[1].Value.ToString());
                int idBanda = int.Parse(row.Cells[4].Value.ToString());
                int idAlbum = int.Parse(row.Cells[6].Value.ToString());
                int bpm = int.Parse(row.Cells[7].ToString());

                if (idBanda != -1 && idAlbum != -1)
                {
                    Control.LogicaCanciones.CrearNuevaCancion(nombre, minutos, segundos, idBanda, idAlbum, bpm);
                    string aux = txtArchivo.Text;
                    txtArchivo.Text = "Cancion " + nombre + " registrada! \n" + aux;
                }
            }
        }
    }
}
