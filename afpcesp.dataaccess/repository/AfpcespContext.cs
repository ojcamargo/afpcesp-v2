using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using afpcesp.dataaccess.models;

namespace afpcesp.dataaccess.repository;

public partial class AfpcespContext : DbContext
{
    public AfpcespContext(IConfiguration configuration)
        : base(new DbContextOptionsBuilder<AfpcespContext>()
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .Options)
    {
    }

    public AfpcespContext(DbContextOptions<AfpcespContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acompanhante> Acompanhantes { get; set; }

    public virtual DbSet<Advogado> Advogados { get; set; }

    public virtual DbSet<AreaAdvocacium> AreaAdvocacia { get; set; }

    public virtual DbSet<Associado> Associados { get; set; }

    public virtual DbSet<AssociadosConferido> AssociadosConferidos { get; set; }

    public virtual DbSet<Atendimento> Atendimentos { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Cidade> Cidades { get; set; }

    public virtual DbSet<ColoniaFeria> ColoniaFerias { get; set; }

    public virtual DbSet<ContasReceber> ContasRecebers { get; set; }

    public virtual DbSet<Contato> Contatos { get; set; }

    public virtual DbSet<Corretora> Corretoras { get; set; }

    public virtual DbSet<CzAssociadoColoniaBkp> CzAssociadoColoniaBkps { get; set; }

    public virtual DbSet<CzAssociadoColonium> CzAssociadoColonia { get; set; }

    public virtual DbSet<CzAssociadoPensionistum> CzAssociadoPensionista { get; set; }

    public virtual DbSet<CzAssociadoSeguradora> CzAssociadoSeguradoras { get; set; }

    public virtual DbSet<CzGrupoUsuario> CzGrupoUsuarios { get; set; }

    public virtual DbSet<Dependente> Dependentes { get; set; }

    public virtual DbSet<Destinatario> Destinatarios { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<EnderecoAssociado> EnderecoAssociados { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }

    public virtual DbSet<Faculdade> Faculdades { get; set; }

    public virtual DbSet<FaixaCep> FaixaCeps { get; set; }

    public virtual DbSet<FaixaCep1> FaixaCeps1 { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<HistoricoReajusteSeguro> HistoricoReajusteSeguros { get; set; }

    public virtual DbSet<Inadimplencium> Inadimplencia { get; set; }

    public virtual DbSet<InstituicaoMedica> InstituicaoMedicas { get; set; }

    public virtual DbSet<LogBairro> LogBairros { get; set; }

    public virtual DbSet<LogBairroBkp> LogBairroBkps { get; set; }

    public virtual DbSet<LogLocalidade> LogLocalidades { get; set; }

    public virtual DbSet<LogLocalidadeBkp> LogLocalidadeBkps { get; set; }

    public virtual DbSet<LogLogradouro> LogLogradouros { get; set; }

    public virtual DbSet<LogLogradouroBkp> LogLogradouroBkps { get; set; }

    public virtual DbSet<LogRegistro> LogRegistros { get; set; }

    public virtual DbSet<MalaDiretum> MalaDireta { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<MotivoExclusao> MotivoExclusaos { get; set; }

    public virtual DbSet<ParametrosDocumento> ParametrosDocumentos { get; set; }

    public virtual DbSet<Parentesco> Parentescos { get; set; }

    public virtual DbSet<Permisso> Permissoes { get; set; }

    public virtual DbSet<Prodesp> Prodesps { get; set; }

    public virtual DbSet<Reajuste> Reajustes { get; set; }

    public virtual DbSet<Scc> Sccs { get; set; }

    public virtual DbSet<Seguradora> Seguradoras { get; set; }

    public virtual DbSet<Spprev> Spprevs { get; set; }

    public virtual DbSet<TipoAssociado> TipoAssociados { get; set; }

    public virtual DbSet<TipoAtendimento> TipoAtendimentos { get; set; }

    public virtual DbSet<TipoContato> TipoContatos { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<Uf> Ufs { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //  "Server=localhost;Database=afpcesp;User Id=sa;Password=admin@01;Encrypt=False"
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acompanhante>(entity =>
        {
            entity.HasKey(e => e.IdAcompanhante);

            entity.Property(e => e.DsNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NrIdade)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.IdParentescoNavigation).WithMany(p => p.Acompanhantes)
                .HasForeignKey(d => d.IdParentesco)
                .HasConstraintName("FK_Acompanhantes_Parentesco");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Acompanhantes)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Acompanhantes_Cz_Associado_Colonia");
        });

        modelBuilder.Entity<Advogado>(entity =>
        {
            entity.HasKey(e => e.IdAdvogado).HasName("PK__Advogado__0590134E2B8AC1CE");

            entity.HasIndex(e => e.DsNome, "UQ__Advogado__CFFF614864B7F102").IsUnique();

            entity.Property(e => e.DsBairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsCelular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsCep)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DsComplemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsCpf)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.DsEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsEndereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DsFax)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsNumero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsRegistroOab)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DsRegistroOAB");
            entity.Property(e => e.DsRg)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsTelefone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FlAtivo).HasDefaultValue(true);

            entity.HasOne(d => d.IdCidadeNavigation).WithMany(p => p.Advogados)
                .HasForeignKey(d => d.IdCidade)
                .HasConstraintName("FK_CIDADE_ADVOGADO");

            entity.HasMany(d => d.IdAreaAdvocacia).WithMany(p => p.IdAdvogados)
                .UsingEntity<Dictionary<string, object>>(
                    "CzAdvogadoArea",
                    r => r.HasOne<AreaAdvocacium>().WithMany()
                        .HasForeignKey("IdAreaAdvocacia")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_AreaAdvocacia"),
                    l => l.HasOne<Advogado>().WithMany()
                        .HasForeignKey("IdAdvogado")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Advogados"),
                    j =>
                    {
                        j.HasKey("IdAdvogado", "IdAreaAdvocacia").HasName("pk_cz_advogado_area");
                        j.ToTable("cz_advogado_area");
                    });
        });

        modelBuilder.Entity<AreaAdvocacium>(entity =>
        {
            entity.HasKey(e => e.IdAreaAdvocacia);

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FlAtivo).HasDefaultValue(true);

            entity.HasMany(d => d.IdAdvogadosNavigation).WithMany(p => p.IdAreaAdvocaciaNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "CzAdvogadoAreaAdvocacium",
                    r => r.HasOne<Advogado>().WithMany()
                        .HasForeignKey("IdAdvogado")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Cz_Advogado_AreaAdvocacia_Advogados"),
                    l => l.HasOne<AreaAdvocacium>().WithMany()
                        .HasForeignKey("IdAreaAdvocacia")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Cz_Advogado_AreaAdvocacia_AreaAdvocacia"),
                    j =>
                    {
                        j.HasKey("IdAreaAdvocacia", "IdAdvogado");
                        j.ToTable("Cz_Advogado_AreaAdvocacia");
                    });
        });

