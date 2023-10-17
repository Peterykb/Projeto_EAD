using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Aula
{
    public int IdAula { get; set; }

    public string Titulo { get; set; } = null!;

    public string Conteudo { get; set; } = null!;

    public int? ModuloIdModulo { get; set; }

    public virtual Modulo? ModuloIdModuloNavigation { get; set; }
}
