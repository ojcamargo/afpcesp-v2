using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Documento
{
    public int IdDocumento { get; set; }

    public string DsTitulo { get; set; } = null!;

    public short IdTipoDocumento { get; set; }

    public string DsTexto { get; set; } = null!;

    public bool FlAtual { get; set; }

    public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; } = null!;
}
