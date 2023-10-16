using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly CursosContext _context;
        public CursoController (CursosContext contexto){
            _context = contexto;
        }
        [HttpGet("cursos")]
        public async Task <ActionResult<List<Curso>>> BuscarCurso(){
            return Ok(await _context.Cursos.ToListAsync());
        }
    }
}