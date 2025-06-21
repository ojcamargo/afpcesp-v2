using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class CzAssociadoSeguradora
{
    public long IdSeguroAssociado { get; set; }

    public long IdAssociado { get; set; }

    public int IdSeguradora { get; set; }

    public int IdCorretora { get; set; }

    public string? NrCertificado { get; set; }

    public string? DsObservacao { get; set; }

    public bool FlAtivo { get; set; }

    public DateTime DtContrato { get; set; }

    public bool FlSeguroVida { get; set; }

    public bool FlSeguroAcidente { get; set; }

    public decimal? VlIndenizacaoMorte { get; set; }

    public decimal? VlIndenizacaoAciente { get; set; }

    public decimal? VlSeguroVida { get; set; }

    public decimal? VlSeguroAcidente { get; set; }

    public DateTime? DtCancelamento { get; set; }

    public bool FlManterHistorico { get; set; }

    public virtual Associado IdAssociadoNavigation { get; set; } = null!;

    public virtual Corretora IdCorretoraNavigation { get; set; } = null!;

    public virtual Seguradora IdSeguradoraNavigation { get; set; } = null!;
}
