using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public string Nome { get; set; } = null!;

    public string Criador { get; set; } = null!;

    public DateTime? DataCriacao { get; set; }

    public int? CategoriaIdCategoria { get; set; }

    public virtual Categoria? CategoriaIdCategoriaNavigation { get; set; }

    public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();
}
