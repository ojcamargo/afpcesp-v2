using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class CzGrupoUsuario
{
    public int? IdGrupo { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Grupo? IdGrupoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
