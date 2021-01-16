using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RegistroPrueba.Server.Services;
using RegistroPrueba.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrueba.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IHubContext<ServiceHub> ServiceHubContext;

        /* Inyección de dependencia */
        public UsuariosController(IHubContext<ServiceHub> serviceHubContext) 
        {
            ServiceHubContext = serviceHubContext;
        }

        //[HttpPost]
        //[Route("PostLogin")]
        //public Task<Control> PostLogin() 
        //{
        //    ServiceHubContext.Clients.
        //}
    }
}
