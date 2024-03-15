using System;
using System.Collections.Generic;

namespace proyecto.Services.DbcontextConnect;

public partial class Clase
{
    public string Nombre { get; set; } = null!;

    public long Id { get; set; }

    public long IdCurso { get; set; }
}
