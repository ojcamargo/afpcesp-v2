using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class TipoDocumento
{
    public short IdTipoDocumento { get; set; }

    public string DsNome { get; set; } = null!;

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
