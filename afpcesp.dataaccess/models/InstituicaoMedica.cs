using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class InstituicaoMedica
{
    public int IdInstituicao { get; set; }

    public string DsNome { get; set; } = null!;

    /// <summary>
    /// H (Hospital) ou C (Clinica)
    /// </summary>
    public string DsTipo { get; set; } = null!;

    public bool FlAtivo { get; set; }

    public string? DsEndereco { get; set; }

    public string? DsNumero { get; set; }

    public string? DsComplemento { get; set; }

    public string? DsBairro { get; set; }

    public int? IdCidade { get; set; }

    public string? DsCep { get; set; }

    public string? DsTelefone { get; set; }

    public string? DsEmail { get; set; }

    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

    public virtual Cidade? IdCidadeNavigation { get; set; }
}
