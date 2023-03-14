using System;
using System.Collections.Generic;

namespace PacientesRegister.Models;

public partial class DatosPaciente
{
    public string? Clavepaciente { get; set; }

    public long Id { get; set; }

    public string? Apellidos { get; set; }

    public string? NombrePac { get; set; }

    public string? DireccionPac { get; set; }

    public string? TelefonoCasa { get; set; }

    public string? TelefonoCelular { get; set; }

    public string? EmailPac { get; set; }

    public int? SexoPac { get; set; }

    public int Activo { get; set; }

    public int? TipoSangreId { get; set; }

    public virtual TipoSangre? TipoSangre { get; set; }
}
