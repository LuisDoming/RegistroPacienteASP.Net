using System;
using System.Collections.Generic;

namespace PacientesRegister.Models;

public partial class TipoSangre
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<DatosPaciente> DatosPacientes { get; } = new List<DatosPaciente>();
}
