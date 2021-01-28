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
            await Clients.Client(Context.ConnectionId).SendAsync("IniciarSesion", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public async Task SendLogin(Cliente cliente) 
        {
            cliente.Id = Context.ConnectionId;
            Clientes.ListaCliente.Add(cliente); /* Agregamos al nuevo usuario a la lista global de usuarios */

            await Clients.Client(Context.ConnectionId).SendAsync("ListarHorario", Horarios.ListaHorario);
            await Clients.Client(Context.ConnectionId).SendAsync("ListarUsuario", Clientes.ListaCliente.Where(x=> x.Id != Context.ConnectionId).ToList());
            await Clients.All.SendAsync("AddUser", cliente); /* Mostraremos al nuevo usuario */
        }

        public async Task MensajePrivado(MessageUser messageUser) 
        {
            var id = messageUser.Id;
            messageUser.Id = Context.ConnectionId;

            await Clients.Client(id).SendAsync("MensajePrivado", messageUser);
        }

        public async Task EscogerHorario(int id, Cliente cliente) 
        {
            Horarios.ListaHorario.FirstOrDefault(x => x.Id == id).Cliente = cliente;
            await Clients.All.SendAsync("EscogerHorario", id, cliente);
        }

        public async Task CancelarHorario(int id)
        {
            Horarios.ListaHorario.FirstOrDefault(x => x.Id == id).Cliente = new();
            await Clients.All.SendAsync("CancelarHorario", id);
        }
    }
}
