using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class MalaDiretum
{
    public int IdMalaDireta { get; set; }

    public string DsNome { get; set; } = null!;

    public virtual ICollection<Destinatario> Destinatarios { get; set; } = new List<Destinatario>();
}
