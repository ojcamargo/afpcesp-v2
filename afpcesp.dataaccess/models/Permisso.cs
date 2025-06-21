using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Permisso
{
    public int IdModulo { get; set; }

    public int IdGrupo { get; set; }

    public bool FlVisualizar { get; set; }

    public bool FlModificar { get; set; }

    public virtual Grupo IdGrupoNavigation { get; set; } = null!;

    public virtual Modulo IdModuloNavigation { get; set; } = null!;
}
