using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class AssociadosConferido
{
    public long IdAssociado { get; set; }

    public int IdUsuario { get; set; }

    public DateTime? DtConferencia { get; set; }

    public virtual Associado IdAssociadoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
