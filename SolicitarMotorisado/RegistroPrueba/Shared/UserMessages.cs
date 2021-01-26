using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPrueba.Shared
{
    public class UserMessages : Persona
    {
        public List<Message> Mesanjes { get; set; }
        public bool Visto { get; set; }
        public bool Activo { get; set; }

    }
}
