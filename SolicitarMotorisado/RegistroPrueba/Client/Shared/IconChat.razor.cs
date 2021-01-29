using Microsoft.AspNetCore.Components;
using RegistroPrueba.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrueba.Client.Shared
{
    public partial class IconChat
    {
        [Parameter] public UserMessages MessagesUser { get; set; }
        [Parameter] public EventCallback<UserMessages> MoverMessagesUser { get; set; }


        protected override void OnInitialized()
        {
            Console.WriteLine(MessagesUser.Nombre);
            base.OnInitialized();
        }

        protected void Maximizar()
        {
            MoverMessagesUser.InvokeAsync(MessagesUser);
        }

    }
}
