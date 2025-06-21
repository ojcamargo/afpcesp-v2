using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Inadimplencium
{
    public long IdInadimplencia { get; set; }

    public DateTime DtRegistro { get; set; }

    public bool FlPa { get; set; }

    public bool FlSeguro { get; set; }

    public bool FlAssociacao { get; set; }

    public bool FlColonia { get; set; }

    public string? DsObservacao { get; set; }

    public long IdAssociado { get; set; }

    public DateTime? DtPagamento { get; set; }

    public virtual Associado IdAssociadoNavigation { get; set; } = null!;

    public virtual ICollection<ColoniaFeria> IdColonia { get; set; } = new List<ColoniaFeria>();

    public virtual ICollection<Seguradora> IdSeguradoras { get; set; } = new List<Seguradora>();
}
