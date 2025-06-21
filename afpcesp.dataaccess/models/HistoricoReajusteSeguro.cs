using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class HistoricoReajusteSeguro
{
    public long IdSeguroAssociado { get; set; }

    public DateTime DtAlteracao { get; set; }

    public decimal? VlSeguroVida { get; set; }

    public decimal? VlSeguroAcidente { get; set; }
}
