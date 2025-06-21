using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class ParametrosDocumento
{
    public int IdParametro { get; set; }

    public string DsNome { get; set; } = null!;

    public string DsTag { get; set; } = null!;

    public string? DsTipo { get; set; }
}
