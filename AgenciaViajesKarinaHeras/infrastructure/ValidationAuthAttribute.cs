using AgenciaViajesKarinaHeras.DbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgenciaViajesKarinaHeras.infrastructure
{
    public class ValidateNamAttribute : ValidationAttribute
    {
        public ValidateNamAttribute()
        {
            ErrorMessage = "Solo Esta permitido el uso a mayores de edad";
        }
        public override bool IsValid(object value)
        {
            Context db = new Context();
            int aux = int.Parse(value.ToString());
            var viajero = db.Viajero.Where(v => v.IdViajero == aux).SingleOrDefault();
            int Datafecha = DateTime.Now.Year;
            int ViajeroAll = viajero.FechaNacimiento.Year; bool val = (Datafecha - ViajeroAll) > 18; return (Datafecha - ViajeroAll) > 18;
        }
    }
}