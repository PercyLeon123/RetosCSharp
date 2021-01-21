using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrueba.Client.Shared
{
    public partial class NavMenu
    {
        protected bool CollapseNavManu = false;

        protected string NavMenuClass => (CollapseNavManu) ? "is-active" : "";
    }
}
