using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Musica.Control
{
    class LogicaBandas
    {
        public static DataTable BuscarBandaPorNombre(string nombre)
        {
            return Database.AD_Bandas.BuscarNombre(nombre);
        }

        public static DataTable BuscarBandaPorPais(int idPais)
        {
            return Database.AD_Bandas.BuscarPais(idPais);
        }

        public static int CrearNuevaBanda(string nombre, int idPais)
        {
            if (!ExisteBanda(nombre, idPais))
            {
                try
                {
                    Database.AD_Bandas.NuevoRegistro(nombre, idPais);
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

        public static bool ExisteBanda(string nombre, int idPais)
        {
            return Database.AD_Bandas.BuscarNombrePais(nombre, idPais).Rows.Count != 0;
        }

        public static int ObtenerIdPais(string nombrePais)
        {
            return Database.AD_Paises.ObtenerId(nombrePais);
        }

        public static bool ModificarBanda(int id, string nombre, int idPais)
        {
            try
            {
                Database.AD_Bandas.ModificarRegistro(id, nombre, idPais);
                return true;
            }
            catch (Exception)
            {
                return false;
            }           
        }

        public static bool EliminarBanda(int id)
        {
            try
            {
                Database.AD_Bandas.EliminarRegistro(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
