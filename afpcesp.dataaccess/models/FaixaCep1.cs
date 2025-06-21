using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class FaixaCep1
{
    public int IdFaixa { get; set; }

    public double? FaixaInicial { get; set; }

    public double? FaixaFinal { get; set; }

    public string? PreAmarrado { get; set; }

    public string? PreCentralizador { get; set; }

    public string? Amarrado { get; set; }

    public string? Centralizador { get; set; }
}
