using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class CzAssociadoColoniaBkp
{
    public long IdRegistro { get; set; }

    public long IdAssociado { get; set; }

    public int IdColonia { get; set; }

    public DateTime DtReserva { get; set; }

    public DateTime DtInicio { get; set; }

    public DateTime DtFinal { get; set; }

    public string? NrApartamneto { get; set; }

    public string? NrRecibo { get; set; }

    public decimal? VlTotal { get; set; }

    public string? Observacao { get; set; }

    public bool FlConfirmado { get; set; }

    public bool FlCancelado { get; set; }

    public bool FlPa { get; set; }

    public bool FlProrrogado { get; set; }
}
