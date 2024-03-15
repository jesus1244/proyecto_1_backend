using System;
using System.Collections.Generic;

namespace proyecto.Services.DbcontextConnect;

public partial class Curso
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public long IdPrograma { get; set; }

    public virtual Programa IdProgramaNavigation { get; set; } = null!;
}
