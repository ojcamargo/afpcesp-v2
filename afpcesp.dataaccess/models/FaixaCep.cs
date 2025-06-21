using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class FaixaCep
{
    public int IdFaixaCep { get; set; }

    public string DsCepInicioFaixa { get; set; } = null!;

    public string DsCepFimFaixa { get; set; } = null!;

    public string DsCentro { get; set; } = null!;

    public string? DsSubCentro { get; set; }
}
