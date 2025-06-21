using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Modulo
{
    public int IdModulo { get; set; }

    public string DsNome { get; set; } = null!;

    public virtual ICollection<LogRegistro> LogRegistros { get; set; } = new List<LogRegistro>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<Permisso> Permissos { get; set; } = new List<Permisso>();
}
