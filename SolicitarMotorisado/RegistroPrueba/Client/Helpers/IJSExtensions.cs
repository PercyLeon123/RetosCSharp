using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace RegistroPrueba.Client.Helpers
{
    public static class IJSExtensions
    {
        public static async ValueTask<bool> ValidaMessage(this IJSRuntime JS, string title, string message, MessageType messageType) 
        {
            return await JS.InvokeAsync<bool>("ValidaMessage", title, message, messageType.ToString());
        }

        public static async ValueTask Message(this IJSRuntime JS, string title, string message, MessageType messageType) 
        {
            await JS.InvokeVoidAsync("Swal.fire", title, message, messageType.ToString());
        }

        public enum MessageType 
        {
            question, warning, error, success, info
        }
    }
}
