using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Uf
{
    public short IdUf { get; set; }

    public string DsSigla { get; set; } = null!;

    public string DsNome { get; set; } = null!;

    public virtual ICollection<Cidade> Cidades { get; set; } = new List<Cidade>();
}
