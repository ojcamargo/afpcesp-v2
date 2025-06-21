using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class LogLocalidade
{
    public int LocNu { get; set; }

    public string UfeSg { get; set; } = null!;

    public string LocNo { get; set; } = null!;

    public string? Cep { get; set; }

    public string LocInSit { get; set; } = null!;

    public string LocInTipoLoc { get; set; } = null!;

    public int? LocNuSub { get; set; }

    public string? LocNoAbrev { get; set; }

    public int? MunNu { get; set; }
}
