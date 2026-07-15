using System;
using System.Collections.Generic;

namespace sistem_supplier._Models.Models;

public partial class Proveedor
{
    public int idProveedor { get; set; }

    public string nomProveedor { get; set; } = null!;

    public string? CampoAdicional { get; set; }

    public string? NitProveedor { get; set; }
}
