using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class LogRegistro
{
    public long Id { get; set; }

    public int IdModulo { get; set; }

    public string DsAcao { get; set; } = null!;

    public int IdUsuario { get; set; }

    public string? IdRegistro { get; set; }

    public string? DsInfo { get; set; }

    public DateTime? DtRegistro { get; set; }

    public virtual Modulo IdModuloNavigation { get; set; } = null!;
}
