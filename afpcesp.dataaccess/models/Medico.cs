using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Medico
{
    public int IdMedico { get; set; }

    public string Nome { get; set; } = null!;

    public string? Endereco { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public int? IdCidade { get; set; }

    public string? Cep { get; set; }

    public string? Telefone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? Crm { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

    public virtual Cidade? IdCidadeNavigation { get; set; }
}
