using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Contato
{
    public int IdContato { get; set; }

    public string DsNome { get; set; } = null!;

    public long IdAssociado { get; set; }

    public string DsTelefone { get; set; } = null!;

    public string? DsRamal { get; set; }

    public short IdTipoContato { get; set; }

    public virtual Associado IdAssociadoNavigation { get; set; } = null!;

    public virtual TipoContato IdTipoContatoNavigation { get; set; } = null!;
}
