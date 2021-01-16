using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrueba.Client.Helpers
{
    public interface IUtilitario
    {
        Task<string> GetAsyncString(string url);
        Task<string> PostAsyncString(string url, object parametro);
    }
}
