using Microsoft.AspNetCore.Components;
using RegistroPrueba.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrueba.Client.Shared
{
    public partial class Chat
    {
        [Parameter] public UserMessages UserMessages { get; set; }
        [Parameter] public EventCallback<MessageUser> EnviarMensajePrivado { get; set; }
        MessageUser MessageUser = new();

        protected override void OnInitialized()
        {
            MessageUser.Id = UserMessages.Id;
            MessageUser.Nombre = UserMessages.Nombre;

            base.OnInitialized();
        }

        protected void EnviarMensaje() 
        {
            EnviarMensajePrivado.InvokeAsync(MessageUser);
        }
        

    }
}
