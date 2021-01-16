using Microsoft.AspNetCore.SignalR;
using RegistroPrueba.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroPrueba.Server.Helpers;

namespace RegistroPrueba.Server.Services
{
    public class ServiceHub : Hub
    {
        /* Inicia coneccion por SignalR */
        public override async Task OnConnectedAsync() 
        {
            /* Context.ConnectionId es el Id de coneccion del que realizo la peticion */
            await Clients.Client(Context.ConnectionId).SendAsync("IniciarSesion", true);
            await base.OnConnectedAsync();
        }

        public async Task SendLogin(Cliente cliente) 
        {
            cliente.Id = Context.ConnectionId;
            Clientes.ListaCliente.Add(cliente); /* Agregamos al nuevo usuario a la lista global de usuarios */

            await Clients.Client(Context.ConnectionId).SendAsync("ListarUsuario", );
            await Clients.All.SendAsync("AddUser", cliente); /* Mostraremos al nuevo usuario */
        }


    }
}
