# Coleção Postman - AFPCESP BackOffice API

Esta pasta contém a coleção Postman completa para testar todos os endpoints da API BackOffice AFPCESP.

## 📁 Arquivos

- **AFPCESP_API.postman_collection.json** - Coleção com todos os endpoints da API
- **AFPCESP_Development.postman_environment.json** - Ambiente de desenvolvimento pré-configurado
- **README.md** - Este arquivo com instruções de uso

## 🚀 Como Importar

### Importar a Coleção

1. Abra o Postman
2. Clique em **Import** (botão no canto superior esquerdo)
3. Arraste o arquivo `AFPCESP_API.postman_collection.json` ou clique em **Upload Files**
4. A coleção será importada com todos os endpoints organizados em pastas

### Importar o Ambiente

1. No Postman, clique no ícone de engrenagem (⚙️) no canto superior direito
2. Clique em **Import**
3. Selecione o arquivo `AFPCESP_Development.postman_environment.json`
4. Selecione o ambiente **AFPCESP - Development** no dropdown no canto superior direito

## 🔧 Configuração Inicial

### Variáveis de Ambiente

O ambiente já vem pré-configurado com:

| Variável | Valor Padrão | Descrição |
|----------|--------------|-----------|
| `baseUrl` | `http://localhost:5031` | URL base da API (HTTP) |
| `baseUrlHttps` | `https://localhost:7209` | URL base da API (HTTPS) |
| `token` | (vazio) | Token JWT - preenchido automaticamente após login |
| `username` | (vazio) | Nome do usuário - preenchido após login |
| `userId` | (vazio) | ID do usuário - para uso em testes |

### Primeiro Uso

1. **Inicie a API**
   ```bash
   cd /home/ojcamargo/projects/afpcesp
   dotnet run --project afpcesp.backoffice.webapi
   ```

2. **Execute o Login**
   - Vá para a pasta **Authentication** → **Login**
   - Execute a requisição (credenciais de exemplo já estão preenchidas)
   - O token será salvo automaticamente na variável `{{token}}`

3. **Use os Outros Endpoints**
   - Todos os endpoints protegidos já estão configurados para usar `{{token}}`
   - O token é enviado automaticamente no header `Authorization: Bearer {{token}}`

## 📚 Estrutura da Coleção

### 1. Authentication (3 endpoints)

Endpoints relacionados à autenticação JWT:

- **POST** `/api/Auth/login` - Autenticação e obtenção de token
- **GET** `/api/Auth/me` - Informações do usuário autenticado
- **GET** `/api/Auth/validate` - Validação do token

### 2. Users (5 endpoints)

CRUD completo de usuários:

- **GET** `/api/User` - Listar todos os usuários
- **GET** `/api/User/{id}` - Obter usuário por ID
- **POST** `/api/User` - Criar novo usuário (requer role Admin)
- **PUT** `/api/User/{id}` - Atualizar usuário (requer role Admin)
- **DELETE** `/api/User/{id}` - Deletar usuário (requer role Admin)

## 🔐 Autenticação Automática

A coleção inclui um script de teste no endpoint de Login que:

1. Captura o token da resposta
2. Salva automaticamente na variável de ambiente `token`
3. Salva o username na variável `username`

Todos os endpoints protegidos usam automaticamente: `Authorization: Bearer {{token}}`

## 📋 Exemplos de Uso

### Fluxo Básico

```
1. Login → Obter Token
2. Get All Users → Listar usuários
3. Get User by ID → Ver detalhes de um usuário
4. Create User → Criar novo usuário (se for Admin)
```

## 🛠️ Personalização

### Alterar Base URL

Se sua API estiver rodando em outra porta ou servidor:

1. Vá em **Environments** → **AFPCESP - Development**
2. Altere o valor de `baseUrl`
3. Salve as alterações

### Adicionar Novos Endpoints

1. Clique com botão direito na pasta desejada
2. Selecione **Add Request**
3. Configure o método HTTP, URL e body
4. Use `{{baseUrl}}` e `{{token}}` nas requisições

## 📝 Credenciais de Teste

**Observação:** As credenciais abaixo são exemplos. Configure de acordo com seu banco de dados.

```json
{
  "username": "admin",
  "password": "admin123"
}
```

## 🔍 Troubleshooting

### Erro 401 Unauthorized
- Verifique se o token está salvo na variável de ambiente
- Faça login novamente para obter um novo token
- Verifique se o token não expirou

### Erro 403 Forbidden
- Seu usuário não tem a role necessária
- Faça login com um usuário que tenha permissão (ex: Admin)

### Erro de Conexão
- Verifique se a API está rodando
- Confirme que a porta está correta no `baseUrl`
- Teste acessar `http://localhost:5031/swagger` no navegador

## 📖 Documentação Adicional

- **Swagger UI:** `http://localhost:5031/swagger`
- **Documentação JWT:** Ver `documentacao/jwt-authentication-guide.md`
- **Arquitetura:** Ver `documentacao/architecture-layered.md`

## 🤝 Contribuindo

Para adicionar novos endpoints à coleção:

1. Crie a requisição no Postman
2. Exporte a coleção atualizada
3. Substitua o arquivo `AFPCESP_API.postman_collection.json`
4. Atualize este README se necessário

---

**Última atualização:** 21 de novembro de 2025  
**Versão da Coleção:** 1.0  
**Total de Endpoints:** 8
