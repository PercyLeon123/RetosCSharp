using Microsoft.AspNetCore.Components;
using RegistroPrueba.Shared;

namespace RegistroPrueba.Client.Shared
{
    public partial class UserChatItem
    {
        [Parameter] public Cliente User { get; set; } = new();
        [Parameter] public EventCallback<UserMessages> EnviarMensaje { get; set; }

        protected UserMessages UserMessages = new();

        protected override void OnInitialized()
        {
            UserMessages.Id = User.Id;
            UserMessages.Nombre = User.Nombre;

            base.OnInitialized();
        }



        public void EnviarMensajeUsuario() 
        {
            //UserMessages.Mesanjes.Add();
            EnviarMensaje.InvokeAsync(UserMessages);
        }
    }
}
