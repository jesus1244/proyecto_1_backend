using System;
using System.Collections.Generic;

namespace proyecto.Services.DbcontextConnect;

public partial class Programa
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
