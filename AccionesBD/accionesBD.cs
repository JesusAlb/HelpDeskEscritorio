using HelpDeskEscritorio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskEscritorio.AccionesBD
{
    class accionesBD
    {

        public static bool validarUsuario(string usuario, string password)
        {
            try
            {
                var usuarioEncontrado = dbhelp.modelo.ViewUsuarios.SingleOrDefault(a => a.username.Equals(usuario) && a.password.Equals(password));
                if (usuarioEncontrado != null)
                {
                    dbhelp.usuario = usuarioEncontrado;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }

        public static int? numero_de_incidentes_abiertos(){
            try{
                return dbhelp.modelo.VistaIncidentesSinCerrars.Where(a => a.status == 0).Count();
            }
            catch{
                return null;
            }
        }

        public static int? numero_de_eventos_abiertos()
        {
            try
            {
                return dbhelp.modelo.VistaEventosSinCerrars.Where(a => a.status == 0).Count();
            }
            catch
            {
                return null;
            }
        }

    }
}
