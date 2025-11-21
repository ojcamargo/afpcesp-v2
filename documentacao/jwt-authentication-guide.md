# Autenticação JWT - Guia de Uso

## Visão Geral

Este documento explica como usar a autenticação JWT implementada na API da AFPCESP.

## Arquitetura Implementada

### Componentes Criados:

1. **Models**
   - `LoginRequest.cs` - Modelo para requisição de login
   - `LoginResponse.cs` - Modelo para resposta com token

2. **Configuration**
   - `JwtSettings.cs` - Configurações do JWT

3. **Services**
   - `IAuthService.cs` - Interface do serviço de autenticação
   - `AuthService.cs` - Implementação com geração de tokens JWT

4. **Controllers**
   - `AuthController.cs` - Endpoints de autenticação
   - `UserController.cs` - Endpoints protegidos com [Authorize]

## Como Funciona

### 1. Configuração (appsettings.json)

```json
{
  "JwtSettings": {
    "SecretKey": "sua-chave-secreta-super-segura-com-pelo-menos-32-caracteres",
    "Issuer": "afpcesp.backoffice.api",
    "Audience": "afpcesp.backoffice.client",
    "ExpirationMinutes": 60
  }
}
```

### 2. Fluxo de Autenticação

1. Cliente faz POST para `/api/auth/login` com credenciais
2. API valida credenciais
3. Se válidas, gera token JWT com claims do usuário
4. Retorna token e informações do usuário
5. Cliente usa o token em requisições subsequentes

### 3. Como Usar o Token

Adicione o token no header `Authorization` de todas as requisições:

```
Authorization: Bearer {seu-token-jwt}
```

## Endpoints Disponíveis

### 🔓 Autenticação (Públicos)

#### POST /api/auth/login
Autentica um usuário e retorna um token JWT.

**Request Body:**
```json
{
  "username": "usuario",
  "password": "123456"
}
```

