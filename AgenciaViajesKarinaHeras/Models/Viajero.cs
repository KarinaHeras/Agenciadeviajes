using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AgenciaViajesKarinaHeras.Models
{
    public class Viajero
    {
        [Key]
        public int IdViajero { get; set; }
        public string Dni { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyy}")]
        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}

public enum Role
{
    Admin,
    Usuario,
}