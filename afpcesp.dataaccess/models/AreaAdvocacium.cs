using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class AreaAdvocacium
{
    public int IdAreaAdvocacia { get; set; }

    public string DsNome { get; set; } = null!;

    public bool FlAtivo { get; set; }

    public virtual ICollection<Advogado> IdAdvogados { get; set; } = new List<Advogado>();

    public virtual ICollection<Advogado> IdAdvogadosNavigation { get; set; } = new List<Advogado>();
}
