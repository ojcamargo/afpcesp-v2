# 📚 Índice de Documentação - Autenticação JWT

## Início Rápido

1. **[Resumo da Implementação](jwt-implementation-summary.md)**
   - Status do projeto
   - Arquivos criados
   - Próximos passos

2. **[Guia de Autenticação JWT](jwt-authentication-guide.md)**
   - Como fazer login
   - Como usar tokens
   - Exemplos práticos
   - Troubleshooting

3. **[Guia de Autorização Avançada](advanced-authorization-guide.md)**
   - Políticas de autorização
   - Requirements customizados
   - Contexto do usuário
   - Exemplos avançados

## Arquivos de Código Principal

### Configuration
- `afpcesp.backoffice.webapi/Configuration/JwtSettings.cs`
  - Configurações do JWT (SecretKey, Issuer, Audience, etc)

### Models
- `afpcesp.backoffice.webapi/Models/LoginRequest.cs`
  - Modelo de requisição de login
- `afpcesp.backoffice.webapi/Models/LoginResponse.cs`
  - Modelo de resposta com token

### Services
- `afpcesp.backoffice.webapi/Services/IAuthService.cs`
  - Interface do serviço de autenticação
- `afpcesp.backoffice.webapi/Services/AuthService.cs`
  - Implementação da autenticação e geração de tokens JWT

### Controllers
- `afpcesp.backoffice.webapi/Controller/AuthController.cs`
  - Endpoints de login e validação
- `afpcesp.backoffice.webapi/Controller/UserController.cs`
  - Exemplo de controller protegido
- `afpcesp.backoffice.webapi/Controller/ExampleController.cs`
  - Exemplos práticos de autorização

### Authorization
- `afpcesp.backoffice.webapi/Authorization/AuthorizationPolicies.cs`
  - Políticas e handlers customizados

### Configuration Files
- `afpcesp.backoffice.webapi/Program.cs`
  - Configuração do pipeline de autenticação
- `afpcesp.backoffice.webapi/appsettings.json`
  - Configurações do JWT
- `afpcesp.backoffice.webapi/appsettings.Development.json`
  - Configurações de desenvolvimento

### Testes
- `afpcesp.backoffice.webapi/afpcesp.backoffice.webapi.http`
  - Exemplos de requisições HTTP

## Fluxo de Autenticação

```
1. Cliente → POST /api/auth/login (username, password)
2. API → Valida credenciais
3. API → Gera token JWT com claims
4. API → Retorna token + informações do usuário
5. Cliente → Guarda o token
6. Cliente → Envia token em requisições: Authorization: Bearer {token}
7. API → Valida token automaticamente
8. API → Disponibiliza User.Identity com claims
9. Controller → Usa [Authorize] para proteger endpoints
10. Controller → Acessa User.Identity.Name, User.Claims, etc
```

## Endpoints Disponíveis

### 🔓 Públicos
- `POST /api/auth/login` - Login e obtenção de token

### 🔒 Protegidos (Requer Token)
- `GET /api/auth/me` - Informações do usuário autenticado
- `GET /api/auth/validate` - Valida se o token é válido
- `GET /api/user` - Lista usuários
- `GET /api/user/{id}` - Busca usuário por ID

### 🔐 Admin Only (Requer Token + Role "Admin")
- `POST /api/user` - Cria usuário
- `PUT /api/user/{id}` - Atualiza usuário
- `DELETE /api/user/{id}` - Deleta usuário

### 📚 Exemplos
- `GET /api/example/public` - Endpoint público
- `GET /api/example/protected` - Requer autenticação
- `GET /api/example/claims` - Mostra claims do token
- `GET /api/example/admin-only` - Requer role Admin
- `GET /api/example/my-data` - Dados do usuário autenticado
- E muitos outros exemplos...

## Como Testar

### Opção 1: VS Code REST Client
1. Abra o arquivo `afpcesp.backoffice.webapi.http`
2. Execute as requisições clicando em "Send Request"

### Opção 2: Swagger
1. Execute: `dotnet run --project afpcesp.backoffice.webapi`
2. Acesse: http://localhost:5031/swagger
3. Faça login em `/api/auth/login`
4. Clique em "Authorize" e cole o token
5. Teste os endpoints

### Opção 3: cURL
```bash
# Login
curl -X POST http://localhost:5031/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"username":"usuario","password":"123456"}'

# Usar token
curl -X GET http://localhost:5031/api/user \
  -H "Authorization: Bearer SEU_TOKEN"
```

## Códigos de Status HTTP

- **200 OK** - Sucesso
- **201 Created** - Recurso criado com sucesso
- **400 Bad Request** - Dados inválidos
- **401 Unauthorized** - Token ausente ou inválido
- **403 Forbidden** - Autenticado mas sem permissão
- **404 Not Found** - Recurso não encontrado
- **500 Internal Server Error** - Erro do servidor

## Atributos de Autorização

```csharp
[AllowAnonymous]                    // Público
[Authorize]                         // Requer autenticação
[Authorize(Roles = "Admin")]        // Requer role específica
[Authorize(Roles = "Admin,Manager")] // Requer uma das roles (OR)
[Authorize(Policy = "PolicyName")]  // Requer política customizada
```

## Claims Disponíveis no Token

- `sub` - Username
- `name` - Nome do usuário
- `email` - Email
- `role` - Roles/perfis (pode ter múltiplas)
- `jti` - ID único do token
- `iat` - Timestamp de criação

## Acessando Contexto do Usuário

```csharp
// Nome do usuário
var username = User.Identity?.Name;

// Verificar role
var isAdmin = User.IsInRole("Admin");

// Obter claim específica
var email = User.FindFirst(ClaimTypes.Email)?.Value;

// Todas as claims
var claims = User.Claims;
```

## ⚠️ Avisos de Segurança

### Para Demonstração (Atual)
- ✅ Senha hardcoded: "123456"
- ✅ RequireHttpsMetadata: false
- ✅ Validação simplificada

### Para Produção (Implementar)
- ⚠️ Integrar com banco de dados
- ⚠️ Usar hash de senha (BCrypt, Argon2)
- ⚠️ Habilitar HTTPS
- ⚠️ Proteger SecretKey (Key Vault, env vars)
- ⚠️ Implementar refresh tokens
- ⚠️ Adicionar rate limiting
- ⚠️ Implementar logout (blacklist)
- ⚠️ Adicionar logs de auditoria

## Suporte

Para mais informações, consulte:
1. [jwt-authentication-guide.md](jwt-authentication-guide.md)
2. [advanced-authorization-guide.md](advanced-authorization-guide.md)
3. [jwt-implementation-summary.md](jwt-implementation-summary.md)
4. Código de exemplo: `Controller/ExampleController.cs`
5. Requisições HTTP: `afpcesp.backoffice.webapi.http`

## Estrutura do Projeto

```
afpcesp.backoffice.webapi/
├── Configuration/        # Configurações (JWT, etc)
├── Models/              # DTOs e modelos
├── Services/            # Lógica de negócio
├── Controller/          # Endpoints da API
├── Authorization/       # Políticas customizadas
├── Program.cs           # Configuração da aplicação
└── appsettings.json     # Configurações
```

---

**Status:** ✅ Implementação Completa e Funcional

**Build:** ✅ Sem erros

**Documentação:** ✅ Completa

**Exemplos:** ✅ Fornecidos

**Pronto para uso!** 🚀
