# Estrutura de ViewModels - Organização de Modelos da API

## Objetivo

Separar os modelos de dados utilizados pelos controllers (ViewModels) das entidades do banco de dados, seguindo o princípio de separação de responsabilidades.

## Estrutura de Pastas

```
afpcesp.backoffice.webapi/
├── ViewModel/                    # Todos os modelos usados pelos controllers
│   ├── LoginRequest.cs          # Request para autenticação
│   ├── LoginResponse.cs         # Response com token JWT
│   ├── UserViewModel.cs         # Representação de usuário na API
│   ├── CreateUserRequest.cs     # Request para criar usuário
│   ├── UpdateUserRequest.cs     # Request para atualizar usuário
│   └── CreateResourceRequest.cs # Request para criar recurso
├── Controller/                   # Controllers da API
├── Services/                     # Serviços da camada API
└── Configuration/                # Configurações
```

## ViewModels Criados

### Autenticação

#### LoginRequest
```csharp
public class LoginRequest
{
    [Required(ErrorMessage = "O nome de usuário é obrigatório")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Password { get; set; }
}
```

#### LoginResponse
```csharp
public class LoginResponse
{
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string Username { get; set; }
    public string? Email { get; set; }
    public List<string> Roles { get; set; }
}
```

### Usuários

#### UserViewModel
```csharp
public class UserViewModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string? Name { get; set; }
}
```

#### CreateUserRequest
```csharp
public class CreateUserRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string? Name { get; set; }
    public string Password { get; set; }
}
```

#### UpdateUserRequest
```csharp
public class UpdateUserRequest
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string? Name { get; set; }
}
```

### Recursos

#### CreateResourceRequest
```csharp
public class CreateResourceRequest
{
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public string? Description { get; set; }
}
```

## Camada de Serviço - UserApiService

O `UserApiService` faz o mapeamento entre ViewModels e entidades do banco de dados:

```csharp
public class UserApiService : IUserApiService
{
    private readonly IBaseRepository<Usuario> _userRepository;
    
    // Métodos que recebem ViewModels e convertem para entidades
    public async Task<UserViewModel> CreateUserAsync(CreateUserRequest request)
    {
        var usuario = new Usuario
        {
            DsLogin = request.Username,
            DsSenha = request.Password, // TODO: Hash
            FlAtivo = true
        };
        
        var created = await _userRepository.AddAsync(usuario);
        return MapToViewModel(created);
    }
    
    private UserViewModel MapToViewModel(Usuario usuario)
    {
        return new UserViewModel
        {
            Id = usuario.IdUsuario,
            Username = usuario.DsLogin,
            Email = string.Empty,
            Name = usuario.DsLogin
        };
    }
}
```

## Uso nos Controllers

### Exemplo: AuthController

```csharp
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
    {
        var response = await _authService.AuthenticateAsync(loginRequest);
        
        if (response == null)
        {
            return Unauthorized(new { message = "Usuário ou senha inválidos" });
        }
        
        return Ok(response);
    }
}
```

### Exemplo: UserController

```csharp
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserApiService _userService;
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UserViewModel>> CreateUser(CreateUserRequest request)
    {
        var user = await _userService.CreateUserAsync(request);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserRequest request)
    {
        if (id != request.Id)
            return BadRequest();
            
        var result = await _userService.UpdateUserAsync(request);
        return result ? NoContent() : NotFound();
    }
}
```

## Benefícios da Organização

### 1. Separação de Responsabilidades
- **ViewModels**: Representam dados da API (requisições/respostas)
- **Entidades**: Representam dados do banco de dados
- **Serviços**: Fazem o mapeamento entre os dois

### 2. Flexibilidade
- Alterações no banco de dados não afetam diretamente a API
- API pode expor apenas os campos necessários
- Facilita versionamento da API

### 3. Segurança
- Evita exposição de campos sensíveis do banco
- Controle preciso sobre dados recebidos/enviados
- Validação centralizada

### 4. Manutenibilidade
- Código mais organizado e fácil de entender
- Testes mais simples
- Documentação mais clara

## Validação de Dados

Use Data Annotations nos ViewModels:

```csharp
public class CreateUserRequest
{
    [Required(ErrorMessage = "Username é obrigatório")]
    [StringLength(50, MinimumLength = 3)]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }
}
```

## Swagger/OpenAPI

Os ViewModels são automaticamente documentados no Swagger:

```csharp
/// <summary>
/// ViewModel para criação de usuário.
/// </summary>
public class CreateUserRequest
{
    /// <summary>
    /// Nome de usuário (3-50 caracteres).
    /// </summary>
    public string Username { get; set; }
}
```

## Mapeamento Automático (Opcional)

Para projetos maiores, considere usar AutoMapper:

```bash
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

```csharp
// Configuração
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Usuario, UserViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdUsuario))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.DsLogin));
            
        CreateMap<CreateUserRequest, Usuario>()
            .ForMember(dest => dest.DsLogin, opt => opt.MapFrom(src => src.Username));
    }
}

// Uso
private readonly IMapper _mapper;

public UserViewModel MapToViewModel(Usuario usuario)
{
    return _mapper.Map<UserViewModel>(usuario);
}
```

## Convenções de Nomenclatura

- **Request**: Modelos de entrada (CreateXRequest, UpdateXRequest)
- **Response**: Modelos de saída específicos (LoginResponse)
- **ViewModel**: Modelos gerais de representação (UserViewModel)

## Checklist para Novos Endpoints

1. ✅ Criar ViewModels na pasta `ViewModel/`
2. ✅ Adicionar validações (Data Annotations)
3. ✅ Documentar com XML comments
4. ✅ Criar métodos de mapeamento no serviço
5. ✅ Usar ViewModels nos controllers
6. ✅ Testar no Swagger

## Exemplo Completo de Novo Endpoint

### 1. Criar ViewModel
```csharp
// ViewModel/CreateProductRequest.cs
public class CreateProductRequest
{
    [Required]
    public string Name { get; set; }
    
    public decimal Price { get; set; }
}
```

### 2. Criar Serviço
```csharp
public interface IProductApiService
{
    Task<ProductViewModel> CreateAsync(CreateProductRequest request);
}

public class ProductApiService : IProductApiService
{
    public async Task<ProductViewModel> CreateAsync(CreateProductRequest request)
    {
        var product = new Product
        {
            DsNome = request.Name,
            VlPreco = request.Price
        };
        
        var created = await _repository.AddAsync(product);
        return MapToViewModel(created);
    }
}
```

### 3. Usar no Controller
```csharp
[HttpPost]
[Authorize(Roles = "Admin")]
public async Task<ActionResult<ProductViewModel>> CreateProduct(CreateProductRequest request)
{
    var product = await _productService.CreateAsync(request);
    return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
}
```

## Resumo

✅ **Todos os modelos dos controllers** estão na pasta `ViewModel/`  
✅ **Separação clara** entre ViewModels e entidades do banco  
✅ **Serviços fazem o mapeamento** entre as camadas  
✅ **Controllers recebem e retornam apenas ViewModels**  
✅ **Código mais organizado e manutenível**  

---

**Status:** ✅ Implementado e Funcional  
**Build:** ✅ Sem erros  
