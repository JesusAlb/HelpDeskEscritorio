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
                var usuarioEncontrado = dbhelp.modelo.vt_usuarios.SingleOrDefault(a => a.nombre_usuario.Equals(usuario) && a.password.Equals(password));
                if (usuarioEncontrado != null)
                {
                    dbhelp.usuario = usuarioEncontrado;
                    dbhelp.ip_servidor = dbhelp.modelo.vt_equipos.FirstOrDefault(a => a.nomTipoEquipo.Equals("Servidor IIS")).ip;
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
                return dbhelp.modelo.vt_incidente_sin_cerrar.Where(a => a.estatus_incidente == 0).Count();
            }
            catch{
                return null;
            }
        }

        public static int? numero_de_eventos_abiertos()
        {
            try
            {
                return dbhelp.modelo.vt_evento_sin_cerrar.Where(a => a.estatus_evento == 0).Count();
            }
            catch
            {
                return null;
            }
        }

    }
}
