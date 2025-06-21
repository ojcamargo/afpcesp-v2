using System;
using System.Collections.Generic;

namespace afpcesp.dataaccess.models;

public partial class Cidade
{
    public int IdCidade { get; set; }

    public string DsCidade { get; set; } = null!;

    public short IdUf { get; set; }

    public virtual ICollection<Advogado> Advogados { get; set; } = new List<Advogado>();

    public virtual ICollection<ColoniaFeria> ColoniaFeria { get; set; } = new List<ColoniaFeria>();

    public virtual ICollection<Corretora> Corretoras { get; set; } = new List<Corretora>();

    public virtual ICollection<Destinatario> Destinatarios { get; set; } = new List<Destinatario>();

    public virtual ICollection<EnderecoAssociado> EnderecoAssociados { get; set; } = new List<EnderecoAssociado>();

    public virtual ICollection<Faculdade> Faculdades { get; set; } = new List<Faculdade>();

    public virtual Uf IdUfNavigation { get; set; } = null!;

    public virtual ICollection<InstituicaoMedica> InstituicaoMedicas { get; set; } = new List<InstituicaoMedica>();

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();

    public virtual ICollection<Seguradora> Seguradoras { get; set; } = new List<Seguradora>();
}
