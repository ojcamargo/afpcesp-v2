using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class EnderecoAssociado
{
    public int IdEndereco { get; set; }

    public long IdAssociado { get; set; }

    public string? DsEndereco { get; set; }

    public string? DsNumero { get; set; }

    public string? DsComplemento { get; set; }

    public string? DsBairro { get; set; }

    public int? IdCidade { get; set; }

    public string? DsCep { get; set; }

    public bool FlMalaDireta { get; set; }

    public short? IdTipoEndereco { get; set; }

    public string? DsCentro { get; set; }

    public virtual Cidade? IdCidadeNavigation { get; set; }
}
