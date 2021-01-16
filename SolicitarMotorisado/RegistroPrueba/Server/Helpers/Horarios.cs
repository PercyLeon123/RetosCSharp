using RegistroPrueba.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrueba.Server.Helpers
{
    public static class Horarios
    {
        public static List<Horario> ListaHorario { get; set; }

        static Horarios() 
        {
            ListaHorario = new List<Horario>
            {
                new Horario() { Id = 1, FechaHorarioInicio = new DateTime(2021, 1, 17, 7, 0, 0), FechaHorarioFin = new DateTime(2021, 1, 17, 7, 29, 59), Disponible = true },
                new Horario() { Id = 2, FechaHorarioInicio = new DateTime(2021, 1, 17, 7, 30, 0), FechaHorarioFin = new DateTime(2021, 1, 17, 7, 60, 59), Disponible = true },
                new Horario() { Id = 3, FechaHorarioInicio = new DateTime(2021, 1, 17, 8, 0, 0), FechaHorarioFin = new DateTime(2021, 1, 17, 8, 29, 59), Disponible = true },
                new Horario() { Id = 4, FechaHorarioInicio = new DateTime(2021, 1, 17, 8, 30, 0), FechaHorarioFin = new DateTime(2021, 1, 17, 8, 60, 59), Disponible = true },
                new Horario() { Id = 5, FechaHorarioInicio = new DateTime(2021, 1, 17, 9, 0, 0), FechaHorarioFin = new DateTime(2021, 1, 17, 9, 29, 59), Disponible = true },
                new Horario() { Id = 6, FechaHorarioInicio = new DateTime(2021, 1, 17, 9, 30, 0), FechaHorarioFin = new DateTime(2021, 1, 17, 9, 60, 59), Disponible = true },
            };
        }
    }
}
