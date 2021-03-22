using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Musica.Control
{
    class LogicaCanciones
    {
        public static DataTable BuscarCancionPorNombre(string input)
        {
            return Database.AD_Canciones.BuscarNombre(input);
        }

        public static DataTable BuscarCancionPorBanda(string input)
        {
            return Database.AD_Canciones.BuscarBanda(input);
        }

        public static DataTable BuscarCancionEnTiempo(int minutos, int segundos)
        {
            return Database.AD_Canciones.BuscarTiempo(minutos, segundos);
        }

        public static bool EliminarCancion(int id)
        {
            try
            {
                Database.AD_Canciones.EliminarRegistro(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static int CrearNuevaCancion(string nombre, int minutos, int segundos, int idBanda, int idAlbum, int bpm)
        {
            if (!ExisteCancion(nombre, idBanda))
            {
                try
                {
                    Database.AD_Canciones.NuevoRegistro(nombre, idBanda, idAlbum, minutos, segundos, bpm);
                    return 0;
                }
                catch (Exception)
                {
                    return 1;
                }
            }
            else
            {
                return -1;
            }
        }

        private static bool ExisteCancion(string nombre, int idBanda)
        {
            return Database.AD_Canciones.BuscarNombreBanda(nombre, idBanda).Rows.Count != 0;
        }

        public static int ObtenerIdBanda(string banda)
        {
            return Database.AD_Bandas.ObtenerId(banda);
        }

        internal static bool ModificarCancion(int idMod, string nombre, int minutos, int segundos, int idBanda, int idAlbum, int bpm)
        {
            try
            {
                Database.AD_Canciones.ModificarRegistro(idMod, nombre, minutos, segundos, idBanda, idAlbum, bpm);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int ObtenerIdAlbum(string album, int idbanda)
        {
            return Database.AD_Albumes.ObtenerId(album);
        }

        public static int ObtenerMinutos(int id)
        {
            return Database.AD_Canciones.ObtenerMinutos(id);
        }

        public static int ObtenerSegundos(int id)
        {
            return Database.AD_Canciones.ObtenerSegundos(id);
        }
    }
}
