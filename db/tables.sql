IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MalaDireta]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MalaDireta](
	[IdMalaDireta] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMalaDireta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Uf]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Uf]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Uf](
	[IdUf] [smallint] IDENTITY(1,1) NOT NULL,
	[DsSigla] [char](2) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Uf] PRIMARY KEY CLUSTERED 
(
	[IdUf] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoDocumento]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TipoDocumento](
	[IdTipoDocumento] [smallint] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoDocumento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[TipoContato]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoContato]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TipoContato](
	[IdTipoContato] [smallint] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoContato] PRIMARY KEY CLUSTERED 
(
	[IdTipoContato] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TipoContato] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[TipoAtendimento]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoAtendimento]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TipoAtendimento](
	[IdTipoAtendimento] [smallint] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoAtendimento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[TipoAssociado]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoAssociado]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TipoAssociado](
	[IdTipoAssociado] [smallint] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoAssociado] PRIMARY KEY CLUSTERED 
(
	[IdTipoAssociado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TipoAssociado] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[SPPREV]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPPREV]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SPPREV](
	[CPF] [varchar](11) NULL,
	[RS] [varchar](20) NULL,
	[COD_AVERBACAO] [varchar](21) NULL,
	[DATA_DESC] [varchar](8) NULL,
	[VALOR_PARC] [varchar](15) NULL,
	[VALOR_DESC] [varchar](15) NULL,
	[COD_ERRO] [varchar](3) NULL
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Parentesco]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parentesco]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Parentesco](
	[IdParentesco] [smallint] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
	[FlFamiliar] [bit] NULL,
 CONSTRAINT [PK_Parentesco] PRIMARY KEY CLUSTERED 
(
	[IdParentesco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Parentesco] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[ParametrosDocumentos]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ParametrosDocumentos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ParametrosDocumentos](
	[IdParametro] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
	[DsTag] [varchar](20) NOT NULL,
	[DsTipo] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdParametro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[MotivoExclusao]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MotivoExclusao]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MotivoExclusao](
	[IdMotivo] [smallint] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MotivoExclusao] PRIMARY KEY CLUSTERED 
(
	[IdMotivo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_MotivoExclusao] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Modulos]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Modulos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Modulos](
	[IdModulo] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Modulos] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[SCC]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SCC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SCC](
	[CPF] [varchar](11) NULL,
	[RS] [varchar](20) NULL,
	[COD_AVERBACAO] [varchar](21) NULL,
	[NOME] [varchar](100) NULL
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Reajuste]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reajuste]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reajuste](
	[IdReajuste] [int] IDENTITY(1,1) NOT NULL,
	[DataAtualizacao] [datetime] NULL,
	[Valor] [money] NULL,
 CONSTRAINT [PK_Reajustes] PRIMARY KEY CLUSTERED 
(
	[IdReajuste] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[PRODESP]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRODESP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PRODESP](
	[CPF] [varchar](11) NULL,
	[RS] [varchar](20) NULL,
	[COD_AVERBACAO] [varchar](21) NULL,
	[DATA_DESC] [varchar](8) NULL,
	[VALOR_PARC] [varchar](15) NULL,
	[VALOR_DESC] [varchar](15) NULL,
	[COD_ERRO] [varchar](3) NULL,
	[ESPECIE] [varchar](5) NULL
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[HistoricoReajusteSeguros]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HistoricoReajusteSeguros]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HistoricoReajusteSeguros](
	[IdSeguroAssociado] [bigint] NOT NULL,
	[DtAlteracao] [datetime] NOT NULL,
	[VlSeguroVida] [money] NULL,
	[VlSeguroAcidente] [money] NULL,
 CONSTRAINT [PK_HistoricoReajusteSeguros] PRIMARY KEY CLUSTERED 
(
	[IdSeguroAssociado] ASC,
	[DtAlteracao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Grupos]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Grupos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Grupos](
	[IdGrupo] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
	[FlAtivo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Funcionarios]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcionarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Funcionarios](
	[IdFuncionario] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](100) NOT NULL,
	[FlAtivo] [bit] NULL,
	[DsCpf] [varchar](14) NULL,
	[DsRg] [varchar](20) NULL,
	[DsTelefone] [varchar](20) NULL,
	[DsEmail] [varchar](100) NULL,
	[DtAdmissao] [datetime] NULL,
	[DtDemissao] [datetime] NULL,
	[DsEndereco] [varchar](200) NULL,
	[DsNumero] [varchar](20) NULL,
	[DsComplemento] [varchar](50) NULL,
	[DsBairro] [varchar](50) NULL,
	[IdCidade] [int] NULL,
	[DsCep] [varchar](9) NULL,
 CONSTRAINT [PK_Funcionarios] PRIMARY KEY CLUSTERED 
(
	[IdFuncionario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[FaixaCep]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FaixaCep]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FaixaCep](
	[IdFaixa] [int] NOT NULL,
	[FaixaInicial] [float] NULL,
	[FaixaFinal] [float] NULL,
	[PreAmarrado] [varchar](10) NULL,
	[PreCentralizador] [varchar](10) NULL,
	[Amarrado] [varchar](100) NULL,
	[Centralizador] [varchar](100) NULL,
 CONSTRAINT [PK_FaixaCep] PRIMARY KEY CLUSTERED 
(
	[IdFaixa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Faixa_Cep]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Faixa_Cep]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Faixa_Cep](
	[IdFaixaCep] [int] IDENTITY(1,1) NOT NULL,
	[DsCepInicioFaixa] [varchar](9) NOT NULL,
	[DsCepFimFaixa] [varchar](9) NOT NULL,
	[DsCentro] [varchar](60) NOT NULL,
	[DsSubCentro] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFaixaCep] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[LOG_LOGRADOURO_BKP]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LOG_LOGRADOURO_BKP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LOG_LOGRADOURO_BKP](
	[LOG_NU] [int] NOT NULL,
	[UFE_SG] [nvarchar](2) NOT NULL,
	[LOC_NU] [int] NOT NULL,
	[BAI_NU_INI] [int] NULL,
	[BAI_NU_FIM] [int] NULL,
	[LOG_NO] [nvarchar](100) NOT NULL,
	[LOG_COMPLEMENTO] [nvarchar](100) NULL,
	[CEP] [nvarchar](8) NOT NULL,
	[TLO_TX] [nvarchar](72) NULL,
	[LOG_STA_TLO] [nvarchar](1) NULL,
	[LOG_NO_ABREV] [nvarchar](36) NULL
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[LOG_LOGRADOURO]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LOG_LOGRADOURO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LOG_LOGRADOURO](
	[LOG_NU] [int] NOT NULL,
	[UFE_SG] [nvarchar](2) NOT NULL,
	[LOC_NU] [int] NOT NULL,
	[BAI_NU_INI] [int] NULL,
	[BAI_NU_FIM] [int] NULL,
	[LOG_NO] [nvarchar](100) NOT NULL,
	[LOG_COMPLEMENTO] [nvarchar](100) NULL,
	[CEP] [nvarchar](8) NOT NULL,
	[TLO_TX] [nvarchar](72) NULL,
	[LOG_STA_TLO] [nvarchar](1) NULL,
	[LOG_NO_ABREV] [nvarchar](36) NULL
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[LOG_LOCALIDADE_BKP]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LOG_LOCALIDADE_BKP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LOG_LOCALIDADE_BKP](
	[LOC_NU] [int] NOT NULL,
	[UFE_SG] [nvarchar](2) NOT NULL,
	[LOC_NO] [nvarchar](72) NOT NULL,
	[CEP] [nvarchar](8) NULL,
	[LOC_IN_SIT] [nvarchar](1) NOT NULL,
	[LOC_IN_TIPO_LOC] [nvarchar](1) NOT NULL,
	[LOC_NU_SUB] [int] NULL,
	[LOC_NO_ABREV] [nvarchar](36) NULL,
	[MUN_NU] [int] NULL
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[LOG_LOCALIDADE]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LOG_LOCALIDADE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LOG_LOCALIDADE](
	[LOC_NU] [int] NOT NULL,
	[UFE_SG] [nvarchar](2) NOT NULL,
	[LOC_NO] [nvarchar](72) NOT NULL,
	[CEP] [nvarchar](8) NULL,
	[LOC_IN_SIT] [nvarchar](1) NOT NULL,
	[LOC_IN_TIPO_LOC] [nvarchar](1) NOT NULL,
	[LOC_NU_SUB] [int] NULL,
	[LOC_NO_ABREV] [nvarchar](36) NULL,
	[MUN_NU] [int] NULL
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[LOG_BAIRRO_BKP]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LOG_BAIRRO_BKP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LOG_BAIRRO_BKP](
	[BAI_NU] [int] NOT NULL,
	[UFE_SG] [nvarchar](2) NOT NULL,
	[LOC_NU] [int] NOT NULL,
	[BAI_NO] [nvarchar](72) NOT NULL,
	[BAI_NO_ABREV] [nvarchar](36) NULL
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[LOG_BAIRRO]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LOG_BAIRRO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LOG_BAIRRO](
	[BAI_NU] [int] NOT NULL,
	[UFE_SG] [nvarchar](2) NOT NULL,
	[LOC_NU] [int] NOT NULL,
	[BAI_NO] [nvarchar](72) NOT NULL,
	[BAI_NO_ABREV] [nvarchar](36) NULL
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Cz_Associado_Colonia_bkp]    Script Date: 05/19/2025 17:59:11 ******/


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Colonia_bkp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cz_Associado_Colonia_bkp](
	[IdRegistro] [bigint] IDENTITY(1,1) NOT NULL,
	[IdAssociado] [bigint] NOT NULL,
	[IdColonia] [int] NOT NULL,
	[DtReserva] [datetime] NOT NULL,
	[DtInicio] [datetime] NOT NULL,
	[DtFinal] [datetime] NOT NULL,
	[NrApartamneto] [varchar](10) NULL,
	[NrRecibo] [varchar](10) NULL,
	[VlTotal] [money] NULL,
	[Observacao] [text] NULL,
	[FlConfirmado] [bit] NOT NULL,
	[FlCancelado] [bit] NOT NULL,
	[FlPa] [bit] NOT NULL,
	[FlProrrogado] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

/****** Object:  Table [dbo].[EstadoCivil]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EstadoCivil]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EstadoCivil](
	[IdEstadoCivil] [smallint] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoCivil] PRIMARY KEY CLUSTERED 
(
	[IdEstadoCivil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_EstadoCivil] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Especialidades]    Script Date: 05/19/2025 17:59:11 ******/


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Especialidades]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Especialidades](
	[IdEspecialidade] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](100) NOT NULL,
	[FlAtivo] [bit] NOT NULL,
 CONSTRAINT [PK_Especialidades] PRIMARY KEY CLUSTERED 
