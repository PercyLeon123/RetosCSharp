using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroPrueba.Server.Helpers;
using RegistroPrueba.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrueba.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Horario>> Get() 
        {
            return Horarios.ListaHorario;
        }


        [HttpPost]
        public async Task<Control> PostRegistraHorario(int id, Cliente cliente) 
        {
            Control control = new();

            if (Horarios.ListaHorario.Find(x => x.Id == id).Disponible == true)
            {
                //Horarios.ListaHorario.Find(x => x.Id == id).Disponible = true;
                Horarios.ListaHorario.Find(x => x.Id == id).Cliente = cliente;
                control.Codigo = 200;
                control.Descripcion = "Su horario se registro exitosamente";
            }
            else 
            {
                control.Codigo = 300;
                control.Descripcion = "Horario no disponible";
            }

            return control;
        }

        [HttpPost]
        public async Task<Control> PostAnularHorario(int id, Cliente cliente) 
        {
            Control control = new();

            if (Horarios.ListaHorario.Find(x => x.Id == id).Disponible == false)
            {
                //Horarios.ListaHorario.Find(x => x.Id == id).Disponible = false;
                Horarios.ListaHorario.Find(x => x.Id == id).Cliente = new();

                control.Codigo = 200;
                control.Descripcion = "Su horario se anulo exitosamente";
            }
            else
            {
                control.Codigo = 300;
                control.Descripcion = "Error";
            }

            return control;
        }
    }
}
