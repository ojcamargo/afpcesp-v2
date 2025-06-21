using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Destinatario
{
    public int IdDestinatario { get; set; }

    public string Nome { get; set; } = null!;

    public string? Endereco { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public int? IdCidade { get; set; }

    public string? Cep { get; set; }

    public string? Telefone1 { get; set; }

    public string? Telefone2 { get; set; }

    public string? Email { get; set; }

    public string? Car { get; set; }

    public string? Observacao { get; set; }

    public DateTime? DtNascimento { get; set; }

    public int IdMalaDireta { get; set; }

    public string? DsCentro { get; set; }

    public virtual Cidade? IdCidadeNavigation { get; set; }

    public virtual MalaDiretum IdMalaDiretaNavigation { get; set; } = null!;
}
