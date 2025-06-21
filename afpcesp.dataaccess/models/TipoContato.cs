using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class TipoContato
{
    public short IdTipoContato { get; set; }

    public string DsNome { get; set; } = null!;

    public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
}
