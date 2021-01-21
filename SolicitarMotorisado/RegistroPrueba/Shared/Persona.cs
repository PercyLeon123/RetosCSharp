using RegistroPrueba.Shared.Interface;
using System.ComponentModel.DataAnnotations;

namespace RegistroPrueba.Shared
{
    public class Persona : IPersona
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Llenar este campo es obligatorio")]
        public string Nombre { get; set; }
    }
}
