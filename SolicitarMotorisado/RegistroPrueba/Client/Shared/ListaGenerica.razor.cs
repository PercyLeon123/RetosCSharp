using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrueba.Client.Shared
{
    public partial class ListaGenerica<TObject>
    {
        [Parameter] public RenderFragment<TObject> Registro { get; set; }
        [Parameter] public List<TObject> ListObject{ get; set; }
    }
}
