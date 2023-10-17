using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public string NomeCurso { get; set; } = null!;

    public string Criador { get; set; } = null!;

    public int DataCriacao { get; set; }

    public int? CategoriaIdCategoria { get; set; }

    public virtual Categoria? CategoriaIdCategoriaNavigation { get; set; }

    public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();
}
