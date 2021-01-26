using Microsoft.AspNetCore.Components;
using RegistroPrueba.Shared;

namespace RegistroPrueba.Client.Shared
{
    public partial class UserChatItem
    {
        [Parameter] public Cliente User { get; set; } = new();
        [Parameter] public EventCallback<MessageUser> EnviarMensaje { get; set; }

        protected MessageUser MessageUser = new();

        protected override void OnInitialized()
        {
            MessageUser.Id = User.Id;
            MessageUser.Nombre = User.Nombre;

            base.OnInitialized();
        }



        public void EnviarMensajeUsuario() 
        {
            //UserMessages.Mesanjes.Add();
            EnviarMensaje.InvokeAsync(MessageUser);
        }
    }
}