        modelBuilder.Entity<Associado>(entity =>
        {
            entity.HasKey(e => e.IdAssociado);

            entity.HasIndex(e => e.DsNome, "IX_Associados").IsUnique();

            entity.Property(e => e.DsCpf)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.DsDepartamento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsDivisao)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsLocalNascimento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsMae)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DsNome)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DsOrgaoEmissor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DsPai)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DsRg)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsRs)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsSexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("M")
                .IsFixedLength();
            entity.Property(e => e.DsUnidade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DtAfpcesp).HasColumnType("datetime");
            entity.Property(e => e.DtEmissaoRg).HasColumnType("datetime");
            entity.Property(e => e.DtExclusao).HasColumnType("datetime");
            entity.Property(e => e.DtFalecimento).HasColumnType("datetime");
            entity.Property(e => e.DtNascimento).HasColumnType("datetime");
            entity.Property(e => e.DtProdesp).HasColumnType("datetime");
            entity.Property(e => e.DtServicoPublico).HasColumnType("datetime");
            entity.Property(e => e.ImgFoto).HasColumnType("image");
            entity.Property(e => e.NrAverbacao)
                .HasMaxLength(23)
                .IsUnicode(false)
                .HasColumnName("nr_averbacao");
            entity.Property(e => e.NrAverbacao2)
                .HasMaxLength(23)
                .IsUnicode(false)
                .HasColumnName("nr_averbacao2");
            entity.Property(e => e.NrBeneficio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nr_beneficio");
            entity.Property(e => e.Observacao).HasColumnType("text");

            entity.HasOne(d => d.IdCarNavigation).WithMany(p => p.Associados)
                .HasForeignKey(d => d.IdCar)
                .HasConstraintName("FK_Associados_Cars");

            entity.HasOne(d => d.IdEstadoCivilNavigation).WithMany(p => p.Associados)
                .HasForeignKey(d => d.IdEstadoCivil)
                .HasConstraintName("FK_Associados_EstadoCivil");

            entity.HasOne(d => d.IdMotivoNavigation).WithMany(p => p.Associados)
                .HasForeignKey(d => d.IdMotivo)
                .HasConstraintName("FK_Associados_MotivoExclusao");

            entity.HasOne(d => d.IdTipoAssociadoNavigation).WithMany(p => p.Associados)
                .HasForeignKey(d => d.IdTipoAssociado)
                .HasConstraintName("FK_Associados_TipoAssociado");
        });

        modelBuilder.Entity<AssociadosConferido>(entity =>
        {
            entity.HasKey(e => new { e.IdAssociado, e.IdUsuario });

            entity.Property(e => e.DtConferencia).HasColumnType("datetime");

            entity.HasOne(d => d.IdAssociadoNavigation).WithMany(p => p.AssociadosConferidos)
                .HasForeignKey(d => d.IdAssociado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssociadosConferidos_Associados");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AssociadosConferidos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssociadosConferidos_Usuarios");
        });

        modelBuilder.Entity<Atendimento>(entity =>
        {
            entity.HasKey(e => e.IdAtendimento).HasName("PK__Atendime__84DAE47F7B14337F");

            entity.Property(e => e.DsAssunto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsAtendimento).HasColumnType("text");
            entity.Property(e => e.DsDestinatario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsResponsavelPagamento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DtRegistro).HasColumnType("datetime");

            entity.HasOne(d => d.IdAdvogadoNavigation).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.IdAdvogado)
                .HasConstraintName("FK_Atendimentos_Advogados");

            entity.HasOne(d => d.IdAssociadoNavigation).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.IdAssociado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Atendimento_Associado");

            entity.HasOne(d => d.IdColoniaNavigation).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.IdColonia)
                .HasConstraintName("FK_Atendimentos_ColoniaFerias");

            entity.HasOne(d => d.IdFaculdadeNavigation).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.IdFaculdade)
                .HasConstraintName("FK_Atendimentos_Faculdades");

            entity.HasOne(d => d.IdInstituicaoMedicaNavigation).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.IdInstituicaoMedica)
                .HasConstraintName("FK_Atendimentos_InstituicaoMedica");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.IdMedico)
                .HasConstraintName("FK_Atendimentos_Medicos");

            entity.HasOne(d => d.IdSeguradoraNavigation).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.IdSeguradora)
                .HasConstraintName("FK_Atendimentos_Seguradoras");

            entity.HasOne(d => d.IdTipoAtendimentoNavigation).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.IdTipoAtendimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Atendimento_TipoAtendimento");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Atendimento_Usuario");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.IdCar).HasName("PK__Cars__0FA78058BE6B7459");

            entity.HasIndex(e => e.DsNome, "IX_Car").IsUnique();

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cidade>(entity =>
        {
            entity.HasKey(e => e.IdCidade);

            entity.HasIndex(e => new { e.DsCidade, e.IdUf }, "uk_cidade").IsUnique();

            entity.Property(e => e.DsCidade)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUfNavigation).WithMany(p => p.Cidades)
                .HasForeignKey(d => d.IdUf)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cidades_Uf");
        });

        modelBuilder.Entity<ColoniaFeria>(entity =>
        {
            entity.HasKey(e => e.IdColonia).HasName("PK__ColoniaF__A1580F666C71A057");

            entity.HasIndex(e => e.DsNome, "uk_colonia").IsUnique();

            entity.Property(e => e.DsBairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsCep)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DsComplemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsEndereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DsFax)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsNumero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DsTelefone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FlAtivo).HasDefaultValue(true);

            entity.HasOne(d => d.IdCidadeNavigation).WithMany(p => p.ColoniaFeria)
                .HasForeignKey(d => d.IdCidade)
                .HasConstraintName("FK_ColoniaFerias_Cidades");
        });

        modelBuilder.Entity<ContasReceber>(entity =>
        {
            entity.HasKey(e => e.IdContaReceber);

            entity.ToTable("ContasReceber");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.DsContaReceber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("money");
        });

        modelBuilder.Entity<Contato>(entity =>
        {
            entity.HasKey(e => e.IdContato);

            entity.ToTable("Contato");

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsRamal)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.DsTelefone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAssociadoNavigation).WithMany(p => p.Contatos)
                .HasForeignKey(d => d.IdAssociado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contato_Associado");

            entity.HasOne(d => d.IdTipoContatoNavigation).WithMany(p => p.Contatos)
                .HasForeignKey(d => d.IdTipoContato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contato_TipoContato");
        });

        modelBuilder.Entity<Corretora>(entity =>
        {
            entity.HasKey(e => e.IdCorretora);

            entity.HasIndex(e => e.DsNome, "uk_corretora").IsUnique();

            entity.Property(e => e.DsBairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsCep)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DsComplemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsEndereco)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsFax)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsNumero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsTelefone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FlAtivo).HasDefaultValue(true);

            entity.HasOne(d => d.IdCidadeNavigation).WithMany(p => p.Corretoras)
                .HasForeignKey(d => d.IdCidade)
                .HasConstraintName("FK_Corretoras_Corretoras");

            entity.HasOne(d => d.IdSeguradoraNavigation).WithMany(p => p.Corretoras)
                .HasForeignKey(d => d.IdSeguradora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Corretoras_Seguradoras");
        });

        modelBuilder.Entity<CzAssociadoColoniaBkp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cz_Associado_Colonia_bkp");

            entity.Property(e => e.DtFinal).HasColumnType("datetime");
            entity.Property(e => e.DtInicio).HasColumnType("datetime");
            entity.Property(e => e.DtReserva).HasColumnType("datetime");
            entity.Property(e => e.IdRegistro).ValueGeneratedOnAdd();
            entity.Property(e => e.NrApartamneto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NrRecibo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Observacao).HasColumnType("text");
            entity.Property(e => e.VlTotal).HasColumnType("money");
        });

        modelBuilder.Entity<CzAssociadoColonium>(entity =>
        {
            entity.HasKey(e => e.IdRegistro);

            entity.ToTable("Cz_Associado_Colonia");

            entity.Property(e => e.DtFinal).HasColumnType("datetime");
            entity.Property(e => e.DtInicio).HasColumnType("datetime");
            entity.Property(e => e.DtReserva).HasColumnType("datetime");
            entity.Property(e => e.NrApartamneto)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NrRecibo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Observacao).HasColumnType("text");
            entity.Property(e => e.VlTotal).HasColumnType("money");

            entity.HasOne(d => d.IdAssociadoNavigation).WithMany(p => p.CzAssociadoColonia)
                .HasForeignKey(d => d.IdAssociado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cz_Associado_Colonia_Associados");

            entity.HasOne(d => d.IdColoniaNavigation).WithMany(p => p.CzAssociadoColonia)
                .HasForeignKey(d => d.IdColonia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cz_Associado_Colonia_ColoniaFerias");
        });

        modelBuilder.Entity<CzAssociadoPensionistum>(entity =>
        {
            entity.HasKey(e => new { e.IdAssociado, e.IdPensionista, e.IdDependente });

            entity.ToTable("Cz_Associado_Pensionista");

            entity.HasOne(d => d.IdAssociadoNavigation).WithMany(p => p.CzAssociadoPensionistumIdAssociadoNavigations)
                .HasForeignKey(d => d.IdAssociado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Associado_Pensionista_IdAssociado");

            entity.HasOne(d => d.IdPensionistaNavigation).WithMany(p => p.CzAssociadoPensionistumIdPensionistaNavigations)
                .HasForeignKey(d => d.IdPensionista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Associado_Pensionista_IdPensionista");
        });

        modelBuilder.Entity<CzAssociadoSeguradora>(entity =>
        {
            entity.HasKey(e => e.IdSeguroAssociado);

            entity.ToTable("Cz_Associado_Seguradora");

            entity.Property(e => e.DsObservacao).HasColumnType("text");
            entity.Property(e => e.DtCancelamento).HasColumnType("datetime");
            entity.Property(e => e.DtContrato).HasColumnType("datetime");
            entity.Property(e => e.FlAtivo).HasDefaultValue(true);
            entity.Property(e => e.NrCertificado)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.VlIndenizacaoAciente).HasColumnType("money");
            entity.Property(e => e.VlIndenizacaoMorte).HasColumnType("money");
            entity.Property(e => e.VlSeguroAcidente).HasColumnType("money");
            entity.Property(e => e.VlSeguroVida).HasColumnType("money");

            entity.HasOne(d => d.IdAssociadoNavigation).WithMany(p => p.CzAssociadoSeguradoras)
                .HasForeignKey(d => d.IdAssociado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cz_Associado_Seguradora_Associados");

            entity.HasOne(d => d.IdCorretoraNavigation).WithMany(p => p.CzAssociadoSeguradoras)
                .HasForeignKey(d => d.IdCorretora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cz_Associado_Seguradora_Corretoras");

            entity.HasOne(d => d.IdSeguradoraNavigation).WithMany(p => p.CzAssociadoSeguradoras)
                .HasForeignKey(d => d.IdSeguradora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cz_Associado_Seguradora_Seguradoras");
        });

        modelBuilder.Entity<CzGrupoUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cz_grupo_usuario");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany()
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("FK_CZ_Grupo_Usuario_Grupo");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_CZ_Grupo_Usuario_Usuario");
        });

        modelBuilder.Entity<Dependente>(entity =>
        {
            entity.HasKey(e => e.IdDependente);

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsRg)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DtNascimento).HasColumnType("datetime");

            entity.HasOne(d => d.IdAssociadoNavigation).WithMany(p => p.Dependentes)
                .HasForeignKey(d => d.IdAssociado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dependentes_Associados");
        });

        modelBuilder.Entity<Destinatario>(entity =>
        {
            entity.HasKey(e => e.IdDestinatario).HasName("PK__Destinat__49089CD5D6F23E16");

            entity.HasIndex(e => new { e.IdMalaDireta, e.Nome, e.Car }, "ucDestinatarios").IsUnique();

            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Car)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Complemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsCentro)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.DtNascimento).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Endereco)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Observacao).HasColumnType("text");
            entity.Property(e => e.Telefone1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefone2)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCidadeNavigation).WithMany(p => p.Destinatarios)
                .HasForeignKey(d => d.IdCidade)
                .HasConstraintName("FK_Destinatarios_Cidades");

            entity.HasOne(d => d.IdMalaDiretaNavigation).WithMany(p => p.Destinatarios)
                .HasForeignKey(d => d.IdMalaDireta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Destinatarios_MalaDireta");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.IdDocumento).HasName("PK__Document__E5207347E2A8B256");

            entity.HasIndex(e => e.DsTitulo, "UQ__Document__140C2804C5AF398D").IsUnique();

            entity.Property(e => e.DsTexto).HasColumnType("text");
            entity.Property(e => e.DsTitulo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FlAtual).HasDefaultValue(true);

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipodocumento_documento");
        });

        modelBuilder.Entity<EnderecoAssociado>(entity =>
        {
            entity.HasKey(e => e.IdEndereco).HasName("PK__Endereco__0B7C7F17459B22F1");

            entity.ToTable("EnderecoAssociado");

            entity.Property(e => e.DsBairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsCentro)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.DsCep)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DsComplemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsEndereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DsNumero)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCidadeNavigation).WithMany(p => p.EnderecoAssociados)
                .HasForeignKey(d => d.IdCidade)
                .HasConstraintName("FK_EnderecoAssociado_Cidades");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidade);

            entity.HasIndex(e => e.DsNome, "IX_Especialidades").IsUnique();

            entity.Property(e => e.DsNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FlAtivo).HasDefaultValue(true);
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCivil);

            entity.ToTable("EstadoCivil");

            entity.HasIndex(e => e.DsNome, "IX_EstadoCivil").IsUnique();

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Faculdade>(entity =>
        {
            entity.HasKey(e => e.IdFaculdade);

            entity.HasIndex(e => e.DsNome, "uk_faculdade").IsUnique();

            entity.Property(e => e.DsBairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsCep)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DsComplemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsEndereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DsFax)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsNumero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsSite)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DsTelefone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FlAtivo).HasDefaultValue(true);

            entity.HasOne(d => d.IdCidadeNavigation).WithMany(p => p.Faculdades)
                .HasForeignKey(d => d.IdCidade)
                .HasConstraintName("FK_Faculdades_Cidades");
        });

        modelBuilder.Entity<FaixaCep>(entity =>
        {
            entity.HasKey(e => e.IdFaixaCep).HasName("PK__Faixa_Ce__231ADD8E1C20F440");

            entity.ToTable("Faixa_Cep");

            entity.Property(e => e.DsCentro)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.DsCepFimFaixa)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DsCepInicioFaixa)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DsSubCentro)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FaixaCep1>(entity =>
        {
            entity.HasKey(e => e.IdFaixa);

            entity.ToTable("FaixaCep");

            entity.Property(e => e.IdFaixa).ValueGeneratedNever();
            entity.Property(e => e.Amarrado)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Centralizador)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PreAmarrado)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PreCentralizador)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.IdFuncionario);

            entity.HasIndex(e => e.DsNome, "UQ__Funciona__CFFF614886C66759").IsUnique();

            entity.Property(e => e.DsBairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsCep)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DsComplemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsCpf)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.DsEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsEndereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DsNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsNumero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsRg)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsTelefone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DtAdmissao).HasColumnType("datetime");
            entity.Property(e => e.DtDemissao).HasColumnType("datetime");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__Grupos__303F6FD9CD44358E");

            entity.HasIndex(e => e.DsNome, "UQ__Grupos__CFFF61481B222487").IsUnique();

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FlAtivo).HasDefaultValue(true);
        });

        modelBuilder.Entity<HistoricoReajusteSeguro>(entity =>
        {
            entity.HasKey(e => new { e.IdSeguroAssociado, e.DtAlteracao });

            entity.Property(e => e.DtAlteracao).HasColumnType("datetime");
            entity.Property(e => e.VlSeguroAcidente).HasColumnType("money");
            entity.Property(e => e.VlSeguroVida).HasColumnType("money");
        });

        modelBuilder.Entity<Inadimplencium>(entity =>
        {
            entity.HasKey(e => e.IdInadimplencia);

            entity.Property(e => e.DsObservacao).HasColumnType("text");
            entity.Property(e => e.DtPagamento).HasColumnType("datetime");
            entity.Property(e => e.DtRegistro).HasColumnType("datetime");

            entity.HasOne(d => d.IdAssociadoNavigation).WithMany(p => p.Inadimplencia)
                .HasForeignKey(d => d.IdAssociado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inadimplencia_Associados");

            entity.HasMany(d => d.IdColonia).WithMany(p => p.IdInadimplencia)
                .UsingEntity<Dictionary<string, object>>(
                    "CzInadimplenciaColonium",
                    r => r.HasOne<ColoniaFeria>().WithMany()
                        .HasForeignKey("IdColonia")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Cz_Inadimplencia_Colonia_ColoniaFerias"),
                    l => l.HasOne<Inadimplencium>().WithMany()
                        .HasForeignKey("IdInadimplencia")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Cz_Inadimplencia_Colonia_Inadimplencia"),
                    j =>
                    {
                        j.HasKey("IdInadimplencia", "IdColonia");
                        j.ToTable("Cz_Inadimplencia_Colonia");
                    });

            entity.HasMany(d => d.IdSeguradoras).WithMany(p => p.IdInadimplencia)
                .UsingEntity<Dictionary<string, object>>(
                    "CzInadimpleciaSeguradora",
                    r => r.HasOne<Seguradora>().WithMany()
                        .HasForeignKey("IdSeguradora")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Cz_Inadimplecia_Seguradora_Seguradoras"),
                    l => l.HasOne<Inadimplencium>().WithMany()
                        .HasForeignKey("IdInadimplencia")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Cz_Inadimplecia_Seguradora_Inadimplencia"),
                    j =>
                    {
                        j.HasKey("IdInadimplencia", "IdSeguradora");
                        j.ToTable("Cz_Inadimplecia_Seguradora");
                    });
        });

        modelBuilder.Entity<InstituicaoMedica>(entity =>
        {
            entity.HasKey(e => e.IdInstituicao);

            entity.ToTable("InstituicaoMedica");

            entity.Property(e => e.DsBairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsCep)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DsComplemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsEndereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsNumero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsTelefone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("H (Hospital) ou C (Clinica)");
            entity.Property(e => e.FlAtivo).HasDefaultValue(true);

            entity.HasOne(d => d.IdCidadeNavigation).WithMany(p => p.InstituicaoMedicas)
                .HasForeignKey(d => d.IdCidade)
                .HasConstraintName("FK_InstituicaoMedica_Cidades");
        });

        modelBuilder.Entity<LogBairro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LOG_BAIRRO");

            entity.Property(e => e.BaiNo)
                .HasMaxLength(72)
                .HasColumnName("BAI_NO");
            entity.Property(e => e.BaiNoAbrev)
                .HasMaxLength(36)
                .HasColumnName("BAI_NO_ABREV");
            entity.Property(e => e.BaiNu).HasColumnName("BAI_NU");
            entity.Property(e => e.LocNu).HasColumnName("LOC_NU");
            entity.Property(e => e.UfeSg)
                .HasMaxLength(2)
                .HasColumnName("UFE_SG");
        });

        modelBuilder.Entity<LogBairroBkp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LOG_BAIRRO_BKP");

            entity.Property(e => e.BaiNo)
                .HasMaxLength(72)
                .HasColumnName("BAI_NO");
            entity.Property(e => e.BaiNoAbrev)
                .HasMaxLength(36)
                .HasColumnName("BAI_NO_ABREV");
            entity.Property(e => e.BaiNu).HasColumnName("BAI_NU");
            entity.Property(e => e.LocNu).HasColumnName("LOC_NU");
            entity.Property(e => e.UfeSg)
                .HasMaxLength(2)
                .HasColumnName("UFE_SG");
        });

        modelBuilder.Entity<LogLocalidade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LOG_LOCALIDADE");

            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("CEP");
            entity.Property(e => e.LocInSit)
                .HasMaxLength(1)
                .HasColumnName("LOC_IN_SIT");
            entity.Property(e => e.LocInTipoLoc)
                .HasMaxLength(1)
                .HasColumnName("LOC_IN_TIPO_LOC");
            entity.Property(e => e.LocNo)
                .HasMaxLength(72)
                .HasColumnName("LOC_NO");
            entity.Property(e => e.LocNoAbrev)
                .HasMaxLength(36)
                .HasColumnName("LOC_NO_ABREV");
            entity.Property(e => e.LocNu).HasColumnName("LOC_NU");
            entity.Property(e => e.LocNuSub).HasColumnName("LOC_NU_SUB");
            entity.Property(e => e.MunNu).HasColumnName("MUN_NU");
            entity.Property(e => e.UfeSg)
                .HasMaxLength(2)
                .HasColumnName("UFE_SG");
        });

        modelBuilder.Entity<LogLocalidadeBkp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LOG_LOCALIDADE_BKP");

            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("CEP");
            entity.Property(e => e.LocInSit)
                .HasMaxLength(1)
                .HasColumnName("LOC_IN_SIT");
            entity.Property(e => e.LocInTipoLoc)
                .HasMaxLength(1)
                .HasColumnName("LOC_IN_TIPO_LOC");
            entity.Property(e => e.LocNo)
                .HasMaxLength(72)
                .HasColumnName("LOC_NO");
            entity.Property(e => e.LocNoAbrev)
                .HasMaxLength(36)
                .HasColumnName("LOC_NO_ABREV");
            entity.Property(e => e.LocNu).HasColumnName("LOC_NU");
            entity.Property(e => e.LocNuSub).HasColumnName("LOC_NU_SUB");
            entity.Property(e => e.MunNu).HasColumnName("MUN_NU");
            entity.Property(e => e.UfeSg)
                .HasMaxLength(2)
                .HasColumnName("UFE_SG");
        });

        modelBuilder.Entity<LogLogradouro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LOG_LOGRADOURO");

            entity.Property(e => e.BaiNuFim).HasColumnName("BAI_NU_FIM");
            entity.Property(e => e.BaiNuIni).HasColumnName("BAI_NU_INI");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("CEP");
            entity.Property(e => e.LocNu).HasColumnName("LOC_NU");
            entity.Property(e => e.LogComplemento)
                .HasMaxLength(100)
                .HasColumnName("LOG_COMPLEMENTO");
            entity.Property(e => e.LogNo)
                .HasMaxLength(100)
                .HasColumnName("LOG_NO");
            entity.Property(e => e.LogNoAbrev)
                .HasMaxLength(36)
                .HasColumnName("LOG_NO_ABREV");
            entity.Property(e => e.LogNu).HasColumnName("LOG_NU");
            entity.Property(e => e.LogStaTlo)
                .HasMaxLength(1)
                .HasColumnName("LOG_STA_TLO");
            entity.Property(e => e.TloTx)
                .HasMaxLength(72)
                .HasColumnName("TLO_TX");
            entity.Property(e => e.UfeSg)
                .HasMaxLength(2)
                .HasColumnName("UFE_SG");
        });

        modelBuilder.Entity<LogLogradouroBkp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LOG_LOGRADOURO_BKP");

            entity.Property(e => e.BaiNuFim).HasColumnName("BAI_NU_FIM");
            entity.Property(e => e.BaiNuIni).HasColumnName("BAI_NU_INI");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("CEP");
            entity.Property(e => e.LocNu).HasColumnName("LOC_NU");
            entity.Property(e => e.LogComplemento)
                .HasMaxLength(100)
                .HasColumnName("LOG_COMPLEMENTO");
            entity.Property(e => e.LogNo)
                .HasMaxLength(100)
                .HasColumnName("LOG_NO");
            entity.Property(e => e.LogNoAbrev)
                .HasMaxLength(36)
                .HasColumnName("LOG_NO_ABREV");
            entity.Property(e => e.LogNu).HasColumnName("LOG_NU");
            entity.Property(e => e.LogStaTlo)
                .HasMaxLength(1)
                .HasColumnName("LOG_STA_TLO");
            entity.Property(e => e.TloTx)
                .HasMaxLength(72)
                .HasColumnName("TLO_TX");
            entity.Property(e => e.UfeSg)
                .HasMaxLength(2)
                .HasColumnName("UFE_SG");
        });

        modelBuilder.Entity<LogRegistro>(entity =>
        {
            entity.Property(e => e.DsAcao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DsInfo).HasColumnType("text");
            entity.Property(e => e.DtRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdRegistro)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.LogRegistros)
                .HasForeignKey(d => d.IdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogRegistros_Usuarios");
        });

        modelBuilder.Entity<MalaDiretum>(entity =>
        {
            entity.HasKey(e => e.IdMalaDireta).HasName("PK__MalaDire__BB7A7EA500EEF2E5");

            entity.HasIndex(e => e.DsNome, "UQ__MalaDire__CFFF61481C68B8D5").IsUnique();

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PK__Medicos__C326E65222C9AA99");

            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Complemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crm)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Endereco)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCidadeNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdCidade)
                .HasConstraintName("FK_Medicos_Cidades");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu);

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsUrl)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMenuPaiNavigation).WithMany(p => p.InverseIdMenuPaiNavigation)
                .HasForeignKey(d => d.IdMenuPai)
                .HasConstraintName("FK_Menus_Menus");

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.IdModulo)
                .HasConstraintName("FK_Menus_Modulos");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo);

            entity.Property(e => e.DsNome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MotivoExclusao>(entity =>
        {
            entity.HasKey(e => e.IdMotivo);

            entity.ToTable("MotivoExclusao");

            entity.HasIndex(e => e.DsNome, "IX_MotivoExclusao").IsUnique();

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ParametrosDocumento>(entity =>
        {
            entity.HasKey(e => e.IdParametro).HasName("PK__Parametr__37B016F4842ABEF3");

            entity.HasIndex(e => e.DsNome, "UQ__Parametr__CFFF61487FF49108").IsUnique();

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsTag)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsTipo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Parentesco>(entity =>
        {
            entity.HasKey(e => e.IdParentesco);

            entity.ToTable("Parentesco");

            entity.HasIndex(e => e.DsNome, "IX_Parentesco").IsUnique();

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Permisso>(entity =>
        {
            entity.HasKey(e => new { e.IdModulo, e.IdGrupo });

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Permissos)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permissoes_Grupos");

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Permissos)
                .HasForeignKey(d => d.IdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permissoes_Modulos");
        });

        modelBuilder.Entity<Prodesp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PRODESP");

            entity.Property(e => e.CodAverbacao)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("COD_AVERBACAO");
            entity.Property(e => e.CodErro)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("COD_ERRO");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.DataDesc)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("DATA_DESC");
            entity.Property(e => e.Especie)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ESPECIE");
            entity.Property(e => e.Rs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RS");
            entity.Property(e => e.ValorDesc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("VALOR_DESC");
            entity.Property(e => e.ValorParc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("VALOR_PARC");
        });

        modelBuilder.Entity<Reajuste>(entity =>
        {
            entity.HasKey(e => e.IdReajuste).HasName("PK_Reajustes");

            entity.ToTable("Reajuste");

            entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
            entity.Property(e => e.Valor).HasColumnType("money");
        });

        modelBuilder.Entity<Scc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SCC");

            entity.Property(e => e.CodAverbacao)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("COD_AVERBACAO");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOME");
            entity.Property(e => e.Rs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RS");
        });

        modelBuilder.Entity<Seguradora>(entity =>
        {
            entity.HasKey(e => e.IdSeguradora);

            entity.HasIndex(e => e.DsNome, "uk_seguradora").IsUnique();

            entity.Property(e => e.DsBairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsCep)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DsCodiProdesp)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.DsComplemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsEndereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DsFax)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DsNumero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DsTelefone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FlAtivo).HasDefaultValue(true);

            entity.HasOne(d => d.IdCidadeNavigation).WithMany(p => p.Seguradoras)
                .HasForeignKey(d => d.IdCidade)
                .HasConstraintName("FK_Seguradoras_Cidades");
        });

        modelBuilder.Entity<Spprev>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SPPREV");

            entity.Property(e => e.CodAverbacao)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("COD_AVERBACAO");
            entity.Property(e => e.CodErro)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("COD_ERRO");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.DataDesc)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("DATA_DESC");
            entity.Property(e => e.Rs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RS");
            entity.Property(e => e.ValorDesc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("VALOR_DESC");
            entity.Property(e => e.ValorParc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("VALOR_PARC");
        });

        modelBuilder.Entity<TipoAssociado>(entity =>
        {
            entity.HasKey(e => e.IdTipoAssociado);

            entity.ToTable("TipoAssociado");

            entity.HasIndex(e => e.DsNome, "IX_TipoAssociado").IsUnique();

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoAtendimento>(entity =>
        {
            entity.HasKey(e => e.IdTipoAtendimento).HasName("PK__TipoAten__2DFF128BBBA917E2");

            entity.ToTable("TipoAtendimento");

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoContato>(entity =>
        {
            entity.HasKey(e => e.IdTipoContato);

            entity.ToTable("TipoContato");

            entity.HasIndex(e => e.DsNome, "IX_TipoContato").IsUnique();

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__TipoDocu__3AB3332F7DCD4004");

            entity.ToTable("TipoDocumento");

            entity.HasIndex(e => e.DsNome, "UQ__TipoDocu__CFFF6148127FBBA7").IsUnique();

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Uf>(entity =>
        {
            entity.HasKey(e => e.IdUf);

            entity.ToTable("Uf");

            entity.Property(e => e.DsNome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsSigla)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.DsLogin)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DsSenha)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FlAtivo).HasDefaultValue(true);

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdFuncionario)
                .HasConstraintName("FK_Usuarios_Funcionarios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
