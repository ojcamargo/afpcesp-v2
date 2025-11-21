# Autorização Avançada com Políticas (Policies)

## Introdução

Além do uso básico de `[Authorize]` e `[Authorize(Roles = "Admin")]`, você pode criar políticas de autorização personalizadas para cenários mais complexos.

## Configuração de Políticas no Program.cs

Adicione as seguintes configurações após `builder.Services.AddAuthentication()`:

```csharp
using afpcesp.backoffice.webapi.Authorization;

// ... código existente ...

// Adiciona autorização com políticas personalizadas
builder.Services.AddAuthorization(options =>
{
    // Política baseada em role
    options.AddPolicy(Policies.RequireAdminRole, policy =>
        policy.RequireRole("Admin"));

    // Política baseada em múltiplas roles
    options.AddPolicy(Policies.RequireManagerRole, policy =>
        policy.RequireRole("Admin", "Manager"));

    // Política com requirement customizado (idade mínima)
    options.AddPolicy(Policies.RequireMinimumAge, policy =>
        policy.Requirements.Add(new MinimumAgeRequirement(18)));

    // Política com permissão específica
    options.AddPolicy(Policies.CanViewSensitiveData, policy =>
        policy.Requirements.Add(new PermissionRequirement("ViewSensitiveData")));

    // Política combinando múltiplos requisitos
    options.AddPolicy("FullAccess", policy =>
    {
        policy.RequireRole("Admin");
        policy.RequireClaim("Department", "IT");
        policy.Requirements.Add(new MinimumAgeRequirement(21));
    });
});

// Registrar handlers de autorização
builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
```

## Usando Políticas nos Controllers

### Exemplo 1: Política Simples de Role

```csharp
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    [HttpGet("dashboard")]
    [Authorize(Policy = Policies.RequireAdminRole)]
    public ActionResult GetDashboard()
    {
        return Ok(new { message = "Dashboard administrativo" });
    }
}
```

### Exemplo 2: Política com Múltiplas Roles

```csharp
[HttpGet("reports")]
[Authorize(Policy = Policies.RequireManagerRole)]
public ActionResult GetReports()
{
    // Acessível para Admin OU Manager
    return Ok(new { message = "Relatórios gerenciais" });
}
```

### Exemplo 3: Política com Requirement Customizado

```csharp
[HttpGet("adult-content")]
[Authorize(Policy = Policies.RequireMinimumAge)]
public ActionResult GetAdultContent()
{
    // Requer idade mínima de 18 anos
    return Ok(new { message = "Conteúdo para maiores de 18 anos" });
}
```

### Exemplo 4: Política com Permissões Específicas

```csharp
[HttpGet("sensitive-data")]
[Authorize(Policy = Policies.CanViewSensitiveData)]
public ActionResult GetSensitiveData()
{
    // Requer permissão específica ViewSensitiveData
    return Ok(new { message = "Dados sensíveis" });
}
```

## Adicionando Claims Personalizadas no Token

Modifique o `AuthService.GenerateJwtToken()` para incluir claims adicionais:

```csharp
public string GenerateJwtToken(string username, string? email, List<string> roles)
{
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, username),
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        
        // Claims personalizadas
        new Claim("DateOfBirth", "1990-01-01"), // Para MinimumAgeRequirement
        new Claim("Department", "IT"),
        new Claim("Permission", "ViewSensitiveData"),
        new Claim("Permission", "EditUsers"), // Pode ter múltiplas permissões
        new Claim("EmployeeId", "12345")
    };

    if (!string.IsNullOrEmpty(email))
    {
        claims.Add(new Claim(ClaimTypes.Email, email));
    }

    foreach (var role in roles)
    {
        claims.Add(new Claim(ClaimTypes.Role, role));
    }

    var token = new JwtSecurityToken(
        issuer: _jwtSettings.Issuer,
        audience: _jwtSettings.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}
```

## Autorização Imperativa (No Código)

Além dos atributos, você pode verificar autorização programaticamente:

```csharp
[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;

    public DocumentsController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult> GetDocument(int id)
    {
        // Busca o documento
        var document = GetDocumentById(id); // Seu método de busca

        // Verifica autorização programaticamente
        var authResult = await _authorizationService.AuthorizeAsync(
            User, 
            document, 
            Policies.CanViewSensitiveData
        );

        if (!authResult.Succeeded)
        {
            return Forbid(); // 403 Forbidden
        }

        return Ok(document);
    }
}
```

## Autorização Baseada em Recursos

Para autorização baseada em recursos específicos, crie um requirement:

```csharp
public class DocumentAuthorizationHandler : 
    AuthorizationHandler<PermissionRequirement, Document>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement,
        Document document)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        // Verifica se o usuário é o dono do documento
        if (document.OwnerId == userId)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        // Ou se é admin
        if (context.User.IsInRole("Admin"))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }
}
```

## Políticas Combinadas

Você pode combinar múltiplos requisitos:

```csharp
options.AddPolicy("SuperAdmin", policy =>
{
    policy.RequireRole("Admin");
    policy.RequireClaim("Department", "IT");
    policy.RequireClaim("ClearanceLevel", "5");
    policy.Requirements.Add(new MinimumAgeRequirement(25));
});
```

