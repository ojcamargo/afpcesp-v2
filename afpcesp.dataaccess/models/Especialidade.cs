using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Especialidade
{
    public int IdEspecialidade { get; set; }

    public string DsNome { get; set; } = null!;

    public bool FlAtivo { get; set; }
}
