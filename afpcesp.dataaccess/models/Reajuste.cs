using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Reajuste
{
    public int IdReajuste { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    public decimal? Valor { get; set; }
}
