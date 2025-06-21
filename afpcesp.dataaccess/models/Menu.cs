using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string DsNome { get; set; } = null!;

    public string? DsUrl { get; set; }

    public int? IdModulo { get; set; }

    public int? IdMenuPai { get; set; }

    public virtual Menu? IdMenuPaiNavigation { get; set; }

    public virtual Modulo? IdModuloNavigation { get; set; }

    public virtual ICollection<Menu> InverseIdMenuPaiNavigation { get; set; } = new List<Menu>();
}