(
	[IdEspecialidade] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Especialidades] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[AreaAdvocacia]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AreaAdvocacia]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AreaAdvocacia](
	[IdAreaAdvocacia] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
	[FlAtivo] [bit] NOT NULL,
 CONSTRAINT [PK_AreaAdvocacia] PRIMARY KEY CLUSTERED 
(
	[IdAreaAdvocacia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Cars]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cars](
	[IdCar] [smallint] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCar] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Car] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[ContasReceber]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContasReceber]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ContasReceber](
	[IdContaReceber] [int] IDENTITY(1,1) NOT NULL,
	[DsContaReceber] [varchar](100) NULL,
	[Valor] [money] NULL,
	[DataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_ContasReceber] PRIMARY KEY CLUSTERED 
(
	[IdContaReceber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Cidades]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cidades]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cidades](
	[IdCidade] [int] IDENTITY(1,1) NOT NULL,
	[DsCidade] [varchar](100) NOT NULL,
	[IdUf] [smallint] NOT NULL,
 CONSTRAINT [PK_Cidades] PRIMARY KEY CLUSTERED 
(
	[IdCidade] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [uk_cidade] UNIQUE NONCLUSTERED 
(
	[DsCidade] ASC,
	[IdUf] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Associados]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Associados]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Associados](
	[IdAssociado] [bigint] IDENTITY(1,1) NOT NULL,
	[IdAssociadoVinculo] [bigint] NULL,
	[DsNome] [varchar](200) NOT NULL,
	[FlPolicial] [bit] NULL,
	[IdCar] [smallint] NULL,
	[DsRg] [varchar](20) NULL,
	[DsOrgaoEmissor] [varchar](10) NULL,
	[DtEmissaoRg] [datetime] NULL,
	[DsRs] [varchar](20) NULL,
	[DsSexo] [char](1) NULL,
	[DsEmail] [varchar](100) NULL,
	[DsCpf] [varchar](14) NULL,
	[DtNascimento] [datetime] NULL,
	[DsLocalNascimento] [varchar](100) NULL,
	[DsPai] [varchar](200) NULL,
	[DsMae] [varchar](200) NULL,
	[DtServicoPublico] [datetime] NULL,
	[DsUnidade] [varchar](50) NULL,
	[DsDivisao] [varchar](50) NULL,
	[DsDepartamento] [varchar](50) NULL,
	[DtAfpcesp] [datetime] NULL,
	[DtProdesp] [datetime] NULL,
	[DtFalecimento] [datetime] NULL,
	[ImgFoto] [image] NULL,
	[IdTipoAssociado] [smallint] NULL,
	[DtExclusao] [datetime] NULL,
	[IdMotivo] [smallint] NULL,
	[IdEstadoCivil] [smallint] NULL,
	[FlAtivo] [bit] NOT NULL,
	[Observacao] [text] NULL,
	[nr_beneficio] [varchar](15) NULL,
	[nr_averbacao] [varchar](23) NULL,
	[nr_averbacao2] [varchar](23) NULL,
 CONSTRAINT [PK_Associados] PRIMARY KEY CLUSTERED 
(
	[IdAssociado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Associados] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

/****** Object:  Table [dbo].[Documentos]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Documentos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Documentos](
	[IdDocumento] [int] IDENTITY(1,1) NOT NULL,
	[DsTitulo] [varchar](100) NOT NULL,
	[IdTipoDocumento] [smallint] NOT NULL,
	[DsTexto] [text] NOT NULL,
	[FlAtual] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDocumento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DsTitulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[DsLogin] [varchar](50) NOT NULL,
	[DsSenha] [varchar](200) NULL,
	[IdFuncionario] [int] NULL,
	[FlAtivo] [bit] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Permissoes]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permissoes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Permissoes](
	[IdModulo] [int] NOT NULL,
	[IdGrupo] [int] NOT NULL,
	[FlVisualizar] [bit] NOT NULL,
	[FlModificar] [bit] NOT NULL,
 CONSTRAINT [PK_Permissoes] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC,
	[IdGrupo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Menus]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Menus](
	[IdMenu] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
	[DsUrl] [varchar](100) NULL,
	[IdModulo] [int] NULL,
	[IdMenuPai] [int] NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[IdMenu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[LogRegistros]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogRegistros]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogRegistros](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdModulo] [int] NOT NULL,
	[DsAcao] [char](1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdRegistro] [varchar](30) NULL,
	[DsInfo] [text] NULL,
	[DtRegistro] [datetime] NULL,
 CONSTRAINT [PK_LogRegistros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

/****** Object:  Table [dbo].[Cz_Associado_Pensionista]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Pensionista]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cz_Associado_Pensionista](
	[IdAssociado] [bigint] NOT NULL,
	[IdPensionista] [bigint] NOT NULL,
	[IdDependente] [int] NOT NULL,
 CONSTRAINT [PK_Cz_Associado_Pensionista] PRIMARY KEY CLUSTERED 
(
	[IdAssociado] ASC,
	[IdPensionista] ASC,
	[IdDependente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Medicos]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Medicos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Medicos](
	[IdMedico] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Endereco] [varchar](100) NULL,
	[Numero] [varchar](20) NULL,
	[Complemento] [varchar](50) NULL,
	[Bairro] [varchar](100) NULL,
	[IdCidade] [int] NULL,
	[Cep] [varchar](9) NULL,
	[Telefone] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[Crm] [varchar](10) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMedico] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Seguradoras]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Seguradoras]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Seguradoras](
	[IdSeguradora] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](100) NOT NULL,
	[FlAtivo] [bit] NOT NULL,
	[DsEndereco] [varchar](200) NULL,
	[DsNumero] [varchar](20) NULL,
	[DsComplemento] [varchar](50) NULL,
	[DsBairro] [varchar](50) NULL,
	[IdCidade] [int] NULL,
	[DsCep] [varchar](9) NULL,
	[DsTelefone] [varchar](20) NULL,
	[DsFax] [varchar](20) NULL,
	[DsEmail] [varchar](100) NULL,
	[DsCodiProdesp] [varchar](2) NULL,
 CONSTRAINT [PK_Seguradoras] PRIMARY KEY CLUSTERED 
(
	[IdSeguradora] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [uk_seguradora] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[InstituicaoMedica]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InstituicaoMedica]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[InstituicaoMedica](
	[IdInstituicao] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
	[DsTipo] [char](1) NOT NULL,
	[FlAtivo] [bit] NOT NULL,
	[DsEndereco] [varchar](200) NULL,
	[DsNumero] [varchar](20) NULL,
	[DsComplemento] [varchar](50) NULL,
	[DsBairro] [varchar](50) NULL,
	[IdCidade] [int] NULL,
	[DsCep] [varchar](9) NULL,
	[DsTelefone] [varchar](20) NULL,
	[DsEmail] [varchar](100) NULL,
 CONSTRAINT [PK_InstituicaoMedica] PRIMARY KEY CLUSTERED 
(
	[IdInstituicao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'InstituicaoMedica', N'COLUMN',N'DsTipo'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'H (Hospital) ou C (Clinica)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstituicaoMedica', @level2type=N'COLUMN',@level2name=N'DsTipo'

/****** Object:  Table [dbo].[Inadimplencia]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inadimplencia]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Inadimplencia](
	[IdInadimplencia] [bigint] IDENTITY(1,1) NOT NULL,
	[DtRegistro] [datetime] NOT NULL,
	[FlPa] [bit] NOT NULL,
	[FlSeguro] [bit] NOT NULL,
	[FlAssociacao] [bit] NOT NULL,
	[FlColonia] [bit] NOT NULL,
	[DsObservacao] [text] NULL,
	[IdAssociado] [bigint] NOT NULL,
	[DtPagamento] [datetime] NULL,
 CONSTRAINT [PK_Inadimplencia] PRIMARY KEY CLUSTERED 
(
	[IdInadimplencia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

/****** Object:  Table [dbo].[Faculdades]    Script Date: 05/19/2025 17:59:11 ******/


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Faculdades]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Faculdades](
	[IdFaculdade] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](100) NOT NULL,
	[DsEndereco] [varchar](200) NULL,
	[DsNumero] [varchar](20) NULL,
	[DsComplemento] [varchar](50) NULL,
	[DsBairro] [varchar](50) NULL,
	[IdCidade] [int] NULL,
	[DsCep] [varchar](9) NULL,
	[DsTelefone] [varchar](20) NULL,
	[DsFax] [varchar](20) NULL,
	[DsEmail] [varchar](100) NULL,
	[FlAtivo] [bit] NOT NULL,
	[DsSite] [varchar](200) NULL,
 CONSTRAINT [PK_Faculdades] PRIMARY KEY CLUSTERED 
