using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string NomeCategoria { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
