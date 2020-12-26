﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorLibro>
        {
            public int AutorLibroId { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorLibro>
        {
            public readonly ContextoAutor _contexto;

            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<AutorLibro> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.AutorLibro.Where(x => x.AutorLibroId == request.AutorLibroId).FirstOrDefaultAsync();

                if(autor == null)
                {
                    throw new Exception("No se encontro el autor");
                }

                return autor;
            }
        }
    }
}
