using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using RegistroPrueba.Client.Shared;
using RegistroPrueba.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrueba.Client.Pages
{
    public partial class Index
    {
        [Inject] protected NavigationManager NavigationManager { get; set; }

        protected HubConnection HubConection; /* Guardara la conexión que se utiliza para invocar métodos en un servidor SignalR. */
        protected Modal CModalLogin; /* Componente Modal instanciado */
        protected Modal CModalListUsers;

        protected List<Cliente> ListaCliente = new();
        protected List<Horario> ListaHorario = new();
        protected List<UserMessages> ListaMensajeUsuarios = new();
        protected Cliente Cliente = new();

        protected override void OnInitialized()
        {
            /* HubConnectionBuilder es un constructor para configurar instancias de HubConnection  */
            HubConection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/serviceHub"))
                .Build();

            /* Metodo invocable por el servidor */
            HubConection.On<List<Cliente>>("ListarUsuario", (listaCliente) =>
            {
                ListaCliente = listaCliente;
                StateHasChanged();
            });

            HubConection.On<List<Horario>>("ListarHorario", (listaHorario) =>
            {
                 ListaHorario = listaHorario;
                 StateHasChanged();
            });

            HubConection.On<MessageUser>("MensajePrivado", (messageUser) =>
            {
                ListaMensajeUsuarios.FirstOrDefault(x => x.Id == messageUser.Id).Mesanjes.Add(messageUser.Mesanje);
            });
        }

        public bool IsConnected => HubConection.State == HubConnectionState.Connected;

        /* Consumir metodo del servidor */
        protected async Task SendLogin()
        {
            await HubConection.StartAsync(); /* Inicia una conexión con el servidor */
            await HubConection.SendAsync("SendLogin", Cliente); /*  Metodo del servidor */
        }

        protected async Task Login(bool? isAuthenticated)
        {
            await SendLogin();
            CModalLogin.EventoModal();
        }

        protected void ComenzarChat(UserMessages userMessage) 
        {
            ListaMensajeUsuarios.Add(userMessage);
            StateHasChanged();
        }

        protected async Task MensajePrivado(MessageUser messageUser) 
        {
            await HubConection.SendAsync("MensajePrivado", messageUser);
        }
    }
}
