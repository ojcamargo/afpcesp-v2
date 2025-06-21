using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Seguradora
{
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

    public string? DsCodiProdesp { get; set; }

    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

    public virtual ICollection<Corretora> Corretoras { get; set; } = new List<Corretora>();

    public virtual ICollection<CzAssociadoSeguradora> CzAssociadoSeguradoras { get; set; } = new List<CzAssociadoSeguradora>();

    public virtual Cidade? IdCidadeNavigation { get; set; }

    public virtual ICollection<Inadimplencium> IdInadimplencia { get; set; } = new List<Inadimplencium>();
}
