using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Libro.Aplicacion;

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/libromaterial")]
    public class LibroMaterialController : Controller
    {
        private readonly IMediator _mediator;

        public LibroMaterialController(IMediator mediator)
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
        public async Task<IEnumerable<LibroMaterialDto>> GetLibros()
        {
            return await _mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<LibroMaterialDto> GetLibroUnico(Guid id)
        {
            return await _mediator.Send(new ConsultaFiltro.LibroUnico { LibroId = id});
        }
    }
}