using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgenciaViajesKarinaHeras.Models
{
    public class Destino
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int DestinoID { get; set; }
        public int CodigoViaje { get; set; }
        public int ViajeroId { get; set; }
        public string Ciudad { get; set; }

        public string Pais { get; set; }
    
}
}