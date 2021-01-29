using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
using RegistroPrueba.Client.Shared;
using RegistroPrueba.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* https://docs.microsoft.com/en-us/aspnet/core/signalr/dotnet-client?view=aspnetcore-2.2&tabs=visual-studio */

namespace RegistroPrueba.Client.Pages
{
    public partial class Index
    {
        [Inject] protected NavigationManager NavigationManager { get; set; }

        protected HubConnection HubConection; /* Guardara la conexión que se utiliza para invocar métodos en un servidor SignalR. */
        protected Modal CModalLogin; /* Componente Modal instanciado */
        protected Modal CModalListUsers;

        protected List<Cliente> ListaCliente = new();
        protected List<Cliente> ListaClienteH = new();
        protected List<Horario> ListaHorario = new();
        protected ListUsersMessages ListaMensajeUsuarios = new();
        protected ListUsersMessages ListaMensajeUsuariosMin = new();
        protected Cliente Cliente = new();

        protected Cliente UserCliente = new();
        protected string UsuarioFind;

        protected override void OnInitialized()
        {
            /* HubConnectionBuilder es un constructor para configurar instancias de HubConnection  */
            HubConection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/serviceHub")) /* La URL que utilizará HttpConnection, Convierte un URI relativo en uno absoluto (resolviéndolo en relación con el URI absoluto actual).*/
                .Build(); /* Crea una nueva instancia de HubConnection */

            /* Metodo invocable por el servidor */
            HubConection.On<string>("IniciarSesion", (id) =>
            {
                UserCliente.Id = id; /* Por ver */
            });

            HubConection.On<List<Cliente>>("ListarUsuario", (listaCliente) =>
            {
                ListaCliente = listaCliente;
                ListaClienteH = listaCliente; /* Historico */
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
                if (ListaMensajeUsuarios.ListaMensajeUsuarios.Count() < 2)
                {
                    ListaMensajeUsuarios.ValidaUser(messageUser);
                    ListaMensajeUsuarios.AddMessage(messageUser);
                }
                else 
                {
                    ListaMensajeUsuariosMin.ValidaUser(messageUser);
                    ListaMensajeUsuariosMin.AddMessage(messageUser);
                }
                
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

            HubConection.On<int, Cliente>("EscogerHorario", (id, cliente) =>
            {
                ListaHorario.FirstOrDefault(x => x.Id == id).Cliente = cliente;
                StateHasChanged();
            });

            HubConection.On<int>("CancelarHorario", (id) =>
            {
                ListaHorario.FirstOrDefault(x => x.Id == id).Cliente = new();
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
            if (ListaMensajeUsuarios.IsNotExists(messageUser.Id)) 
            {
                if (ListaMensajeUsuarios.ListaMensajeUsuarios.Count() < 2)
                {
                    ListaMensajeUsuarios.ValidaUser(messageUser);
                }
                else
                {
                    /* si no hay es true */
                    if (ListaMensajeUsuariosMin.IsNotExists(messageUser.Id))
                    {
                        var objetUserMessage = ListaMensajeUsuarios.ListaMensajeUsuarios.First();

                        ListaMensajeUsuariosMin.ValidaConversacion(objetUserMessage);
                        ListaMensajeUsuarios.ListaMensajeUsuarios.Remove(objetUserMessage);

                        ListaMensajeUsuarios.ValidaUser(messageUser);
                    }
                    else
                    {
                        var obj = ListaMensajeUsuarios.ListaMensajeUsuarios.First();

                        ListaMensajeUsuariosMin.ValidaConversacion(obj);
                        ListaMensajeUsuarios.ListaMensajeUsuarios.Remove(obj);

                        var objetUserMessage = ListaMensajeUsuariosMin.ListaMensajeUsuarios.FirstOrDefault(x => x.Id == messageUser.Id);
                        ListaMensajeUsuarios.ValidaConversacion(objetUserMessage);
                        ListaMensajeUsuariosMin.ListaMensajeUsuarios.Remove(objetUserMessage);
                    }
                }
            }

            CModalListUsers.EventoModal();
            StateHasChanged();
        }

        protected void MaximizarMessagesUser(UserMessages userMessages) 
        {
            Console.WriteLine("-Inicio");
            if (ListaMensajeUsuarios.ListaMensajeUsuarios.Count() > 1) 
            {
                var obj = ListaMensajeUsuarios.ListaMensajeUsuarios.First();
                ListaMensajeUsuariosMin.ValidaConversacion(obj);
                ListaMensajeUsuarios.ListaMensajeUsuarios.Remove(obj);
            }
            ListaMensajeUsuarios.ValidaConversacion(userMessages);
            ListaMensajeUsuariosMin.ListaMensajeUsuarios.Remove(userMessages);
            Console.WriteLine("-Fin");
        }

        protected void MinimizarMessagesUser(UserMessages userMessages)
        {
            ListaMensajeUsuarios.ListaMensajeUsuarios.Remove(userMessages);
            ListaMensajeUsuariosMin.ValidaConversacion(userMessages);
        }

        protected void CloseMessagesUser(UserMessages userMessages)
        {
            ListaMensajeUsuarios.ListaMensajeUsuarios.Remove(userMessages);
        }

        protected async Task MensajePrivado(MessageUser messageUser) 
        {
            messageUser.Nombre = UserCliente.Nombre; /* Artificio, le asignamos Nombre de la session */
            messageUser.Emisor = true; /* Emisor */

            ListaMensajeUsuarios.AddMessage(messageUser);
            await HubConection.SendAsync("MensajePrivado", messageUser);
        }

        public async Task EscogerHorario(int id) 
        {
            await HubConection.SendAsync("EscogerHorario", id, UserCliente);
        }

        public async Task CancelarHorario(int id) 
        {
            await HubConection.SendAsync("CancelarHorario", id);
        }

        protected void BuscarUsuario(KeyboardEventArgs e) 
        {
            if (e.Key == "Enter") 
            {
                ListaCliente = ListaClienteH.Where(x => x.Nombre.ToLower().Contains(UsuarioFind.ToLower())).ToList();
            }
        }
    }
}
