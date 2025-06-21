using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Advogado
{
    public int IdAdvogado { get; set; }

    public string DsNome { get; set; } = null!;

    public string? DsRegistroOab { get; set; }

    public string? DsEndereco { get; set; }

    public string? DsNumero { get; set; }

    public string? DsBairro { get; set; }

    public string? DsComplemento { get; set; }

    public int? IdCidade { get; set; }

    public string? DsCep { get; set; }

    public string? DsTelefone { get; set; }

    public string? DsRg { get; set; }

    public string? DsCpf { get; set; }

    public string? DsEmail { get; set; }

    public bool FlAtivo { get; set; }

    public string? DsFax { get; set; }

    public string? DsCelular { get; set; }

    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

    public virtual Cidade? IdCidadeNavigation { get; set; }

    public virtual ICollection<AreaAdvocacium> IdAreaAdvocacia { get; set; } = new List<AreaAdvocacium>();

    public virtual ICollection<AreaAdvocacium> IdAreaAdvocaciaNavigation { get; set; } = new List<AreaAdvocacium>();
}
