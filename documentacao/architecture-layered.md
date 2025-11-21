# Arquitetura em Camadas - Estrutura do Projeto

## Visão Geral da Arquitetura

O projeto está organizado em uma arquitetura em camadas limpa (Clean Architecture), com separação clara de responsabilidades:

```
┌─────────────────────────────────────────────────────────────┐
│                    CAMADA WEBAPI                             │
│                 (Apresentação/API)                           │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐     │
│  │ Controllers  │  │  ViewModels  │  │   Mappers    │     │
│  │              │  │              │  │              │     │
│  │ AuthCtrl     │  │ LoginRequest │  │ViewModel     │     │
│  │ UserCtrl     │  │ UserViewModel│  │ Mapper       │     │
│  └──────┬───────┘  └──────────────┘  └──────┬───────┘     │
│         │                                     │              │
│         └────────────── Chama ────────────────┘             │
└─────────────────────────┬───────────────────────────────────┘
                          │ Converte ViewModels → Models
                          ↓
┌─────────────────────────────────────────────────────────────┐
│                 CAMADA APPLICATION                           │
│                 (Lógica de Negócio)                          │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐     │
│  │  Services    │  │    Models    │  │   Mappers    │     │
│  │              │  │              │  │              │     │
│  │ AuthAppSvc   │  │ UserModel    │  │ UserMapper   │     │
│  │ UserAppSvc   │  │ LoginModel   │  │              │     │
│  └──────┬───────┘  └──────────────┘  └──────┬───────┘     │
│         │                                     │              │
│         └────────────── Chama ────────────────┘             │
└─────────────────────────┬───────────────────────────────────┘
                          │ Converte Models → Entities
                          ↓
┌─────────────────────────────────────────────────────────────┐
│                 CAMADA DATAACCESS                            │
│                 (Acesso a Dados)                             │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐     │
│  │ Repositories │  │   Entities   │  │   DbContext  │     │
│  │              │  │              │  │              │     │
│  │ IBaseRepo<T> │  │   Usuario    │  │ AfpcespDb    │     │
│  │              │  │ Funcionario  │  │   Context    │     │
│  └──────┬───────┘  └──────────────┘  └──────────────┘     │
│         │                                                    │
│         └───────────────── Acessa ────────────────────────► │
└─────────────────────────────────────────────────────────────┘
                          │
                          ↓
                   ┌──────────────┐
                   │  SQL Server  │
                   │   Database   │
                   └──────────────┘
```

## Estrutura de Diretórios

```
afpcesp/
├── afpcesp.backoffice.webapi/        # Camada de Apresentação
│   ├── Controller/
│   │   ├── AuthController.cs         → Usa IAuthApplicationService
│   │   └── UserController.cs         → Usa IUserApplicationService
│   ├── ViewModel/                    → DTOs da API
│   │   ├── LoginRequest.cs
│   │   ├── LoginResponse.cs
│   │   ├── UserViewModel.cs
│   │   ├── CreateUserRequest.cs
│   │   └── UpdateUserRequest.cs
│   ├── Mappers/
│   │   └── ViewModelMapper.cs        → ViewModel ↔ Model
│   ├── Configuration/
│   │   └── JwtSettings.cs
│   └── Program.cs                    → Configuração e DI
│
├── afpcesp.application/               # Camada de Aplicação
│   ├── Services/
│   │   ├── IAuthApplicationService.cs
│   │   ├── AuthApplicationService.cs  → Gera JWT, valida login
│   │   ├── IUserApplicationService.cs
│   │   └── UserApplicationService.cs  → CRUD de usuários
│   ├── Models/                        → Modelos de domínio
│   │   ├── UserModel.cs
│   │   ├── CreateUserModel.cs
│   │   ├── UpdateUserModel.cs
│   │   ├── LoginModel.cs
│   │   └── AuthResponseModel.cs
│   └── Mappers/
│       └── UserMapper.cs              → Model ↔ Entity
│
└── afpcesp.dataaccess/                # Camada de Dados
    ├── repository/
    │   └── IBaseRepository.cs         → Interface genérica
    └── models/                        → Entidades EF Core
        ├── Usuario.cs
        ├── Funcionario.cs
        └── ...
```

## Fluxo de Dados

### Exemplo: Criar Usuário

```
1. Cliente HTTP
   POST /api/user
   Body: { "username": "joao", "password": "123456" }
   ↓
2. UserController.CreateUser(CreateUserRequest)
   ↓
3. ViewModelMapper.ToCreateModel()
   CreateUserRequest → CreateUserModel
   ↓
4. IUserApplicationService.CreateUserAsync(CreateUserModel)
   ↓
5. UserMapper.ToEntity()
   CreateUserModel → Usuario (entity)
   ↓
6. IBaseRepository<Usuario>.AddAsync(Usuario)
   ↓
7. DbContext.SaveChanges()
   ↓
8. Database (SQL Server)
   ↓
9. Usuario (entity retornado)
   ↓
10. UserMapper.ToModel()
    Usuario → UserModel
    ↓
11. ViewModelMapper.ToViewModel()
    UserModel → UserViewModel
    ↓
12. Response 201 Created
    Body: { "id": 1, "username": "joao" }
```

