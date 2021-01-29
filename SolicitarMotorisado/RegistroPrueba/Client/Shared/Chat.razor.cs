using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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
        [Parameter] public EventCallback<UserMessages> MinimizarMessagesUser { get; set; }
        [Parameter] public EventCallback<UserMessages> CloseMessagesUser { get; set; }


        MessageUser MessageUser = new();
        ElementReference InputMessage;

        protected override void OnInitialized()
        {
            MessageUser.Id = UserMessages.Id;
            
            base.OnInitialized();
        }

        protected void Minimizar()
        {
            MinimizarMessagesUser.InvokeAsync(UserMessages);
        }
        protected void Cerrar()
        {
            CloseMessagesUser.InvokeAsync(UserMessages);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender) 
        {
            if (firstRender) 
            {
                await InputMessage.FocusAsync();
            }
           
        }

        protected void EnviarMensaje() 
        {
            EnviarMensajePrivado.InvokeAsync(MessageUser);
            MessageUser.Mensaje = "";
        }

        protected void RedactarMensaje(KeyboardEventArgs e) 
        {
            if (e.Key == "Enter") 
            {
                EnviarMensaje();
            }
        
        }

    }
}
