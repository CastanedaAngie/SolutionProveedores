using System;
using System.Collections.Generic;

namespace sistem_supplier._Models.Models;

public partial class ServicioProveedor
{
    public int IdServicioProveedor { get; set; }

    public int IdProveedor { get; set; }

    public int IdServicio { get; set; }
}
