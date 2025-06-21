using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class ContasReceber
{
    public int IdContaReceber { get; set; }

    public string? DsContaReceber { get; set; }

    public decimal? Valor { get; set; }

    public DateTime? DataAtualizacao { get; set; }
}