(
	[IdFaculdade] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [uk_faculdade] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Contato]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contato]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contato](
	[IdContato] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
	[IdAssociado] [bigint] NOT NULL,
	[DsTelefone] [varchar](20) NOT NULL,
	[DsRamal] [varchar](6) NULL,
	[IdTipoContato] [smallint] NOT NULL,
 CONSTRAINT [PK_Contato] PRIMARY KEY CLUSTERED 
(
	[IdContato] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[AssociadosConferidos]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssociadosConferidos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AssociadosConferidos](
	[IdAssociado] [bigint] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[DtConferencia] [datetime] NULL,
 CONSTRAINT [PK_AssociadosConferidos] PRIMARY KEY CLUSTERED 
(
	[IdAssociado] ASC,
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[cz_grupo_usuario]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cz_grupo_usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cz_grupo_usuario](
	[IdGrupo] [int] NULL,
	[IdUsuario] [int] NULL
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[EnderecoAssociado]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EnderecoAssociado]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EnderecoAssociado](
	[IdEndereco] [int] IDENTITY(1,1) NOT NULL,
	[IdAssociado] [bigint] NOT NULL,
	[DsEndereco] [varchar](200) NULL,
	[DsNumero] [varchar](20) NULL,
	[DsComplemento] [varchar](50) NULL,
	[DsBairro] [varchar](50) NULL,
	[IdCidade] [int] NULL,
	[DsCep] [varchar](9) NULL,
	[FlMalaDireta] [bit] NOT NULL,
	[IdTipoEndereco] [smallint] NULL
) ON [PRIMARY]

ALTER TABLE [dbo].[EnderecoAssociado] ADD [DsCentro] [varchar](60) NULL
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[EnderecoAssociado]') AND name = N'PK__Endereco__0B7C7F1703B16C81')
ALTER TABLE [dbo].[EnderecoAssociado] ADD PRIMARY KEY CLUSTERED 
(
	[IdEndereco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Destinatarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Destinatarios](
	[IdDestinatario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Endereco] [varchar](100) NULL,
	[Numero] [varchar](20) NULL,
	[Complemento] [varchar](50) NULL,
	[Bairro] [varchar](100) NULL,
	[IdCidade] [int] NULL,
	[Cep] [varchar](9) NULL,
	[Telefone1] [varchar](20) NULL,
	[Telefone2] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[Car] [varchar](50) NULL,
	[Observacao] [text] NULL,
	[DtNascimento] [datetime] NULL,
	[IdMalaDireta] [int] NOT NULL,
	[DsCentro] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDestinatario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [ucDestinatarios] UNIQUE NONCLUSTERED 
(
	[IdMalaDireta] ASC,
	[Nome] ASC,
	[Car] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

/****** Object:  Table [dbo].[Dependentes]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dependentes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Dependentes](
	[IdDependente] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](50) NOT NULL,
	[IdParentesco] [smallint] NULL,
	[IdAssociado] [bigint] NOT NULL,
	[DtNascimento] [datetime] NULL,
	[FlPensionista] [bit] NOT NULL,
	[DsRg] [varchar](20) NULL,
 CONSTRAINT [PK_Dependentes] PRIMARY KEY CLUSTERED 
(
	[IdDependente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Advogados]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advogados]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Advogados](
	[IdAdvogado] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](100) NOT NULL,
	[DsRegistroOAB] [varchar](10) NULL,
	[DsEndereco] [varchar](200) NULL,
	[DsNumero] [varchar](20) NULL,
	[DsBairro] [varchar](50) NULL,
	[DsComplemento] [varchar](50) NULL,
	[IdCidade] [int] NULL,
	[DsCep] [varchar](9) NULL,
	[DsTelefone] [varchar](20) NULL,
	[DsRg] [varchar](20) NULL,
	[DsCpf] [varchar](14) NULL,
	[DsEmail] [varchar](100) NULL,
	[FlAtivo] [bit] NOT NULL,
	[DsFax] [varchar](20) NULL,
	[DsCelular] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAdvogado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[ColoniaFerias]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColoniaFerias]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ColoniaFerias](
	[IdColonia] [int] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](100) NOT NULL,
	[FlAtivo] [bit] NOT NULL,
	[DsEndereco] [varchar](200) NULL,
	[DsNumero] [varchar](10) NULL,
	[DsComplemento] [varchar](50) NULL,
	[DsBairro] [varchar](50) NULL,
	[IdCidade] [int] NULL,
	[DsCep] [varchar](9) NULL,
	[DsTelefone] [varchar](20) NULL,
	[DsFax] [varchar](20) NULL,
	[DsEmail] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdColonia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [uk_colonia] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Atendimentos]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Atendimentos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Atendimentos](
	[IdAtendimento] [bigint] IDENTITY(1,1) NOT NULL,
	[DtRegistro] [datetime] NOT NULL,
	[DsAssunto] [varchar](100) NOT NULL,
	[IdTipoAtendimento] [smallint] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdAssociado] [bigint] NOT NULL,
	[DsAtendimento] [text] NULL,
	[FlFeedback] [bit] NULL,
	[FlQualificacao] [bit] NULL,
	[IdSeguradora] [int] NULL,
	[IdAdvogado] [int] NULL,
	[IdFaculdade] [int] NULL,
	[IdColonia] [int] NULL,
	[IdMedico] [int] NULL,
	[IdInstituicaoMedica] [int] NULL,
	[DsDestinatario] [varchar](100) NULL,
	[DsResponsavelPagamento] [varchar](20) NULL,
	[NumeroOficio] [bigint] NULL,
	[QuantidadeAcoes] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAtendimento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

/****** Object:  Table [dbo].[Cz_Inadimplencia_Colonia]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cz_Inadimplencia_Colonia]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cz_Inadimplencia_Colonia](
	[IdInadimplencia] [bigint] NOT NULL,
	[IdColonia] [int] NOT NULL,
 CONSTRAINT [PK_Cz_Inadimplencia_Colonia] PRIMARY KEY CLUSTERED 
(
	[IdInadimplencia] ASC,
	[IdColonia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Cz_Inadimplecia_Seguradora]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cz_Inadimplecia_Seguradora]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cz_Inadimplecia_Seguradora](
	[IdInadimplencia] [bigint] NOT NULL,
	[IdSeguradora] [int] NOT NULL,
 CONSTRAINT [PK_Cz_Inadimplecia_Seguradora] PRIMARY KEY CLUSTERED 
(
	[IdInadimplencia] ASC,
	[IdSeguradora] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Cz_Associado_Colonia]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Colonia]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cz_Associado_Colonia](
	[IdRegistro] [bigint] IDENTITY(1,1) NOT NULL,
	[IdAssociado] [bigint] NOT NULL,
	[IdColonia] [int] NOT NULL,
	[DtReserva] [datetime] NOT NULL,
	[DtInicio] [datetime] NOT NULL,
	[DtFinal] [datetime] NOT NULL,
	[NrApartamneto] [varchar](20) NULL,
	[NrRecibo] [varchar](25) NULL,
	[VlTotal] [money] NULL,
	[Observacao] [text] NULL,
	[FlConfirmado] [bit] NOT NULL,
	[FlCancelado] [bit] NOT NULL,
	[FlPa] [bit] NOT NULL,
	[FlProrrogado] [bit] NOT NULL,
 CONSTRAINT [PK_Cz_Associado_Colonia] PRIMARY KEY CLUSTERED 
(
	[IdRegistro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

/****** Object:  Table [dbo].[Cz_Advogado_AreaAdvocacia]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cz_Advogado_AreaAdvocacia]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cz_Advogado_AreaAdvocacia](
	[IdAreaAdvocacia] [int] NOT NULL,
	[IdAdvogado] [int] NOT NULL,
 CONSTRAINT [PK_Cz_Advogado_AreaAdvocacia] PRIMARY KEY CLUSTERED 
(
	[IdAreaAdvocacia] ASC,
	[IdAdvogado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[cz_advogado_area]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cz_advogado_area]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cz_advogado_area](
	[IdAdvogado] [int] NOT NULL,
	[IdAreaAdvocacia] [int] NOT NULL,
 CONSTRAINT [pk_cz_advogado_area] PRIMARY KEY CLUSTERED 
(
	[IdAdvogado] ASC,
	[IdAreaAdvocacia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Corretoras]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Corretoras]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Corretoras](
	[IdCorretora] [int] IDENTITY(1,1) NOT NULL,
	[IdSeguradora] [int] NOT NULL,
	[DsNome] [varchar](100) NOT NULL,
	[FlAtivo] [bit] NOT NULL,
	[DsEndereco] [varchar](100) NULL,
	[DsNumero] [varchar](20) NULL,
	[DsComplemento] [varchar](50) NULL,
	[DsBairro] [varchar](50) NULL,
	[IdCidade] [int] NULL,
	[DsCep] [varchar](9) NULL,
	[DsTelefone] [varchar](20) NULL,
	[DsFax] [varchar](20) NULL,
	[DsEmail] [varchar](100) NULL,
 CONSTRAINT [PK_Corretoras] PRIMARY KEY CLUSTERED 
(
	[IdCorretora] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [uk_corretora] UNIQUE NONCLUSTERED 
(
	[DsNome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[Cz_Associado_Seguradora]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Seguradora]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cz_Associado_Seguradora](
	[IdSeguroAssociado] [bigint] IDENTITY(1,1) NOT NULL,
	[IdAssociado] [bigint] NOT NULL,
	[IdSeguradora] [int] NOT NULL,
	[IdCorretora] [int] NOT NULL,
	[NrCertificado] [varchar](10) NULL,
	[DsObservacao] [text] NULL,
	[FlAtivo] [bit] NOT NULL,
	[DtContrato] [datetime] NOT NULL,
	[FlSeguroVida] [bit] NOT NULL,
	[FlSeguroAcidente] [bit] NOT NULL,
	[VlIndenizacaoMorte] [money] NULL,
	[VlIndenizacaoAciente] [money] NULL,
	[VlSeguroVida] [money] NULL,
	[VlSeguroAcidente] [money] NULL,
	[DtCancelamento] [datetime] NULL,
	[FlManterHistorico] [bit] NOT NULL,
 CONSTRAINT [PK_Cz_Associado_Seguradora] PRIMARY KEY CLUSTERED 
(
	[IdSeguroAssociado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

/****** Object:  Table [dbo].[Acompanhantes]    Script Date: 05/19/2025 17:59:11 ******/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Acompanhantes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Acompanhantes](
	[IdAcompanhante] [bigint] IDENTITY(1,1) NOT NULL,
	[DsNome] [varchar](100) NOT NULL,
	[NrIdade] [varchar](5) NULL,
	[IdParentesco] [smallint] NULL,
	[IdReserva] [bigint] NOT NULL,
 CONSTRAINT [PK_Acompanhantes] PRIMARY KEY CLUSTERED 
(
	[IdAcompanhante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

/****** Object:  Default [DF__Advogados__FlAti__6EB64F9B]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__Advogados__FlAti__6EB64F9B]') AND parent_object_id = OBJECT_ID(N'[dbo].[Advogados]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Advogados__FlAti__6EB64F9B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Advogados] ADD  DEFAULT ((1)) FOR [FlAtivo]
END
End

/****** Object:  Default [DF_AreaAdvocacia_FlAtivo]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_AreaAdvocacia_FlAtivo]') AND parent_object_id = OBJECT_ID(N'[dbo].[AreaAdvocacia]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_AreaAdvocacia_FlAtivo]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AreaAdvocacia] ADD  CONSTRAINT [DF_AreaAdvocacia_FlAtivo]  DEFAULT ((1)) FOR [FlAtivo]
END
End

/****** Object:  Default [DF_Associados_DsSexo]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Associados_DsSexo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Associados]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Associados_DsSexo]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Associados] ADD  CONSTRAINT [DF_Associados_DsSexo]  DEFAULT ('M') FOR [DsSexo]
END
End

/****** Object:  Default [DF__ColoniaFe__FlAti__746F28F1]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__ColoniaFe__FlAti__746F28F1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ColoniaFerias]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ColoniaFe__FlAti__746F28F1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ColoniaFerias] ADD  DEFAULT ((1)) FOR [FlAtivo]
END
End

/****** Object:  Default [DF_Corretoras_FlAtivo]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Corretoras_FlAtivo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Corretoras]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Corretoras_FlAtivo]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Corretoras] ADD  CONSTRAINT [DF_Corretoras_FlAtivo]  DEFAULT ((1)) FOR [FlAtivo]
END
End

/****** Object:  Default [DF_Cz_Associado_Colonia_FlConfirmado]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cz_Associado_Colonia_FlConfirmado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Colonia]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Cz_Associado_Colonia_FlConfirmado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cz_Associado_Colonia] ADD  CONSTRAINT [DF_Cz_Associado_Colonia_FlConfirmado]  DEFAULT ((0)) FOR [FlConfirmado]
END
End

/****** Object:  Default [DF_Cz_Associado_Colonia_FlCancelado]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cz_Associado_Colonia_FlCancelado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Colonia]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Cz_Associado_Colonia_FlCancelado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cz_Associado_Colonia] ADD  CONSTRAINT [DF_Cz_Associado_Colonia_FlCancelado]  DEFAULT ((0)) FOR [FlCancelado]
END
End

/****** Object:  Default [DF_Cz_Associado_Colonia_FlPa]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cz_Associado_Colonia_FlPa]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Colonia]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Cz_Associado_Colonia_FlPa]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cz_Associado_Colonia] ADD  CONSTRAINT [DF_Cz_Associado_Colonia_FlPa]  DEFAULT ((0)) FOR [FlPa]
END
End

/****** Object:  Default [DF_Cz_Associado_Colonia_FlProrrogado]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cz_Associado_Colonia_FlProrrogado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Colonia]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Cz_Associado_Colonia_FlProrrogado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cz_Associado_Colonia] ADD  CONSTRAINT [DF_Cz_Associado_Colonia_FlProrrogado]  DEFAULT ((0)) FOR [FlProrrogado]
END
End

/****** Object:  Default [DF_Cz_Associado_Seguradora_FlAtivo]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cz_Associado_Seguradora_FlAtivo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Seguradora]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Cz_Associado_Seguradora_FlAtivo]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cz_Associado_Seguradora] ADD  CONSTRAINT [DF_Cz_Associado_Seguradora_FlAtivo]  DEFAULT ((1)) FOR [FlAtivo]
END
End

/****** Object:  Default [DF_Cz_Associado_Seguradora_FlSeguroVida]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cz_Associado_Seguradora_FlSeguroVida]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Seguradora]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Cz_Associado_Seguradora_FlSeguroVida]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cz_Associado_Seguradora] ADD  CONSTRAINT [DF_Cz_Associado_Seguradora_FlSeguroVida]  DEFAULT ((0)) FOR [FlSeguroVida]
END
End

/****** Object:  Default [DF_Cz_Associado_Seguradora_FlSeguroAcidente]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cz_Associado_Seguradora_FlSeguroAcidente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Seguradora]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Cz_Associado_Seguradora_FlSeguroAcidente]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cz_Associado_Seguradora] ADD  CONSTRAINT [DF_Cz_Associado_Seguradora_FlSeguroAcidente]  DEFAULT ((0)) FOR [FlSeguroAcidente]
END
End

/****** Object:  Default [DF_Cz_Associado_Seguradora_FlManterHistorico]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cz_Associado_Seguradora_FlManterHistorico]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Seguradora]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Cz_Associado_Seguradora_FlManterHistorico]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cz_Associado_Seguradora] ADD  CONSTRAINT [DF_Cz_Associado_Seguradora_FlManterHistorico]  DEFAULT ((0)) FOR [FlManterHistorico]
END
End

/****** Object:  Default [DF__Dependent__FlPen__64C2D10D]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__Dependent__FlPen__64C2D10D]') AND parent_object_id = OBJECT_ID(N'[dbo].[Dependentes]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Dependent__FlPen__64C2D10D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Dependentes] ADD  DEFAULT ((0)) FOR [FlPensionista]
END
End

/****** Object:  Default [DF__Documento__FlAtu__7AB2122C]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__Documento__FlAtu__7AB2122C]') AND parent_object_id = OBJECT_ID(N'[dbo].[Documentos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Documento__FlAtu__7AB2122C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Documentos] ADD  DEFAULT ((1)) FOR [FlAtual]
END
End

/****** Object:  Default [DF_EnderecoAssociado_FlMalaDireta]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_EnderecoAssociado_FlMalaDireta]') AND parent_object_id = OBJECT_ID(N'[dbo].[EnderecoAssociado]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EnderecoAssociado_FlMalaDireta]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EnderecoAssociado] ADD  CONSTRAINT [DF_EnderecoAssociado_FlMalaDireta]  DEFAULT ((0)) FOR [FlMalaDireta]
END
End

/****** Object:  Default [DF_Especialidades_Ativo]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Especialidades_Ativo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Especialidades]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Especialidades_Ativo]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Especialidades] ADD  CONSTRAINT [DF_Especialidades_Ativo]  DEFAULT ((1)) FOR [FlAtivo]
END
End

/****** Object:  Default [DF_Faculdades_FlAtivo]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Faculdades_FlAtivo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Faculdades]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Faculdades_FlAtivo]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Faculdades] ADD  CONSTRAINT [DF_Faculdades_FlAtivo]  DEFAULT ((1)) FOR [FlAtivo]
END
End

/****** Object:  Default [DF__Grupos__FlAtivo__385A3EEA]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__Grupos__FlAtivo__385A3EEA]') AND parent_object_id = OBJECT_ID(N'[dbo].[Grupos]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Grupos__FlAtivo__385A3EEA]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Grupos] ADD  DEFAULT ((1)) FOR [FlAtivo]
END
End

/****** Object:  Default [DF_Inadimplencia_FlPa]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Inadimplencia_FlPa]') AND parent_object_id = OBJECT_ID(N'[dbo].[Inadimplencia]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Inadimplencia_FlPa]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Inadimplencia] ADD  CONSTRAINT [DF_Inadimplencia_FlPa]  DEFAULT ((0)) FOR [FlPa]
END
End

/****** Object:  Default [DF_Inadimplencia_FlSeguro]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Inadimplencia_FlSeguro]') AND parent_object_id = OBJECT_ID(N'[dbo].[Inadimplencia]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Inadimplencia_FlSeguro]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Inadimplencia] ADD  CONSTRAINT [DF_Inadimplencia_FlSeguro]  DEFAULT ((0)) FOR [FlSeguro]
END
End

/****** Object:  Default [DF_Inadimplencia_FlAssociacao]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Inadimplencia_FlAssociacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Inadimplencia]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Inadimplencia_FlAssociacao]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Inadimplencia] ADD  CONSTRAINT [DF_Inadimplencia_FlAssociacao]  DEFAULT ((0)) FOR [FlAssociacao]
END
End

/****** Object:  Default [DF_Inadimplencia_FlColonia]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Inadimplencia_FlColonia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Inadimplencia]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Inadimplencia_FlColonia]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Inadimplencia] ADD  CONSTRAINT [DF_Inadimplencia_FlColonia]  DEFAULT ((0)) FOR [FlColonia]
END
End

/****** Object:  Default [DF_InstituicaoMedica_FlAtivo]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_InstituicaoMedica_FlAtivo]') AND parent_object_id = OBJECT_ID(N'[dbo].[InstituicaoMedica]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_InstituicaoMedica_FlAtivo]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[InstituicaoMedica] ADD  CONSTRAINT [DF_InstituicaoMedica_FlAtivo]  DEFAULT ((1)) FOR [FlAtivo]
END
End

/****** Object:  Default [DF__LogRegist__DtReg__5C979F60]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__LogRegist__DtReg__5C979F60]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogRegistros]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__LogRegist__DtReg__5C979F60]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LogRegistros] ADD  DEFAULT (getdate()) FOR [DtRegistro]
END
End

/****** Object:  Default [DF_Permissoes_FlVisualizar]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Permissoes_FlVisualizar]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permissoes]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Permissoes_FlVisualizar]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Permissoes] ADD  CONSTRAINT [DF_Permissoes_FlVisualizar]  DEFAULT ((0)) FOR [FlVisualizar]
END
End

/****** Object:  Default [DF_Permissoes_FlAlterar]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Permissoes_FlAlterar]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permissoes]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Permissoes_FlAlterar]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Permissoes] ADD  CONSTRAINT [DF_Permissoes_FlAlterar]  DEFAULT ((0)) FOR [FlModificar]
END
End

/****** Object:  Default [DF_Seguradoras_FlAtivo]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Seguradoras_FlAtivo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Seguradoras]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Seguradoras_FlAtivo]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Seguradoras] ADD  CONSTRAINT [DF_Seguradoras_FlAtivo]  DEFAULT ((1)) FOR [FlAtivo]
END
End

/****** Object:  Default [DF__Usuarios__FlAtiv__55EAA1D1]    Script Date: 05/19/2025 17:59:11 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__Usuarios__FlAtiv__55EAA1D1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuarios]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Usuarios__FlAtiv__55EAA1D1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((1)) FOR [FlAtivo]
END
End

/****** Object:  ForeignKey [FK_Acompanhantes_Cz_Associado_Colonia]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Acompanhantes_Cz_Associado_Colonia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Acompanhantes]'))
ALTER TABLE [dbo].[Acompanhantes]  WITH NOCHECK ADD  CONSTRAINT [FK_Acompanhantes_Cz_Associado_Colonia] FOREIGN KEY([IdReserva])
REFERENCES [dbo].[Cz_Associado_Colonia] ([IdRegistro])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Acompanhantes_Cz_Associado_Colonia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Acompanhantes]'))
ALTER TABLE [dbo].[Acompanhantes] CHECK CONSTRAINT [FK_Acompanhantes_Cz_Associado_Colonia]

/****** Object:  ForeignKey [FK_Acompanhantes_Parentesco]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Acompanhantes_Parentesco]') AND parent_object_id = OBJECT_ID(N'[dbo].[Acompanhantes]'))
ALTER TABLE [dbo].[Acompanhantes]  WITH CHECK ADD  CONSTRAINT [FK_Acompanhantes_Parentesco] FOREIGN KEY([IdParentesco])
REFERENCES [dbo].[Parentesco] ([IdParentesco])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Acompanhantes_Parentesco]') AND parent_object_id = OBJECT_ID(N'[dbo].[Acompanhantes]'))
ALTER TABLE [dbo].[Acompanhantes] CHECK CONSTRAINT [FK_Acompanhantes_Parentesco]

/****** Object:  ForeignKey [FK_CIDADE_ADVOGADO]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CIDADE_ADVOGADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[Advogados]'))
ALTER TABLE [dbo].[Advogados]  WITH CHECK ADD  CONSTRAINT [FK_CIDADE_ADVOGADO] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidades] ([IdCidade])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CIDADE_ADVOGADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[Advogados]'))
ALTER TABLE [dbo].[Advogados] CHECK CONSTRAINT [FK_CIDADE_ADVOGADO]

/****** Object:  ForeignKey [FK_Associados_Cars]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associados_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[Associados]'))
ALTER TABLE [dbo].[Associados]  WITH CHECK ADD  CONSTRAINT [FK_Associados_Cars] FOREIGN KEY([IdCar])
REFERENCES [dbo].[Cars] ([IdCar])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associados_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[Associados]'))
ALTER TABLE [dbo].[Associados] CHECK CONSTRAINT [FK_Associados_Cars]

/****** Object:  ForeignKey [FK_Associados_EstadoCivil]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associados_EstadoCivil]') AND parent_object_id = OBJECT_ID(N'[dbo].[Associados]'))
ALTER TABLE [dbo].[Associados]  WITH CHECK ADD  CONSTRAINT [FK_Associados_EstadoCivil] FOREIGN KEY([IdEstadoCivil])
REFERENCES [dbo].[EstadoCivil] ([IdEstadoCivil])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associados_EstadoCivil]') AND parent_object_id = OBJECT_ID(N'[dbo].[Associados]'))
ALTER TABLE [dbo].[Associados] CHECK CONSTRAINT [FK_Associados_EstadoCivil]

/****** Object:  ForeignKey [FK_Associados_MotivoExclusao]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associados_MotivoExclusao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Associados]'))
ALTER TABLE [dbo].[Associados]  WITH NOCHECK ADD  CONSTRAINT [FK_Associados_MotivoExclusao] FOREIGN KEY([IdMotivo])
REFERENCES [dbo].[MotivoExclusao] ([IdMotivo])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associados_MotivoExclusao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Associados]'))
ALTER TABLE [dbo].[Associados] NOCHECK CONSTRAINT [FK_Associados_MotivoExclusao]

/****** Object:  ForeignKey [FK_Associados_TipoAssociado]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associados_TipoAssociado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Associados]'))
ALTER TABLE [dbo].[Associados]  WITH CHECK ADD  CONSTRAINT [FK_Associados_TipoAssociado] FOREIGN KEY([IdTipoAssociado])
REFERENCES [dbo].[TipoAssociado] ([IdTipoAssociado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associados_TipoAssociado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Associados]'))
ALTER TABLE [dbo].[Associados] CHECK CONSTRAINT [FK_Associados_TipoAssociado]

/****** Object:  ForeignKey [FK_AssociadosConferidos_Associados]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssociadosConferidos_Associados]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssociadosConferidos]'))
ALTER TABLE [dbo].[AssociadosConferidos]  WITH CHECK ADD  CONSTRAINT [FK_AssociadosConferidos_Associados] FOREIGN KEY([IdAssociado])
REFERENCES [dbo].[Associados] ([IdAssociado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssociadosConferidos_Associados]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssociadosConferidos]'))
ALTER TABLE [dbo].[AssociadosConferidos] CHECK CONSTRAINT [FK_AssociadosConferidos_Associados]

/****** Object:  ForeignKey [FK_AssociadosConferidos_Usuarios]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssociadosConferidos_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssociadosConferidos]'))
ALTER TABLE [dbo].[AssociadosConferidos]  WITH CHECK ADD  CONSTRAINT [FK_AssociadosConferidos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssociadosConferidos_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssociadosConferidos]'))
ALTER TABLE [dbo].[AssociadosConferidos] CHECK CONSTRAINT [FK_AssociadosConferidos_Usuarios]

/****** Object:  ForeignKey [Fk_Atendimento_Associado]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Fk_Atendimento_Associado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos]  WITH NOCHECK ADD  CONSTRAINT [Fk_Atendimento_Associado] FOREIGN KEY([IdAssociado])
REFERENCES [dbo].[Associados] ([IdAssociado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Fk_Atendimento_Associado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos] CHECK CONSTRAINT [Fk_Atendimento_Associado]

/****** Object:  ForeignKey [Fk_Atendimento_TipoAtendimento]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Fk_Atendimento_TipoAtendimento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [Fk_Atendimento_TipoAtendimento] FOREIGN KEY([IdTipoAtendimento])
REFERENCES [dbo].[TipoAtendimento] ([IdTipoAtendimento])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Fk_Atendimento_TipoAtendimento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos] CHECK CONSTRAINT [Fk_Atendimento_TipoAtendimento]

/****** Object:  ForeignKey [Fk_Atendimento_Usuario]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Fk_Atendimento_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [Fk_Atendimento_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Fk_Atendimento_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos] CHECK CONSTRAINT [Fk_Atendimento_Usuario]

/****** Object:  ForeignKey [FK_Atendimentos_Advogados]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_Advogados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimentos_Advogados] FOREIGN KEY([IdAdvogado])
REFERENCES [dbo].[Advogados] ([IdAdvogado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_Advogados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos] CHECK CONSTRAINT [FK_Atendimentos_Advogados]

/****** Object:  ForeignKey [FK_Atendimentos_ColoniaFerias]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_ColoniaFerias]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimentos_ColoniaFerias] FOREIGN KEY([IdColonia])
REFERENCES [dbo].[ColoniaFerias] ([IdColonia])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_ColoniaFerias]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos] CHECK CONSTRAINT [FK_Atendimentos_ColoniaFerias]

/****** Object:  ForeignKey [FK_Atendimentos_Faculdades]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_Faculdades]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimentos_Faculdades] FOREIGN KEY([IdFaculdade])
REFERENCES [dbo].[Faculdades] ([IdFaculdade])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_Faculdades]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos] CHECK CONSTRAINT [FK_Atendimentos_Faculdades]

/****** Object:  ForeignKey [FK_Atendimentos_InstituicaoMedica]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_InstituicaoMedica]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimentos_InstituicaoMedica] FOREIGN KEY([IdInstituicaoMedica])
REFERENCES [dbo].[InstituicaoMedica] ([IdInstituicao])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_InstituicaoMedica]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos] CHECK CONSTRAINT [FK_Atendimentos_InstituicaoMedica]

/****** Object:  ForeignKey [FK_Atendimentos_Medicos]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_Medicos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimentos_Medicos] FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medicos] ([IdMedico])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_Medicos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos] CHECK CONSTRAINT [FK_Atendimentos_Medicos]

/****** Object:  ForeignKey [FK_Atendimentos_Seguradoras]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_Seguradoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimentos_Seguradoras] FOREIGN KEY([IdSeguradora])
REFERENCES [dbo].[Seguradoras] ([IdSeguradora])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Atendimentos_Seguradoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Atendimentos]'))
ALTER TABLE [dbo].[Atendimentos] CHECK CONSTRAINT [FK_Atendimentos_Seguradoras]

/****** Object:  ForeignKey [FK_Cidades_Uf]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cidades_Uf]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cidades]'))
ALTER TABLE [dbo].[Cidades]  WITH CHECK ADD  CONSTRAINT [FK_Cidades_Uf] FOREIGN KEY([IdUf])
REFERENCES [dbo].[Uf] ([IdUf])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cidades_Uf]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cidades]'))
ALTER TABLE [dbo].[Cidades] CHECK CONSTRAINT [FK_Cidades_Uf]

/****** Object:  ForeignKey [FK_ColoniaFerias_Cidades]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ColoniaFerias_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[ColoniaFerias]'))
ALTER TABLE [dbo].[ColoniaFerias]  WITH CHECK ADD  CONSTRAINT [FK_ColoniaFerias_Cidades] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidades] ([IdCidade])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ColoniaFerias_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[ColoniaFerias]'))
ALTER TABLE [dbo].[ColoniaFerias] CHECK CONSTRAINT [FK_ColoniaFerias_Cidades]

/****** Object:  ForeignKey [FK_Contato_Associado]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contato_Associado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contato]'))
ALTER TABLE [dbo].[Contato]  WITH NOCHECK ADD  CONSTRAINT [FK_Contato_Associado] FOREIGN KEY([IdAssociado])
REFERENCES [dbo].[Associados] ([IdAssociado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contato_Associado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contato]'))
ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FK_Contato_Associado]

/****** Object:  ForeignKey [FK_Contato_TipoContato]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contato_TipoContato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contato]'))
ALTER TABLE [dbo].[Contato]  WITH CHECK ADD  CONSTRAINT [FK_Contato_TipoContato] FOREIGN KEY([IdTipoContato])
REFERENCES [dbo].[TipoContato] ([IdTipoContato])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contato_TipoContato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contato]'))
ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FK_Contato_TipoContato]

/****** Object:  ForeignKey [FK_Corretoras_Corretoras]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Corretoras_Corretoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Corretoras]'))
ALTER TABLE [dbo].[Corretoras]  WITH CHECK ADD  CONSTRAINT [FK_Corretoras_Corretoras] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidades] ([IdCidade])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Corretoras_Corretoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Corretoras]'))
ALTER TABLE [dbo].[Corretoras] CHECK CONSTRAINT [FK_Corretoras_Corretoras]

/****** Object:  ForeignKey [FK_Corretoras_Seguradoras]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Corretoras_Seguradoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Corretoras]'))
ALTER TABLE [dbo].[Corretoras]  WITH CHECK ADD  CONSTRAINT [FK_Corretoras_Seguradoras] FOREIGN KEY([IdSeguradora])
REFERENCES [dbo].[Seguradoras] ([IdSeguradora])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Corretoras_Seguradoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Corretoras]'))
ALTER TABLE [dbo].[Corretoras] CHECK CONSTRAINT [FK_Corretoras_Seguradoras]

/****** Object:  ForeignKey [fk_Advogados]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Advogados]') AND parent_object_id = OBJECT_ID(N'[dbo].[cz_advogado_area]'))
ALTER TABLE [dbo].[cz_advogado_area]  WITH CHECK ADD  CONSTRAINT [fk_Advogados] FOREIGN KEY([IdAdvogado])
REFERENCES [dbo].[Advogados] ([IdAdvogado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Advogados]') AND parent_object_id = OBJECT_ID(N'[dbo].[cz_advogado_area]'))
ALTER TABLE [dbo].[cz_advogado_area] CHECK CONSTRAINT [fk_Advogados]

/****** Object:  ForeignKey [fk_AreaAdvocacia]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_AreaAdvocacia]') AND parent_object_id = OBJECT_ID(N'[dbo].[cz_advogado_area]'))
ALTER TABLE [dbo].[cz_advogado_area]  WITH CHECK ADD  CONSTRAINT [fk_AreaAdvocacia] FOREIGN KEY([IdAreaAdvocacia])
REFERENCES [dbo].[AreaAdvocacia] ([IdAreaAdvocacia])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_AreaAdvocacia]') AND parent_object_id = OBJECT_ID(N'[dbo].[cz_advogado_area]'))
ALTER TABLE [dbo].[cz_advogado_area] CHECK CONSTRAINT [fk_AreaAdvocacia]

/****** Object:  ForeignKey [FK_Cz_Advogado_AreaAdvocacia_Advogados]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Advogado_AreaAdvocacia_Advogados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Advogado_AreaAdvocacia]'))
ALTER TABLE [dbo].[Cz_Advogado_AreaAdvocacia]  WITH CHECK ADD  CONSTRAINT [FK_Cz_Advogado_AreaAdvocacia_Advogados] FOREIGN KEY([IdAdvogado])
REFERENCES [dbo].[Advogados] ([IdAdvogado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Advogado_AreaAdvocacia_Advogados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Advogado_AreaAdvocacia]'))
ALTER TABLE [dbo].[Cz_Advogado_AreaAdvocacia] CHECK CONSTRAINT [FK_Cz_Advogado_AreaAdvocacia_Advogados]

/****** Object:  ForeignKey [FK_Cz_Advogado_AreaAdvocacia_AreaAdvocacia]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Advogado_AreaAdvocacia_AreaAdvocacia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Advogado_AreaAdvocacia]'))
ALTER TABLE [dbo].[Cz_Advogado_AreaAdvocacia]  WITH CHECK ADD  CONSTRAINT [FK_Cz_Advogado_AreaAdvocacia_AreaAdvocacia] FOREIGN KEY([IdAreaAdvocacia])
REFERENCES [dbo].[AreaAdvocacia] ([IdAreaAdvocacia])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Advogado_AreaAdvocacia_AreaAdvocacia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Advogado_AreaAdvocacia]'))
ALTER TABLE [dbo].[Cz_Advogado_AreaAdvocacia] CHECK CONSTRAINT [FK_Cz_Advogado_AreaAdvocacia_AreaAdvocacia]

/****** Object:  ForeignKey [FK_Cz_Associado_Colonia_Associados]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Colonia_Associados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Colonia]'))
ALTER TABLE [dbo].[Cz_Associado_Colonia]  WITH NOCHECK ADD  CONSTRAINT [FK_Cz_Associado_Colonia_Associados] FOREIGN KEY([IdAssociado])
REFERENCES [dbo].[Associados] ([IdAssociado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Colonia_Associados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Colonia]'))
ALTER TABLE [dbo].[Cz_Associado_Colonia] CHECK CONSTRAINT [FK_Cz_Associado_Colonia_Associados]

/****** Object:  ForeignKey [FK_Cz_Associado_Colonia_ColoniaFerias]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Colonia_ColoniaFerias]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Colonia]'))
ALTER TABLE [dbo].[Cz_Associado_Colonia]  WITH CHECK ADD  CONSTRAINT [FK_Cz_Associado_Colonia_ColoniaFerias] FOREIGN KEY([IdColonia])
REFERENCES [dbo].[ColoniaFerias] ([IdColonia])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Colonia_ColoniaFerias]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Colonia]'))
ALTER TABLE [dbo].[Cz_Associado_Colonia] CHECK CONSTRAINT [FK_Cz_Associado_Colonia_ColoniaFerias]

/****** Object:  ForeignKey [FK_Associado_Pensionista_IdAssociado]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associado_Pensionista_IdAssociado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Pensionista]'))
ALTER TABLE [dbo].[Cz_Associado_Pensionista]  WITH CHECK ADD  CONSTRAINT [FK_Associado_Pensionista_IdAssociado] FOREIGN KEY([IdAssociado])
REFERENCES [dbo].[Associados] ([IdAssociado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associado_Pensionista_IdAssociado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Pensionista]'))
ALTER TABLE [dbo].[Cz_Associado_Pensionista] CHECK CONSTRAINT [FK_Associado_Pensionista_IdAssociado]

/****** Object:  ForeignKey [FK_Associado_Pensionista_IdPensionista]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associado_Pensionista_IdPensionista]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Pensionista]'))
ALTER TABLE [dbo].[Cz_Associado_Pensionista]  WITH CHECK ADD  CONSTRAINT [FK_Associado_Pensionista_IdPensionista] FOREIGN KEY([IdPensionista])
REFERENCES [dbo].[Associados] ([IdAssociado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Associado_Pensionista_IdPensionista]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Pensionista]'))
ALTER TABLE [dbo].[Cz_Associado_Pensionista] CHECK CONSTRAINT [FK_Associado_Pensionista_IdPensionista]

/****** Object:  ForeignKey [FK_Cz_Associado_Pensionista_Cz_Associado_Pensionista]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Pensionista_Cz_Associado_Pensionista]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Pensionista]'))
ALTER TABLE [dbo].[Cz_Associado_Pensionista]  WITH CHECK ADD  CONSTRAINT [FK_Cz_Associado_Pensionista_Cz_Associado_Pensionista] FOREIGN KEY([IdAssociado], [IdPensionista], [IdDependente])
REFERENCES [dbo].[Cz_Associado_Pensionista] ([IdAssociado], [IdPensionista], [IdDependente])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Pensionista_Cz_Associado_Pensionista]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Pensionista]'))
ALTER TABLE [dbo].[Cz_Associado_Pensionista] CHECK CONSTRAINT [FK_Cz_Associado_Pensionista_Cz_Associado_Pensionista]

/****** Object:  ForeignKey [FK_Cz_Associado_Seguradora_Associados]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Seguradora_Associados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Seguradora]'))
ALTER TABLE [dbo].[Cz_Associado_Seguradora]  WITH NOCHECK ADD  CONSTRAINT [FK_Cz_Associado_Seguradora_Associados] FOREIGN KEY([IdAssociado])
REFERENCES [dbo].[Associados] ([IdAssociado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Seguradora_Associados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Seguradora]'))
ALTER TABLE [dbo].[Cz_Associado_Seguradora] CHECK CONSTRAINT [FK_Cz_Associado_Seguradora_Associados]

/****** Object:  ForeignKey [FK_Cz_Associado_Seguradora_Corretoras]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Seguradora_Corretoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Seguradora]'))
ALTER TABLE [dbo].[Cz_Associado_Seguradora]  WITH CHECK ADD  CONSTRAINT [FK_Cz_Associado_Seguradora_Corretoras] FOREIGN KEY([IdCorretora])
REFERENCES [dbo].[Corretoras] ([IdCorretora])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Seguradora_Corretoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Seguradora]'))
ALTER TABLE [dbo].[Cz_Associado_Seguradora] CHECK CONSTRAINT [FK_Cz_Associado_Seguradora_Corretoras]

/****** Object:  ForeignKey [FK_Cz_Associado_Seguradora_Seguradoras]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Seguradora_Seguradoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Seguradora]'))
ALTER TABLE [dbo].[Cz_Associado_Seguradora]  WITH CHECK ADD  CONSTRAINT [FK_Cz_Associado_Seguradora_Seguradoras] FOREIGN KEY([IdSeguradora])
REFERENCES [dbo].[Seguradoras] ([IdSeguradora])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Associado_Seguradora_Seguradoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Associado_Seguradora]'))
ALTER TABLE [dbo].[Cz_Associado_Seguradora] CHECK CONSTRAINT [FK_Cz_Associado_Seguradora_Seguradoras]

/****** Object:  ForeignKey [FK_CZ_Grupo_Usuario_Grupo]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CZ_Grupo_Usuario_Grupo]') AND parent_object_id = OBJECT_ID(N'[dbo].[cz_grupo_usuario]'))
ALTER TABLE [dbo].[cz_grupo_usuario]  WITH CHECK ADD  CONSTRAINT [FK_CZ_Grupo_Usuario_Grupo] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupos] ([IdGrupo])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CZ_Grupo_Usuario_Grupo]') AND parent_object_id = OBJECT_ID(N'[dbo].[cz_grupo_usuario]'))
ALTER TABLE [dbo].[cz_grupo_usuario] CHECK CONSTRAINT [FK_CZ_Grupo_Usuario_Grupo]

/****** Object:  ForeignKey [FK_CZ_Grupo_Usuario_Usuario]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CZ_Grupo_Usuario_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[cz_grupo_usuario]'))
ALTER TABLE [dbo].[cz_grupo_usuario]  WITH CHECK ADD  CONSTRAINT [FK_CZ_Grupo_Usuario_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CZ_Grupo_Usuario_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[cz_grupo_usuario]'))
ALTER TABLE [dbo].[cz_grupo_usuario] CHECK CONSTRAINT [FK_CZ_Grupo_Usuario_Usuario]

/****** Object:  ForeignKey [FK_Cz_Inadimplecia_Seguradora_Inadimplencia]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Inadimplecia_Seguradora_Inadimplencia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Inadimplecia_Seguradora]'))
ALTER TABLE [dbo].[Cz_Inadimplecia_Seguradora]  WITH NOCHECK ADD  CONSTRAINT [FK_Cz_Inadimplecia_Seguradora_Inadimplencia] FOREIGN KEY([IdInadimplencia])
REFERENCES [dbo].[Inadimplencia] ([IdInadimplencia])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Inadimplecia_Seguradora_Inadimplencia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Inadimplecia_Seguradora]'))
ALTER TABLE [dbo].[Cz_Inadimplecia_Seguradora] CHECK CONSTRAINT [FK_Cz_Inadimplecia_Seguradora_Inadimplencia]

/****** Object:  ForeignKey [FK_Cz_Inadimplecia_Seguradora_Seguradoras]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Inadimplecia_Seguradora_Seguradoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Inadimplecia_Seguradora]'))
ALTER TABLE [dbo].[Cz_Inadimplecia_Seguradora]  WITH CHECK ADD  CONSTRAINT [FK_Cz_Inadimplecia_Seguradora_Seguradoras] FOREIGN KEY([IdSeguradora])
REFERENCES [dbo].[Seguradoras] ([IdSeguradora])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Inadimplecia_Seguradora_Seguradoras]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Inadimplecia_Seguradora]'))
ALTER TABLE [dbo].[Cz_Inadimplecia_Seguradora] CHECK CONSTRAINT [FK_Cz_Inadimplecia_Seguradora_Seguradoras]

/****** Object:  ForeignKey [FK_Cz_Inadimplencia_Colonia_ColoniaFerias]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Inadimplencia_Colonia_ColoniaFerias]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Inadimplencia_Colonia]'))
ALTER TABLE [dbo].[Cz_Inadimplencia_Colonia]  WITH CHECK ADD  CONSTRAINT [FK_Cz_Inadimplencia_Colonia_ColoniaFerias] FOREIGN KEY([IdColonia])
REFERENCES [dbo].[ColoniaFerias] ([IdColonia])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Inadimplencia_Colonia_ColoniaFerias]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Inadimplencia_Colonia]'))
ALTER TABLE [dbo].[Cz_Inadimplencia_Colonia] CHECK CONSTRAINT [FK_Cz_Inadimplencia_Colonia_ColoniaFerias]

/****** Object:  ForeignKey [FK_Cz_Inadimplencia_Colonia_Inadimplencia]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Inadimplencia_Colonia_Inadimplencia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Inadimplencia_Colonia]'))
ALTER TABLE [dbo].[Cz_Inadimplencia_Colonia]  WITH CHECK ADD  CONSTRAINT [FK_Cz_Inadimplencia_Colonia_Inadimplencia] FOREIGN KEY([IdInadimplencia])
REFERENCES [dbo].[Inadimplencia] ([IdInadimplencia])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cz_Inadimplencia_Colonia_Inadimplencia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cz_Inadimplencia_Colonia]'))
ALTER TABLE [dbo].[Cz_Inadimplencia_Colonia] CHECK CONSTRAINT [FK_Cz_Inadimplencia_Colonia_Inadimplencia]

/****** Object:  ForeignKey [FK_Dependentes_Associados]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Dependentes_Associados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Dependentes]'))
ALTER TABLE [dbo].[Dependentes]  WITH NOCHECK ADD  CONSTRAINT [FK_Dependentes_Associados] FOREIGN KEY([IdAssociado])
REFERENCES [dbo].[Associados] ([IdAssociado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Dependentes_Associados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Dependentes]'))
ALTER TABLE [dbo].[Dependentes] CHECK CONSTRAINT [FK_Dependentes_Associados]

/****** Object:  ForeignKey [FK_Destinatarios_Cidades]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Destinatarios_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[Destinatarios]'))
ALTER TABLE [dbo].[Destinatarios]  WITH CHECK ADD  CONSTRAINT [FK_Destinatarios_Cidades] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidades] ([IdCidade])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Destinatarios_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[Destinatarios]'))
ALTER TABLE [dbo].[Destinatarios] CHECK CONSTRAINT [FK_Destinatarios_Cidades]

/****** Object:  ForeignKey [Fk_Destinatarios_MalaDireta]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Fk_Destinatarios_MalaDireta]') AND parent_object_id = OBJECT_ID(N'[dbo].[Destinatarios]'))
ALTER TABLE [dbo].[Destinatarios]  WITH CHECK ADD  CONSTRAINT [Fk_Destinatarios_MalaDireta] FOREIGN KEY([IdMalaDireta])
REFERENCES [dbo].[MalaDireta] ([IdMalaDireta])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Fk_Destinatarios_MalaDireta]') AND parent_object_id = OBJECT_ID(N'[dbo].[Destinatarios]'))
ALTER TABLE [dbo].[Destinatarios] CHECK CONSTRAINT [Fk_Destinatarios_MalaDireta]

/****** Object:  ForeignKey [fk_tipodocumento_documento]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_tipodocumento_documento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Documentos]'))
ALTER TABLE [dbo].[Documentos]  WITH CHECK ADD  CONSTRAINT [fk_tipodocumento_documento] FOREIGN KEY([IdTipoDocumento])
REFERENCES [dbo].[TipoDocumento] ([IdTipoDocumento])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_tipodocumento_documento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Documentos]'))
ALTER TABLE [dbo].[Documentos] CHECK CONSTRAINT [fk_tipodocumento_documento]

/****** Object:  ForeignKey [FK_EnderecoAssociado_Cidades]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EnderecoAssociado_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[EnderecoAssociado]'))
ALTER TABLE [dbo].[EnderecoAssociado]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoAssociado_Cidades] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidades] ([IdCidade])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EnderecoAssociado_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[EnderecoAssociado]'))
ALTER TABLE [dbo].[EnderecoAssociado] CHECK CONSTRAINT [FK_EnderecoAssociado_Cidades]

/****** Object:  ForeignKey [FK_Faculdades_Cidades]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Faculdades_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[Faculdades]'))
ALTER TABLE [dbo].[Faculdades]  WITH CHECK ADD  CONSTRAINT [FK_Faculdades_Cidades] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidades] ([IdCidade])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Faculdades_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[Faculdades]'))
ALTER TABLE [dbo].[Faculdades] CHECK CONSTRAINT [FK_Faculdades_Cidades]

/****** Object:  ForeignKey [FK_Inadimplencia_Associados]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Inadimplencia_Associados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Inadimplencia]'))
ALTER TABLE [dbo].[Inadimplencia]  WITH NOCHECK ADD  CONSTRAINT [FK_Inadimplencia_Associados] FOREIGN KEY([IdAssociado])
REFERENCES [dbo].[Associados] ([IdAssociado])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Inadimplencia_Associados]') AND parent_object_id = OBJECT_ID(N'[dbo].[Inadimplencia]'))
ALTER TABLE [dbo].[Inadimplencia] CHECK CONSTRAINT [FK_Inadimplencia_Associados]

/****** Object:  ForeignKey [FK_InstituicaoMedica_Cidades]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_InstituicaoMedica_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[InstituicaoMedica]'))
ALTER TABLE [dbo].[InstituicaoMedica]  WITH CHECK ADD  CONSTRAINT [FK_InstituicaoMedica_Cidades] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidades] ([IdCidade])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_InstituicaoMedica_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[InstituicaoMedica]'))
ALTER TABLE [dbo].[InstituicaoMedica] CHECK CONSTRAINT [FK_InstituicaoMedica_Cidades]

/****** Object:  ForeignKey [FK_LogRegistros_Usuarios]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LogRegistros_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogRegistros]'))
ALTER TABLE [dbo].[LogRegistros]  WITH CHECK ADD  CONSTRAINT [FK_LogRegistros_Usuarios] FOREIGN KEY([IdModulo])
REFERENCES [dbo].[Modulos] ([IdModulo])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LogRegistros_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogRegistros]'))
ALTER TABLE [dbo].[LogRegistros] CHECK CONSTRAINT [FK_LogRegistros_Usuarios]

/****** Object:  ForeignKey [FK_Medicos_Cidades]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Medicos_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[Medicos]'))
ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Medicos_Cidades] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidades] ([IdCidade])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Medicos_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[Medicos]'))
ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [FK_Medicos_Cidades]

/****** Object:  ForeignKey [FK_Menus_Menus]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Menus_Menus]') AND parent_object_id = OBJECT_ID(N'[dbo].[Menus]'))
ALTER TABLE [dbo].[Menus]  WITH CHECK ADD  CONSTRAINT [FK_Menus_Menus] FOREIGN KEY([IdMenuPai])
REFERENCES [dbo].[Menus] ([IdMenu])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Menus_Menus]') AND parent_object_id = OBJECT_ID(N'[dbo].[Menus]'))
ALTER TABLE [dbo].[Menus] CHECK CONSTRAINT [FK_Menus_Menus]

/****** Object:  ForeignKey [FK_Menus_Modulos]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Menus_Modulos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Menus]'))
ALTER TABLE [dbo].[Menus]  WITH CHECK ADD  CONSTRAINT [FK_Menus_Modulos] FOREIGN KEY([IdModulo])
REFERENCES [dbo].[Modulos] ([IdModulo])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Menus_Modulos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Menus]'))
ALTER TABLE [dbo].[Menus] CHECK CONSTRAINT [FK_Menus_Modulos]

/****** Object:  ForeignKey [FK_Permissoes_Grupos]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Permissoes_Grupos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permissoes]'))
ALTER TABLE [dbo].[Permissoes]  WITH CHECK ADD  CONSTRAINT [FK_Permissoes_Grupos] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupos] ([IdGrupo])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Permissoes_Grupos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permissoes]'))
ALTER TABLE [dbo].[Permissoes] CHECK CONSTRAINT [FK_Permissoes_Grupos]

/****** Object:  ForeignKey [FK_Permissoes_Modulos]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Permissoes_Modulos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permissoes]'))
ALTER TABLE [dbo].[Permissoes]  WITH CHECK ADD  CONSTRAINT [FK_Permissoes_Modulos] FOREIGN KEY([IdModulo])
REFERENCES [dbo].[Modulos] ([IdModulo])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Permissoes_Modulos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permissoes]'))
ALTER TABLE [dbo].[Permissoes] CHECK CONSTRAINT [FK_Permissoes_Modulos]

/****** Object:  ForeignKey [FK_Seguradoras_Cidades]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Seguradoras_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[Seguradoras]'))
ALTER TABLE [dbo].[Seguradoras]  WITH CHECK ADD  CONSTRAINT [FK_Seguradoras_Cidades] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidades] ([IdCidade])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Seguradoras_Cidades]') AND parent_object_id = OBJECT_ID(N'[dbo].[Seguradoras]'))
ALTER TABLE [dbo].[Seguradoras] CHECK CONSTRAINT [FK_Seguradoras_Cidades]

/****** Object:  ForeignKey [FK_Usuarios_Funcionarios]    Script Date: 05/19/2025 17:59:11 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuarios_Funcionarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuarios]'))
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Funcionarios] FOREIGN KEY([IdFuncionario])
REFERENCES [dbo].[Funcionarios] ([IdFuncionario])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuarios_Funcionarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuarios]'))
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Funcionarios]