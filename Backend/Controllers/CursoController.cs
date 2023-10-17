using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ProjetoContext context;
        public CursoController(ProjetoContext curso){
            context = curso;
        }
        [HttpGet]
        public async Task <ActionResult<List<Curso>>> BuscarCursos(){
            return Ok(await context.Cursos.ToListAsync());
        }
    }
}