## Responsabilidades de Cada Camada

### 1. WebApi (Apresentação)
**Responsabilidades:**
- Receber requisições HTTP
- Validar dados de entrada (Data Annotations)
- Converter ViewModels para Models (usando Mappers)
- Chamar serviços da camada Application
- Converter Models para ViewModels
- Retornar responses HTTP

**O que NÃO faz:**
- ❌ Acesso direto ao banco de dados
- ❌ Lógica de negócio
- ❌ Manipulação de entidades do banco

**Arquivos principais:**
```csharp
// Controller
[HttpPost]
public async Task<ActionResult<UserViewModel>> CreateUser(CreateUserRequest request)
{
    // 1. Converte ViewModel → Model
    var model = ViewModelMapper.ToCreateModel(request);
    
    // 2. Chama serviço da Application
    var created = await _userService.CreateUserAsync(model);
    
    // 3. Converte Model → ViewModel
    var viewModel = ViewModelMapper.ToViewModel(created);
    
    return CreatedAtAction(nameof(GetUserById), new { id = viewModel.Id }, viewModel);
}
```

### 2. Application (Lógica de Negócio)
**Responsabilidades:**
- Implementar regras de negócio
- Orquestrar operações complexas
- Converter Models para Entities (usando Mappers)
- Chamar repositories da camada DataAccess
- Logging de operações
- Tratamento de erros de negócio

**O que NÃO faz:**
- ❌ Conhecer detalhes de HTTP/Controllers
- ❌ Conhecer ViewModels
- ❌ Implementar queries SQL diretamente

**Arquivos principais:**
```csharp
// Service
public class UserApplicationService : IUserApplicationService
{
    private readonly IBaseRepository<Usuario> _repository;
    
    public async Task<UserModel> CreateUserAsync(CreateUserModel model)
    {
        // 1. Valida regras de negócio (se necessário)
        
        // 2. Converte Model → Entity
        var entity = UserMapper.ToEntity(model);
        
        // 3. Chama repository
        var created = await _repository.AddAsync(entity);
        
        // 4. Converte Entity → Model
        return UserMapper.ToModel(created);
    }
}
```

### 3. DataAccess (Acesso a Dados)
**Responsabilidades:**
- Acesso ao banco de dados
- Queries e comandos SQL
- Mapeamento de entidades (EF Core)
- Transações de banco de dados

**O que NÃO faz:**
- ❌ Lógica de negócio
- ❌ Conhecer Models da Application
- ❌ Conhecer ViewModels da WebApi

**Arquivos principais:**
```csharp
// Repository
public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
```

## Mapeadores (Mappers)

### ViewModelMapper (WebApi → Application)
```csharp
// afpcesp.webapi/Mappers/ViewModelMapper.cs
public static class ViewModelMapper
{
    // ViewModel → Model
    public static CreateUserModel ToCreateModel(CreateUserRequest request)
    {
        return new CreateUserModel
        {
            Username = request.Username,
            Password = request.Password
        };
    }
    
    // Model → ViewModel
    public static UserViewModel ToViewModel(UserModel model)
    {
        return new UserViewModel
        {
            Id = model.Id,
            Username = model.Username
        };
    }
}
```

### UserMapper (Application → DataAccess)
```csharp
// afpcesp.application/Mappers/UserMapper.cs
public static class UserMapper
{
    // Model → Entity
    public static Usuario ToEntity(CreateUserModel model)
    {
        return new Usuario
        {
            DsLogin = model.Username,
            DsSenha = model.Password,
            FlAtivo = true
        };
    }
    
    // Entity → Model
    public static UserModel ToModel(Usuario entity)
    {
        return new UserModel
        {
            Id = entity.IdUsuario,
            Username = entity.DsLogin,
            Password = entity.DsSenha,
            IsActive = entity.FlAtivo ?? true
        };
    }
}
```

## Injeção de Dependências

### Program.cs (WebApi)
```csharp
// Camada DataAccess
builder.Services.AddDataAccessServices(); // Registra DbContext e Repositories

// Camada Application
builder.Services.AddScoped<IAuthApplicationService, AuthApplicationService>();
builder.Services.AddScoped<IUserApplicationService, UserApplicationService>();

// Camada WebApi
// Controllers são registrados automaticamente com AddControllers()
```

## Benefícios da Arquitetura

