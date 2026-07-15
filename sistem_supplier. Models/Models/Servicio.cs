using System;
using System.Collections.Generic;

namespace sistem_supplier._Models.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string NomServicio { get; set; } = null!;

    public decimal? ValorHora { get; set; }

    public string? Pais { get; set; }
}
