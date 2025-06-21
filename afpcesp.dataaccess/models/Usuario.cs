using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string DsLogin { get; set; } = null!;

    public string? DsSenha { get; set; }

    public int? IdFuncionario { get; set; } = null!;

    public bool? FlAtivo { get; set; } = true;

    public virtual ICollection<AssociadosConferido> AssociadosConferidos { get; set; } = new List<AssociadosConferido>();

    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

    public virtual Funcionario? IdFuncionarioNavigation { get; set; }
}
