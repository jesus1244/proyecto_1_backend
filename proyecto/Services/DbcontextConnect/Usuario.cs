using System;
using System.Collections.Generic;

namespace proyecto.Services.DbcontextConnect;

public partial class Usuario
{
    public long Id { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime FechaInscripcion { get; set; }
}
