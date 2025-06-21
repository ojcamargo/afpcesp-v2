using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Associado
{
    public long IdAssociado { get; set; }

    public long? IdAssociadoVinculo { get; set; }

    public string DsNome { get; set; } = null!;

    public bool? FlPolicial { get; set; }

    public short? IdCar { get; set; }

    public string? DsRg { get; set; }

    public string? DsOrgaoEmissor { get; set; }

    public DateTime? DtEmissaoRg { get; set; }

    public string? DsRs { get; set; }

    public string? DsSexo { get; set; }

    public string? DsEmail { get; set; }

    public string? DsCpf { get; set; }

    public DateTime? DtNascimento { get; set; }

    public string? DsLocalNascimento { get; set; }

    public string? DsPai { get; set; }

    public string? DsMae { get; set; }

    public DateTime? DtServicoPublico { get; set; }

    public string? DsUnidade { get; set; }

    public string? DsDivisao { get; set; }

    public string? DsDepartamento { get; set; }

    public DateTime? DtAfpcesp { get; set; }

    public DateTime? DtProdesp { get; set; }

    public DateTime? DtFalecimento { get; set; }

    public byte[]? ImgFoto { get; set; }

    public short? IdTipoAssociado { get; set; }

    public DateTime? DtExclusao { get; set; }

    public short? IdMotivo { get; set; }

    public short? IdEstadoCivil { get; set; }

    public bool FlAtivo { get; set; }

    public string? Observacao { get; set; }

    public string? NrBeneficio { get; set; }

    public string? NrAverbacao { get; set; }

    public string? NrAverbacao2 { get; set; }

    public virtual ICollection<AssociadosConferido> AssociadosConferidos { get; set; } = new List<AssociadosConferido>();

    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

    public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();

    public virtual ICollection<CzAssociadoColonium> CzAssociadoColonia { get; set; } = new List<CzAssociadoColonium>();

    public virtual ICollection<CzAssociadoPensionistum> CzAssociadoPensionistumIdAssociadoNavigations { get; set; } = new List<CzAssociadoPensionistum>();

    public virtual ICollection<CzAssociadoPensionistum> CzAssociadoPensionistumIdPensionistaNavigations { get; set; } = new List<CzAssociadoPensionistum>();

    public virtual ICollection<CzAssociadoSeguradora> CzAssociadoSeguradoras { get; set; } = new List<CzAssociadoSeguradora>();

    public virtual ICollection<Dependente> Dependentes { get; set; } = new List<Dependente>();

    public virtual Car? IdCarNavigation { get; set; }

    public virtual EstadoCivil? IdEstadoCivilNavigation { get; set; }

    public virtual MotivoExclusao? IdMotivoNavigation { get; set; }

    public virtual TipoAssociado? IdTipoAssociadoNavigation { get; set; }

    public virtual ICollection<Inadimplencium> Inadimplencia { get; set; } = new List<Inadimplencium>();
}
