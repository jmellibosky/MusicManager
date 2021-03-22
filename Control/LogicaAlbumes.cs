using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Musica.Control
{
    class LogicaAlbumes
    {
        public static DataTable BuscarAlbumPorNombre(string nombre)
        {
            return Database.AD_Albumes.BuscarNombre(nombre);
        }

        public static DataTable BuscarAlbumPorBanda(string banda)
        {
            return Database.AD_Albumes.BuscarBanda(banda);
        }

        public static DataTable BuscarAlbumEnPeriodo(string inputd, string inputh)
        {
            int desde;
            int hasta;

            try
            {
                desde = int.Parse(inputd);
                hasta = int.Parse(inputh);

                return Database.AD_Albumes.BuscarEnPeriodo(desde, hasta);
            }
            catch (Exception)
            {
                try
                {
                    if (inputd.Equals(""))
                    {
                        hasta = int.Parse(inputh);
                        return Database.AD_Albumes.BuscarEnPeriodo(0, hasta);
                    }
                    else if (inputh.Equals(""))
                    {
                        desde = int.Parse(inputd);
                        return Database.AD_Albumes.BuscarEnPeriodo(desde, DateTime.Now.Year);
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception)
                {
                    return Database.AD_Albumes.CargarGrilla();
                }
            }

        }

        public static bool EliminarAlbum(int id)
        {
            try
            {
                Database.AD_Albumes.EliminarRegistro(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int CrearNuevoAlbum(string nombre, int año, int idBanda)
        {
            if (!ExisteAlbum(nombre, año, idBanda))
            {
                try
                {
                    Database.AD_Albumes.NuevoRegistro(nombre, año, idBanda);
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

        public static bool ExisteAlbum(string nombre, int año, int idBanda)
        {
            return Database.AD_Albumes.BuscarNombreAlbum(nombre, año, idBanda).Rows.Count != 0;
        }

        public static bool ModificarAlbum(int id, string nombre, int año, int banda)
        {
            try
            {
                Database.AD_Albumes.ModificarRegistro(id, nombre, año, banda);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int ObtenerIdBanda(string banda)
        {
            return Database.AD_Bandas.ObtenerId(banda);
        }
    }
}
