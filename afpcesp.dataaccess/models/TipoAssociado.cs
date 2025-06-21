using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class TipoAssociado
{
    public short IdTipoAssociado { get; set; }

    public string DsNome { get; set; } = null!;

    public virtual ICollection<Associado> Associados { get; set; } = new List<Associado>();
}
