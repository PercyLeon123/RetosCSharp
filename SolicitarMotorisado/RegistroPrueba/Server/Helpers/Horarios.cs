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
            ListaHorario =  new List<Horario>()
                {
                    new Horario() { Id = 1, FechaHorarioInicio = DateTime.Parse("17/01/2021 7:0:0"), FechaHorarioFin = DateTime.Parse("17/01/2021 7:29:0"), Cliente = new(), Empleado = new() },
                    new Horario() { Id = 2, FechaHorarioInicio = DateTime.Parse("17/01/2021 7:30:0"), FechaHorarioFin = DateTime.Parse("17/01/2021 7:59:0"), Cliente = new(), Empleado = new() },
                    new Horario() { Id = 3, FechaHorarioInicio = DateTime.Parse("17/01/2021 8:0:0"), FechaHorarioFin = DateTime.Parse("17/01/2021 8:29:0"), Cliente = new(), Empleado = new() },
                    new Horario() { Id = 4, FechaHorarioInicio = DateTime.Parse("17/01/2021 8:30:0"), FechaHorarioFin = DateTime.Parse("17/01/2021 8:59:0"), Cliente = new(), Empleado = new() },
                    new Horario() { Id = 5, FechaHorarioInicio = DateTime.Parse("17/01/2021 9:0:0"), FechaHorarioFin = DateTime.Parse("17/01/2021 9:29:0"), Cliente = new(), Empleado = new() },
                    new Horario() { Id = 6, FechaHorarioInicio = DateTime.Parse("17/01/2021 9:30:0"), FechaHorarioFin = DateTime.Parse("17/01/2021 9:59:0"), Cliente = new(), Empleado = new() }
                };
        }
    }
}
