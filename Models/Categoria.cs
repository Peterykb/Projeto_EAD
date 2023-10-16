using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Categoria1 { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
