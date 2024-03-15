using System;
using System.Collections.Generic;

namespace proyecto.Services.DbcontextConnect;

public partial class FormularioPrincipal
{
    public long Id { get; set; }

    public long? IdUsuario { get; set; }

    public long? IdCurso { get; set; }

    public string? FechaClaseRealizada { get; set; }

    public string? HorasRealizadas { get; set; }

    public long? IdClase { get; set; }

    public string? TemaClase { get; set; }

    public virtual Clase? IdClaseNavigation { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
