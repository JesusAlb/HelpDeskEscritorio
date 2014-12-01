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
        public static vt_usuarios usuario { get; set; }
        public static string ip_servidor {get; set;}
        public static dbhelpdeskV2Entities modelo = new dbhelpdeskV2Entities();
    }
}
