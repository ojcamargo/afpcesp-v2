using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Atendimento
{
    public long IdAtendimento { get; set; }

    public DateTime DtRegistro { get; set; }

    public string DsAssunto { get; set; } = null!;

    public short IdTipoAtendimento { get; set; }

    public int IdUsuario { get; set; }

    public long IdAssociado { get; set; }

    public string? DsAtendimento { get; set; }

    public bool? FlFeedback { get; set; }

    public bool? FlQualificacao { get; set; }

    public int? IdSeguradora { get; set; }

    public int? IdAdvogado { get; set; }

    public int? IdFaculdade { get; set; }

    public int? IdColonia { get; set; }

    public int? IdMedico { get; set; }

    public int? IdInstituicaoMedica { get; set; }

    public string? DsDestinatario { get; set; }

    public string? DsResponsavelPagamento { get; set; }

    public long? NumeroOficio { get; set; }

    public short? QuantidadeAcoes { get; set; }

    public virtual Advogado? IdAdvogadoNavigation { get; set; }

    public virtual Associado IdAssociadoNavigation { get; set; } = null!;

    public virtual ColoniaFeria? IdColoniaNavigation { get; set; }

    public virtual Faculdade? IdFaculdadeNavigation { get; set; }

    public virtual InstituicaoMedica? IdInstituicaoMedicaNavigation { get; set; }

    public virtual Medico? IdMedicoNavigation { get; set; }

    public virtual Seguradora? IdSeguradoraNavigation { get; set; }

    public virtual TipoAtendimento IdTipoAtendimentoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
