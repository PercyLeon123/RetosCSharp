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
    }
}
