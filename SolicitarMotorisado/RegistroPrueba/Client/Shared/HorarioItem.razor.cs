using Microsoft.AspNetCore.Components;
using RegistroPrueba.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrueba.Client.Shared
{
    public partial class HorarioItem
    {
        [Parameter] public Horario Horario { get; set; }
        [Parameter] public EventCallback<int> Escoger { get; set; }
        [Parameter] public EventCallback<int> Cancelar { get; set; }
        [Parameter] public Cliente Cliente { get; set; }

        protected bool AnularRecerva = false;

        protected void EscogerHorario() 
        {
            Escoger.InvokeAsync(Horario.Id);
        }

        protected void CancelarHorario() 
        {
            Cancelar.InvokeAsync(Horario.Id);
            AnularRecerva = false;
        }



        /* ShouldRender solo renderizara los componentes que permita (TRUE) */
        protected override void OnParametersSet()
        {
            AnularRecerva = (Cliente.Id == Horario.Cliente.Id);
            base.OnParametersSet();
        }
    }
}
