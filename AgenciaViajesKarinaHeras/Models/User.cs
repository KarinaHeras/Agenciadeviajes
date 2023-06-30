using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaViajesKarinaHeras.Models
{
    public class User
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        public string[] Roles { get; set; }
    }
}