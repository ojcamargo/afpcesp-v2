using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Parentesco
{
    public short IdParentesco { get; set; }

    public string DsNome { get; set; } = null!;

    public bool? FlFamiliar { get; set; }

    public virtual ICollection<Acompanhante> Acompanhantes { get; set; } = new List<Acompanhante>();
}
