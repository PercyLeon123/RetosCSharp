using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPrueba.Shared
{
    public class ListUsersMessages
    {
        public List<UserMessages> ListaMensajeUsuarios = new();

        public void ValidaUser(MessageUser messageUser) 
        {
            if (ListaMensajeUsuarios.Where(x => x.Id == messageUser.Id).ToList().Count() == 0) 
            {
                UserMessages userMessages = new() { Id = messageUser.Id, Nombre = messageUser.Nombre, Mesanjes = new() };
                ListaMensajeUsuarios.Add(userMessages);
            }
        }

        public void AddMessage(MessageUser messageUser) 
        {
            ListaMensajeUsuarios.FirstOrDefault(x => x.Id == messageUser.Id).Mesanjes.Add(messageUser.Mesanje);
        }
    }
}
