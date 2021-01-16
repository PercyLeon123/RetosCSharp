using RegistroPrueba.Shared.Interface;


namespace RegistroPrueba.Shared
{
    public class Persona : IPersona
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }
}
