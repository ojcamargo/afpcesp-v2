using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Acompanhante
{
    public long IdAcompanhante { get; set; }

    public string DsNome { get; set; } = null!;

    public string? NrIdade { get; set; }

    public short? IdParentesco { get; set; }

    public long IdReserva { get; set; }

    public virtual Parentesco? IdParentescoNavigation { get; set; }

    public virtual CzAssociadoColonium IdReservaNavigation { get; set; } = null!;
}
