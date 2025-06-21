using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class LogBairro
{
    public int BaiNu { get; set; }

    public string UfeSg { get; set; } = null!;

    public int LocNu { get; set; }

    public string BaiNo { get; set; } = null!;

    public string? BaiNoAbrev { get; set; }
}
