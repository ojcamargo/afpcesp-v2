using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Corretora
{
    public int IdCorretora { get; set; }

    public int IdSeguradora { get; set; }

    public string DsNome { get; set; } = null!;

    public bool FlAtivo { get; set; }

    public string? DsEndereco { get; set; }

    public string? DsNumero { get; set; }

    public string? DsComplemento { get; set; }

    public string? DsBairro { get; set; }

    public int? IdCidade { get; set; }

    public string? DsCep { get; set; }

    public string? DsTelefone { get; set; }

    public string? DsFax { get; set; }

    public string? DsEmail { get; set; }

    public virtual ICollection<CzAssociadoSeguradora> CzAssociadoSeguradoras { get; set; } = new List<CzAssociadoSeguradora>();

    public virtual Cidade? IdCidadeNavigation { get; set; }

    public virtual Seguradora IdSeguradoraNavigation { get; set; } = null!;
}
