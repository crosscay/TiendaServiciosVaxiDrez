using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Controllers
{
    //[Produces("application/json")]
    [Route("api/autor")]
    public class AutorController : Controller
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Nuevo.Ejecuta data)
        {
            await _mediator.Send(data);

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<AutorDto>> GetAutores()
        {
            return await _mediator.Send(new Consulta.ListaAutor());
        }

        [HttpGet("{id}")]
        public async Task<AutorDto> GetAutorLibro(int id)
        {
            return await _mediator.Send(new ConsultaFiltro.AutorUnico { AutorLibroId = id  });
        }
    }
}