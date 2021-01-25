using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrueba.Client.Shared
{
    public partial class Modal
    {
        [Parameter] public RenderFragment Formulario { get; set; }
        [Parameter] public string Title { get; set; }


        protected bool EstadoModal = false;

        protected string ClassModal => (EstadoModal) ? "is-active is-clipped" : "";

        public void EventoModal() 
        {
            EstadoModal = !EstadoModal;
            StateHasChanged();
        }

    }
}
