using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public string DsNome { get; set; } = null!;

    public bool? FlAtivo { get; set; }

    public virtual ICollection<Permisso> Permissos { get; set; } = new List<Permisso>();
}
