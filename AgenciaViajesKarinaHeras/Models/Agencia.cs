using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AgenciaViajesKarinaHeras.Models
{
    public class Agencia
    {
        public int AgenciaId { get; set; }
        public int CodigoViaje { get; set; }
        public decimal Precio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyy}")]
        [Display(Name = "Fecha Viaje")]
        [DataType(DataType.Date)]
        public DateTime FechaViaje { get; set; }
        [UIHint("Enum")]
        [Display(Name = "Rol")]
        public Role? Role { get; set; }

        public virtual Viajero Viajero { get; set; }
        public virtual Destino Destino { get; set; }
    }
}