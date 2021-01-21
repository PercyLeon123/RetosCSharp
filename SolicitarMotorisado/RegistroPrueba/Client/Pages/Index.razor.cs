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
        protected Modal CModal; /* Componente Modal instanciado */

        protected List<Cliente> ListaCliente = new();
        protected Cliente Cliente = new();

        protected override async Task OnInitializedAsync()
        {
            /* HubConnectionBuilder es un constructor para configurar instancias de HubConnection  */
            HubConection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/"))
                .Build();

            /* Metodo invocable por el servidor */
            HubConection.On<List<Cliente>>("ListarUsuario", (listaCliente) =>
            {
                ListaCliente = listaCliente;
                StateHasChanged();
            });

        }

        /* Consumir metodo del servidor */
        protected async Task SendLogin()
        {
            await HubConection.StartAsync(); /* Inicia una conexión con el servidor */
            await HubConection.SendAsync("SendLogin", Cliente); /*  Metodo del servidor */
        }

        protected async Task Login(bool? isAuthenticated)
        {
            await SendLogin();
        }
    }
}
