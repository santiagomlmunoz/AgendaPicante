using Grupo1.AgendaDeTurnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Extensions
{
    public class GetDia
    {
        public static DiasEnum ObtenerDiaPorDayOfWeek(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return DiasEnum.Lunes;
                case DayOfWeek.Tuesday: return DiasEnum.Martes;
                case DayOfWeek.Wednesday: return DiasEnum.Miercoles;
                case DayOfWeek.Thursday: return DiasEnum.Jueves;
                case DayOfWeek.Friday: return DiasEnum.Viernes;
                case DayOfWeek.Saturday: return DiasEnum.Sabado;
                default: return DiasEnum.Domingo;

            }
        }

    }
}
