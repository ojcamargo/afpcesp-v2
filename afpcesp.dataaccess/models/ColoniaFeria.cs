using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class ColoniaFeria
{
    public int IdColonia { get; set; }

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

    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

    public virtual ICollection<CzAssociadoColonium> CzAssociadoColonia { get; set; } = new List<CzAssociadoColonium>();

    public virtual Cidade? IdCidadeNavigation { get; set; }

    public virtual ICollection<Inadimplencium> IdInadimplencia { get; set; } = new List<Inadimplencium>();
}
