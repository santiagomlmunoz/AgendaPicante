using Grupo1.AgendaDeTurnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Extensions
{
    public class DateUtil
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
        public static string getMesPorNumero(int mes)
        {
            switch(mes){
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                case 7: return "Julio";
                case 8: return "Agosto";
                case 9: return "Septiembre";
                case 10: return "Octubre";
                case 11: return "Noviembre";
                default: return "Diciembre";
            }
        }
        public static string FechaToString(DateTime fecha)
        {
            string retorno;
            DiasEnum nombreDia = ObtenerDiaPorDayOfWeek(fecha.DayOfWeek);
            string mes = getMesPorNumero(fecha.Month);
            int dia = fecha.Day;

            retorno = nombreDia.ToString() + " " + dia + " de " + mes;
            return retorno;
        }

    }
}
