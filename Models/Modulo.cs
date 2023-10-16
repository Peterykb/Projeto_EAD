using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Modulo
{
    public int IdModulo { get; set; }

    public string Modulo1 { get; set; } = null!;

    public string Aula { get; set; } = null!;

    public int? CursoIdCurso { get; set; }

    public virtual Curso? CursoIdCursoNavigation { get; set; }
}
