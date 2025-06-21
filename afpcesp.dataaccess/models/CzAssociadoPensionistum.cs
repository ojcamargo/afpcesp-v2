using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class CzAssociadoPensionistum
{
    public long IdAssociado { get; set; }

    public long IdPensionista { get; set; }

    public int IdDependente { get; set; }

    public virtual Associado IdAssociadoNavigation { get; set; } = null!;

    public virtual Associado IdPensionistaNavigation { get; set; } = null!;
}