## Passando Contexto do Usuário Autenticado

### Opção 1: Usando User do ControllerBase

```csharp
[HttpGet("my-data")]
[Authorize]
public ActionResult GetMyData()
{
    var username = User.Identity?.Name;
    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var email = User.FindFirst(ClaimTypes.Email)?.Value;
    
    // Use essas informações para filtrar dados
    var data = _service.GetDataForUser(userId);
    
    return Ok(data);
}
```

### Opção 2: Criando um Serviço de Contexto do Usuário

```csharp
public interface ICurrentUserService
{
    string? UserId { get; }
    string? Username { get; }
    string? Email { get; }
    bool IsAuthenticated { get; }
    bool IsInRole(string role);
    string? GetClaim(string claimType);
}

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId => 
        _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    public string? Username => 
        _httpContextAccessor.HttpContext?.User?.Identity?.Name;

    public string? Email => 
        _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

    public bool IsAuthenticated => 
        _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    public bool IsInRole(string role) => 
        _httpContextAccessor.HttpContext?.User?.IsInRole(role) ?? false;

    public string? GetClaim(string claimType) => 
        _httpContextAccessor.HttpContext?.User?.FindFirst(claimType)?.Value;
}
```

**Registre no Program.cs:**

```csharp
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
```

**Use em qualquer serviço:**

```csharp
public class UserService : IUserService
{
    private readonly ICurrentUserService _currentUser;

    public UserService(ICurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }

    public async Task<User> GetCurrentUserProfile()
    {
        if (!_currentUser.IsAuthenticated)
        {
            throw new UnauthorizedException();
        }

        var userId = _currentUser.UserId;
        return await _repository.GetByIdAsync(userId);
    }
}
```

## Exemplo Completo de Controller com Diferentes Níveis de Autorização

```csharp
[ApiController]
[Route("api/[controller]")]
[Authorize] // Todos os endpoints requerem autenticação
public class UsersController : ControllerBase
{
    private readonly ICurrentUserService _currentUser;

    public UsersController(ICurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }

    // Qualquer usuário autenticado pode ver seu próprio perfil
    [HttpGet("me")]
    public ActionResult GetMyProfile()
    {
        return Ok(new
        {
            userId = _currentUser.UserId,
            username = _currentUser.Username,
            email = _currentUser.Email
        });
    }

    // Apenas usuários com role "Admin" ou "Manager"
    [HttpGet]
    [Authorize(Policy = Policies.RequireManagerRole)]
    public ActionResult GetAllUsers()
    {
        // Lista todos os usuários
        return Ok(/* ... */);
    }

    // Apenas Admin pode criar usuários
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public ActionResult CreateUser([FromBody] CreateUserRequest request)
    {
        return Ok(/* ... */);
    }

    // Qualquer usuário pode atualizar seus próprios dados
    // Admin pode atualizar dados de qualquer usuário
    [HttpPut("{id}")]
    public ActionResult UpdateUser(string id, [FromBody] UpdateUserRequest request)
    {
        var currentUserId = _currentUser.UserId;
        var isAdmin = _currentUser.IsInRole("Admin");

        if (id != currentUserId && !isAdmin)
        {
            return Forbid(); // 403 Forbidden
        }

        // Atualiza o usuário
        return Ok(/* ... */);
    }

    // Apenas Admin pode deletar usuários
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public ActionResult DeleteUser(string id)
    {
        return Ok(/* ... */);
    }
}
```

## Testando Políticas

### No Swagger

1. Faça login e obtenha o token
2. Configure o token no Swagger
3. Tente acessar endpoints com diferentes políticas
4. Observe os códigos de resposta:
   - 200: Sucesso
   - 401: Não autenticado (token ausente/inválido)
   - 403: Não autorizado (autenticado mas sem permissão)

### Com cURL

```bash
# Login
TOKEN=$(curl -X POST http://localhost:5000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"username":"admin","password":"123456"}' \
  | jq -r '.token')

# Acessar endpoint protegido por política
curl -X GET http://localhost:5000/api/admin/dashboard \
  -H "Authorization: Bearer $TOKEN"
```

## Boas Práticas

1. **Use políticas para lógica complexa**: Não coloque lógica de autorização nos controllers
2. **Centralize definições**: Mantenha nomes de políticas em constantes
3. **Teste suas políticas**: Crie testes unitários para handlers de autorização
4. **Documente requisitos**: Deixe claro o que cada política requer
5. **Seja específico**: Crie políticas granulares em vez de genéricas
6. **Evite hardcoding**: Use configuração para valores que podem mudar

## Resumo

- `[Authorize]` - Requer autenticação
- `[Authorize(Roles = "Admin")]` - Requer role específica
- `[Authorize(Policy = "PolicyName")]` - Requer política personalizada
- `[AllowAnonymous]` - Permite acesso público
- `IAuthorizationService` - Verificação programática
- `ICurrentUserService` - Acesso ao contexto do usuário em serviços
