using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Dependente
{
    public int IdDependente { get; set; }

    public string DsNome { get; set; } = null!;

    public short? IdParentesco { get; set; }

    public long IdAssociado { get; set; }

    public DateTime? DtNascimento { get; set; }

    public bool FlPensionista { get; set; }

    public string? DsRg { get; set; }

    public virtual Associado IdAssociadoNavigation { get; set; } = null!;
}