### ✅ Separação de Responsabilidades
- Cada camada tem uma função clara
- Fácil de entender e manter
- Código mais organizado

### ✅ Testabilidade
- Camadas independentes podem ser testadas isoladamente
- Uso de interfaces facilita mocks
- Testes unitários mais simples

### ✅ Flexibilidade
- Mudanças em uma camada não afetam outras
- Pode trocar banco de dados sem afetar Application/WebApi
- Pode trocar API (REST → GraphQL) sem afetar Application/DataAccess

### ✅ Reutilização
- Serviços da Application podem ser usados por múltiplas APIs
- Repositories podem ser compartilhados entre serviços
- Mappers centralizados e reutilizáveis

### ✅ Manutenibilidade
- Código mais fácil de navegar
- Mudanças isoladas em camadas específicas
- Menos acoplamento entre componentes

## Convenções de Nomenclatura

### ViewModels (WebApi)
- `{Ação}{Entidade}Request` - ex: `CreateUserRequest`
- `{Entidade}ViewModel` - ex: `UserViewModel`
- `{Ação}Response` - ex: `LoginResponse`

### Models (Application)
- `{Entidade}Model` - ex: `UserModel`
- `{Ação}{Entidade}Model` - ex: `CreateUserModel`

### Entities (DataAccess)
- Nome da tabela no banco - ex: `Usuario`, `Funcionario`
- Sem sufixo (são as entidades do banco)

### Services
- `I{Entidade}ApplicationService` - Interface
- `{Entidade}ApplicationService` - Implementação

### Mappers
- `{Origem}Mapper` - ex: `ViewModelMapper`, `UserMapper`
- Métodos estáticos para conversão

## Checklist para Novos Endpoints

1. ✅ Criar ViewModels em `webapi/ViewModel/`
2. ✅ Criar Models em `application/Models/` (se necessário)
3. ✅ Adicionar métodos de mapeamento em `webapi/Mappers/ViewModelMapper`
4. ✅ Adicionar métodos de mapeamento em `application/Mappers/{Entity}Mapper`
5. ✅ Criar/Atualizar interface de serviço em `application/Services/I*Service`
6. ✅ Implementar serviço em `application/Services/*Service`
7. ✅ Criar endpoint no controller em `webapi/Controller/`
8. ✅ Registrar serviço no `Program.cs` (se novo)
9. ✅ Testar endpoint no Swagger
10. ✅ Fazer build e verificar erros

## Exemplo Completo - Adicionar Novo Endpoint

### 1. Criar ViewModels
```csharp
// webapi/ViewModel/CreateProductRequest.cs
public class CreateProductRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### 2. Criar Models
```csharp
// application/Models/ProductModel.cs
public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### 3. Criar Mappers
```csharp
// webapi/Mappers/ViewModelMapper.cs
public static ProductModel ToProductModel(CreateProductRequest request)
{
    return new ProductModel { Name = request.Name, Price = request.Price };
}

// application/Mappers/ProductMapper.cs
public static Produto ToEntity(ProductModel model)
{
    return new Produto { DsNome = model.Name, VlPreco = model.Price };
}
```

### 4. Criar/Atualizar Service
```csharp
// application/Services/IProductApplicationService.cs
public interface IProductApplicationService
{
    Task<ProductModel> CreateAsync(ProductModel model);
}

// application/Services/ProductApplicationService.cs
public class ProductApplicationService : IProductApplicationService
{
    private readonly IBaseRepository<Produto> _repository;
    
    public async Task<ProductModel> CreateAsync(ProductModel model)
    {
        var entity = ProductMapper.ToEntity(model);
        var created = await _repository.AddAsync(entity);
        return ProductMapper.ToModel(created);
    }
}
```

### 5. Criar Controller
```csharp
// webapi/Controller/ProductController.cs
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductApplicationService _service;
    
    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> Create(CreateProductRequest request)
    {
        var model = ViewModelMapper.ToProductModel(request);
        var created = await _service.CreateAsync(model);
        var viewModel = ViewModelMapper.ToProductViewModel(created);
        return CreatedAtAction(nameof(GetById), new { id = viewModel.Id }, viewModel);
    }
}
```

### 6. Registrar no Program.cs
```csharp
builder.Services.AddScoped<IProductApplicationService, ProductApplicationService>();
```

## Resumo

✅ **WebApi** → Recebe ViewModels, converte para Models, chama Application  
✅ **Application** → Recebe Models, aplica lógica, converte para Entities, chama DataAccess  
✅ **DataAccess** → Recebe Entities, persiste no banco de dados  

✅ **Fluxo completo:**  
`ViewModel → Model → Entity → Database → Entity → Model → ViewModel`

---

**Status:** ✅ Arquitetura Implementada e Funcional  
**Build:** ✅ Compilação com sucesso  
**Organização:** ✅ Camadas bem definidas  
