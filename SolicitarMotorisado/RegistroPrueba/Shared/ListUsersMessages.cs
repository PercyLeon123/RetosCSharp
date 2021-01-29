using System;
using System.Collections.Generic;
using System.Linq;


namespace RegistroPrueba.Shared
{
    public class ListUsersMessages
    {
        public List<UserMessages> ListaMensajeUsuarios = new();


        public bool IsNotExists(string id) 
        {
            return (ListaMensajeUsuarios.Where(x => x.Id == id).ToList().Count() == 0);
        }

        public void ValidaUser(MessageUser messageUser) 
        {
            if (IsNotExists(messageUser.Id)) 
            {
                UserMessages userMessages = new() { Id = messageUser.Id, Nombre = messageUser.Nombre, Mesanjes = new() };
                ListaMensajeUsuarios.Add(userMessages);
            }
        }

        public void AddMessage(MessageUser messageUser) 
        {
            Message message = new() { Emisor = messageUser.Emisor, Mensaje = messageUser.Mensaje };
            ListaMensajeUsuarios.FirstOrDefault(x => x.Id == messageUser.Id).Mesanjes.Add(message);
        }

        public void ValidaConversacion(UserMessages userMessages)
        {
            if (IsNotExists(userMessages.Id))
            {
                ListaMensajeUsuarios.Add(userMessages);
            }
        }
    }
}
