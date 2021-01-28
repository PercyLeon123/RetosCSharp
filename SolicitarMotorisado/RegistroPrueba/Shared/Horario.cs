using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPrueba.Shared
{
    public class Horario
    {
        public int Id { get; set; }
        public DateTime FechaHorarioInicio { get; set; }
        public DateTime FechaHorarioFin { get; set; }
        public bool Disponible 
        {
            get 
            {
                return (Cliente.Id == null);
            } 
        }
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; } /* Experimental */
    }
}
