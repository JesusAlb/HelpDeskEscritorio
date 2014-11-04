using HelpDeskEscritorio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskEscritorio
{
    class dbhelp
    {
        public static ViewUsuario usuario { get; set; }
        public static dbhelpdeskEntities modelo = new dbhelpdeskEntities();
    }
}