**Response (200 OK):**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiresAt": "2025-11-20T15:30:00Z",
  "username": "usuario",
  "email": "usuario@afpcesp.com.br",
  "roles": ["User", "Admin"]
}
```

**Response (401 Unauthorized):**
```json
{
  "message": "Usuário ou senha inválidos"
}
```

### 🔒 Endpoints Protegidos

#### GET /api/auth/me
Retorna informações do usuário autenticado.

**Headers:**
```
Authorization: Bearer {token}
```

**Response (200 OK):**
```json
{
  "username": "usuario",
  "claims": [
    { "type": "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "value": "usuario" },
    { "type": "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "value": "Admin" }
  ],
  "message": "Token válido! Você está autenticado."
}
```

#### GET /api/auth/validate
Valida se o token é válido.

**Response (200 OK):**
```json
{
  "valid": true,
  "message": "Token válido"
}
```

### 👥 User Controller (Protegido)

Todos os endpoints do `UserController` requerem autenticação:

#### GET /api/user
Lista todos os usuários (requer autenticação).

#### GET /api/user/{id}
Busca usuário por ID (requer autenticação).

#### POST /api/user
Cria novo usuário (requer role "Admin").

#### PUT /api/user/{id}
Atualiza usuário (requer role "Admin").

#### DELETE /api/user/{id}
Deleta usuário (requer role "Admin").

## Exemplos de Uso

### Usando cURL

#### 1. Login
```bash
curl -X POST http://localhost:5000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"username":"usuario","password":"123456"}'
```

#### 2. Acessar Endpoint Protegido
```bash
# Substitua {TOKEN} pelo token recebido no login
curl -X GET http://localhost:5000/api/user \
  -H "Authorization: Bearer {TOKEN}"
```

### Usando JavaScript/Fetch

```javascript
// 1. Login
const loginResponse = await fetch('http://localhost:5000/api/auth/login', {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json'
  },
  body: JSON.stringify({
    username: 'usuario',
    password: '123456'
  })
});

const loginData = await loginResponse.json();
const token = loginData.token;

// 2. Usar o token em requisições
const usersResponse = await fetch('http://localhost:5000/api/user', {
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`
  }
});

const users = await usersResponse.json();
```

### Usando C# HttpClient

```csharp
using System.Net.Http.Headers;
using System.Net.Http.Json;

// 1. Login
var loginRequest = new LoginRequest 
{ 
    Username = "usuario", 
    Password = "123456" 
};

var loginResponse = await httpClient.PostAsJsonAsync(
    "http://localhost:5000/api/auth/login", 
    loginRequest
);

var loginData = await loginResponse.Content.ReadFromJsonAsync<LoginResponse>();
var token = loginData.Token;

// 2. Configurar token para requisições
httpClient.DefaultRequestHeaders.Authorization = 
    new AuthenticationHeaderValue("Bearer", token);

// 3. Fazer requisição protegida
var users = await httpClient.GetFromJsonAsync<List<User>>(
    "http://localhost:5000/api/user"
);
```

## Testando no Swagger

1. Execute a aplicação:
   ```bash
   dotnet run --project afpcesp.backoffice.webapi
   ```

2. Acesse o Swagger: `http://localhost:5000/swagger`

3. Faça login pelo endpoint `/api/auth/login`

4. Copie o token retornado

5. Clique no botão **"Authorize"** no topo da página do Swagger

6. Cole o token no formato: `Bearer {seu-token}`

7. Agora você pode testar os endpoints protegidos

## Atributos de Autorização

### [Authorize]
Requer que o usuário esteja autenticado.

```csharp
[Authorize]
[HttpGet]
public ActionResult GetData()
{
    // Apenas usuários autenticados podem acessar
}
```

### [Authorize(Roles = "Admin")]
Requer que o usuário tenha uma role específica.

```csharp
[Authorize(Roles = "Admin")]
[HttpPost]
public ActionResult CreateUser()
{
    // Apenas usuários com role "Admin" podem acessar
}
```

### [Authorize(Roles = "Admin,Manager")]
Requer que o usuário tenha uma das roles especificadas.

```csharp
[Authorize(Roles = "Admin,Manager")]
[HttpPut]
public ActionResult UpdateData()
{
    // Usuários com role "Admin" OU "Manager" podem acessar
}
```

### [AllowAnonymous]
Permite acesso sem autenticação (mesmo em controllers com [Authorize]).

```csharp
[AllowAnonymous]
[HttpPost("login")]
public ActionResult Login()
{
    // Endpoint público, não requer autenticação
}
```

## Acessando Informações do Usuário no Contexto

Dentro dos controllers, você pode acessar informações do usuário autenticado:

```csharp
[Authorize]
[HttpGet("profile")]
public ActionResult GetProfile()
{
    // Nome do usuário
    var username = User.Identity?.Name;
    
    // Verifica se tem uma role específica
    var isAdmin = User.IsInRole("Admin");
    
    // Obtém todas as claims
    var claims = User.Claims.Select(c => new { c.Type, c.Value });
    
    // Obtém claim específica
    var emailClaim = User.FindFirst(ClaimTypes.Email)?.Value;
    
    return Ok(new { username, isAdmin, claims, email = emailClaim });
}
```

## Segurança - Pontos Importantes

### ⚠️ Em Desenvolvimento

- Senha de exemplo está hardcoded ("123456")
- RequireHttpsMetadata está como `false`

### ✅ Para Produção

1. **Implemente validação real de usuário:**
   ```csharp
   // No AuthService.ValidateCredentialsAsync()
   var user = await _userRepository.GetByUsernameAsync(username);
   return user != null && VerifyPasswordHash(password, user.PasswordHash);
   ```

2. **Use hashing de senha (BCrypt, Argon2, etc.):**
   ```bash
   dotnet add package BCrypt.Net-Next
   ```

3. **Configure HTTPS:**
   ```csharp
   RequireHttpsMetadata = true
   ```

4. **Armazene a SecretKey de forma segura:**
   - Use Azure Key Vault
   - Use variáveis de ambiente
   - Use Secrets Manager
   - NUNCA comite a chave no controle de versão

5. **Configure tempo de expiração apropriado:**
   - Tokens de curta duração (15-60 minutos)
   - Implemente refresh tokens para sessões longas

6. **Adicione validação de IP e User-Agent (opcional)**

7. **Implemente rate limiting para evitar ataques de força bruta**

## Claims Disponíveis no Token

O token JWT gerado contém as seguintes claims:

- `sub` - Username do usuário
- `name` - Nome do usuário
- `email` - Email do usuário
- `role` - Roles/perfis do usuário (pode ter múltiplas)
- `jti` - ID único do token
- `iat` - Data/hora de criação do token

## Troubleshooting

### Erro 401 - Unauthorized

**Possíveis causas:**
- Token não foi enviado no header
- Token expirado
- Token inválido ou malformado
- SecretKey diferente entre geração e validação

**Solução:**
- Verifique se o header Authorization está presente
- Faça login novamente para obter um novo token
- Verifique se a SecretKey é a mesma em todos os ambientes

### Erro 403 - Forbidden

**Causa:**
- Usuário autenticado mas sem permissão (role) necessária

**Solução:**
- Verifique se o usuário tem a role necessária para o endpoint
- Ajuste as roles do usuário ou as permissões do endpoint

## Próximos Passos

1. Integrar com banco de dados para validação real de usuários
2. Implementar hash de senhas
3. Adicionar refresh tokens
4. Implementar logout (blacklist de tokens)
5. Adicionar logs de auditoria
6. Configurar políticas de autorização mais complexas
7. Implementar autenticação de dois fatores (2FA)
