using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Funcionario
{
    public int IdFuncionario { get; set; }

    public string DsNome { get; set; } = null!;

    public bool? FlAtivo { get; set; }

    public string? DsCpf { get; set; }

    public string? DsRg { get; set; }

    public string? DsTelefone { get; set; }

    public string? DsEmail { get; set; }

    public DateTime? DtAdmissao { get; set; }

    public DateTime? DtDemissao { get; set; }

    public string? DsEndereco { get; set; }

    public string? DsNumero { get; set; }

    public string? DsComplemento { get; set; }

    public string? DsBairro { get; set; }

    public int? IdCidade { get; set; }

    public string? DsCep { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
