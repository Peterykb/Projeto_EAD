using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Modulo
{
    public int IdModulo { get; set; }

    public string Titulo { get; set; } = null!;

    public int? CursoIdCurso { get; set; }

    public virtual ICollection<Aula> Aulas { get; set; } = new List<Aula>();

    public virtual Curso? CursoIdCursoNavigation { get; set; }
}
