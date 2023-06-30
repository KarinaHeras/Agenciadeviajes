using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaViajesKarinaHeras.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        virtual public Agencia Agencia { get; set; }
        //virtual public Login Login { get; set; }
        //virtual public Register Register { get; set; }
    }
}   