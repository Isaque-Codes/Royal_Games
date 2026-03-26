# 🎮 Royal_Games

Plataforma de e-commerce para jogos e consoles com autenticação de administrador e catálogo público.

**Status:** 🚧 Em desenvolvimento

---

## 📋 Descrição

Sistema de gerenciamento de catálogo de jogos e consoles com separação clara entre operações públicas (visualização) e administrativas (CRUD). Implementa padrões de Domain-Driven Design com validações de negócio na camada de domínio.

---

## 🎯 Regras de Negócio

| Regra | Descrição |
|-------|-----------|
| **Autenticação** | Apenas usuários autenticados podem cadastrar, editar ou excluir jogos e consoles |
| **Nome Único** | Não devem existir dois jogos com o mesmo nome para a mesma plataforma |
| **Preço** | O valor do jogo não pode ser negativo ou igual a zero |
| **Descontinuados** | Produtos descontinuados permanecem no catálogo apenas para consulta, não podendo ser marcados como disponíveis |

---

## ✨ Funcionalidades

### Cliente (Público)

- Visualizar catálogo de jogos e consoles
- Filtrar por: nome, plataforma, gênero e menor preço
- Consultar informações completas do produto

### Administrador (Autenticado)

- Cadastrar novos jogos e consoles
- Editar informações de produtos
- Excluir produtos do catálogo
- Realizar logout

---

## 🛠️ Arquitetura

Implementação de **Clean Architecture** com separação clara de responsabilidades:

Controllers → Services → DTOs → Repositories → Interfaces → Context

Fluxo de dados: Routes → Business Logic → Data Access → Database (com Validações)

### Padrões Aplicados

- **DDD (Domain-Driven Design)** - Validações na camada de domínio
- **Repository Pattern** - Abstração de acesso a dados
- **DTO Pattern** - Transferência de dados entre camadas
- **Exception Handling** - `DomainException` para erros de negócio

---

## 📁 Estrutura do Projeto

Royal_Games/
- Domains/: Jogo.cs, Usuario.cs, Plataforma.cs, Genero.cs, ClassIndicativa.cs
- Controllers/: JogoController.cs, UsuarioController.cs, PlataformaController.cs, ClassIndicativaController.cs
- Applications/Services/: JogoService.cs, UsuarioService.cs, PlataformaService.cs, ClassIndicativaService.cs
- Repositories/: JogoRepository.cs, UsuarioRepository.cs, PlataformaRepository.cs
- DTOs/: JogoDto (CriarJogoDto.cs, AtualizarJogoDto.cs, LerJogoDto.cs), UsuarioDto
- Contexts/: Royal_GamesContext.cs
- Exceptions/: DomainException.cs

---

## 🔐 Autenticação JWT

A API utiliza **JWT (JSON Web Tokens)** para autenticação:

- Chave secreta armazenada em `appsettings.json`
- Validação de issuer, audience e expiração
- Endpoints protegidos com atributo `[Authorize]`

**Endpoints Protegidos:**
- POST `/api/jogo` - Criar jogo
- PUT `/api/jogo/{id}` - Editar jogo
- DELETE `/api/jogo/{id}` - Deletar jogo
- POST `/api/classIndicativa` - Criar classificação

---

## 🚀 Stack Tecnológico

### Backend (C#)

- **ASP.NET Core 8+** - Framework web
- **Entity Framework Core** - ORM
- **SQL Server** - Banco de dados
- **JWT Bearer** - Autenticação

### Frontend (Em desenvolvimento)

- **Next.js** - Framework React
- **TypeScript** - Type safety
- **TailwindCSS** - Estilização (previsto)

### Banco de Dados

- Relacionamentos Many-to-Many (Jogo ↔ Gênero, Jogo ↔ Plataforma)
- Triggers para auditoria (trg_AlteracaoJogo, trg_ExclusaoJogo)
- Índices únicos para integridade de dados
- Soft delete para usuários e produtos descontinuados

---

## 📌 Endpoints Principais

| Método | Rota | Autenticação | Descrição |
|--------|------|--------------|-----------|
| GET | `/api/jogo` | ❌ | Listar todos os jogos |
| GET | `/api/jogo/{id}` | ❌ | Obter detalhes de um jogo |
| POST | `/api/jogo` | ✅ | Criar novo jogo |
| PUT | `/api/jogo/{id}` | ✅ | Atualizar jogo |
| DELETE | `/api/jogo/{id}` | ✅ | Deletar jogo |
| GET | `/api/plataforma` | ❌ | Listar plataformas |
| GET | `/api/genero` | ❌ | Listar gêneros |
| POST | `/api/usuario` | ❌ | Registrar novo usuário |
| POST | `/api/usuario/login` | ❌ | Autenticar e obter token |

---

## 🎓 Aprendizados e Boas Práticas

- ✅ Clean Architecture com responsabilidades bem definidas
- ✅ DDD com validações na camada de domínio
- ✅ JWT para autenticação segura
- ✅ Repository Pattern para abstração de dados
- ✅ DTOs para transferência de dados entre camadas
- ✅ Tratamento de exceções customizadas
- ✅ Índices e constraints para integridade de dados
- ✅ Triggers para auditoria e soft delete

---

## 📚 Documentação

Swagger disponível em `/swagger` quando o projeto estiver completo.

---

## 👤 Autor

[Isaque-Codes](https://github.com/Isaque-Codes)