using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class TipoAtendimento
{
    public short IdTipoAtendimento { get; set; }

    public string DsNome { get; set; } = null!;

    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();
}
