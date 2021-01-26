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
        protected ListUsersMessages ListaMensajeUsuarios = new();
        protected Cliente Cliente = new();

        protected Cliente UserCliente = new();

        protected override void OnInitialized()
        {
            /* HubConnectionBuilder es un constructor para configurar instancias de HubConnection  */
            HubConection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/serviceHub"))
                .Build();

            /* Metodo invocable por el servidor */
            HubConection.On<string>("IniciarSesion", (id) =>
            {
                UserCliente.Id = id; /* Por ver */
            });

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
                messageUser.Emisor = false; /* Receptor */
                ListaMensajeUsuarios.ValidaUser(messageUser);
                ListaMensajeUsuarios.AddMessage(messageUser);
                StateHasChanged();
            });

            HubConection.On<Cliente>("AddUser", (cliente) => 
            {
                if (UserCliente.Id != cliente.Id)
                    ListaCliente.Add(cliente);
                else 
                    UserCliente = cliente;
                StateHasChanged();
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

        protected void ComenzarChat(MessageUser messageUser) 
        {
            ListaMensajeUsuarios.ValidaUser(messageUser);
            CModalListUsers.EventoModal();
            StateHasChanged();
        }

        protected async Task MensajePrivado(MessageUser messageUser) 
        {
            messageUser.Nombre = UserCliente.Nombre; /* Artificio, le asignamos Nombre de la session */
            messageUser.Emisor = true; /* Emisor */

            ListaMensajeUsuarios.AddMessage(messageUser);
            await HubConection.SendAsync("MensajePrivado", messageUser);
        }
    }
}
