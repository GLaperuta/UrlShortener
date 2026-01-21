🔗 UrlShortener

Projeto de encurtador de URLs desenvolvido em C# com .NET, utilizando os princípios de DDD (Domain-Driven Design) e Clean Architecture.
O objetivo é criar uma API simples, organizada e escalável para criar, resolver e gerenciar links encurtados.

🧱 Arquitetura

O projeto é dividido em camadas bem definidas:

UrlShortener

├─ UrlShortener.API           → Camada de apresentação (endpoints HTTP)

├─ UrlShortener.Application   → Casos de uso, serviços e DTOs

├─ UrlShortener.Domain        → Regras de negócio e entidades

└─ UrlShortener.Infra         → Persistência e repositórios


Essa separação garante:

✔ Baixo acoplamento

✔ Alta coesão

✔ Facilidade de manutenção

✔ Testabilidade

⚙️ Tecnologias utilizadas

✔ .NET 10

✔ ASP.NET Core (Minimal API)

✔ C#

✔ Entity Framework Core (InMemory Database)

✔ Swagger / OpenAPI

✔ DDD + Clean Architecture

✔ Injeção de Dependência (DI)

🚀 Funcionalidades

✔ Criar URLs encurtadas

✔ Resolver URLs curtas e redirecionar para a original

✔ Listar todas as URLs criadas

✔ Deletar uma URL encurtada

✔ Contador de acessos

✔ Redirecionamento automático via navegador

📌 Endpoints
🔹 Criar uma URL encurtada
POST /api/create


Body (string):

"https://google.com"


Resposta:

{
  "shortCode": "abc123",
  "originalUrl": "https://google.com",
  "accessCount": 0,
  "createdAt": "2026-01-21T20:10:00Z"
}

🔹 Listar todas as URLs
GET /api/urls

🔹 Redirecionar para a URL original
GET /{shortUrl}


Exemplo:

GET /abc123


➡ Redireciona automaticamente para a URL original.

🔹 Deletar uma URL
DELETE /api/delete/{shortUrl}

📖 Swagger

Após rodar o projeto, acesse:

https://localhost:{porta}/swagger


A porta pode ser vista no console ou no arquivo:

Properties/launchSettings.json

🧪 Banco de dados

O projeto usa InMemory Database, ideal para estudos e testes:

.UseInMemoryDatabase("UrlShortenerDB")


Não há necessidade de configurar SQL Server ou outro banco.

🎯 Objetivo do projeto

Este projeto tem foco educacional e arquitetural, demonstrando como aplicar boas práticas de desenvolvimento em um problema simples:

✔ Separação clara de responsabilidades

✔ Uso correto de DTOs

✔ Domínio isolado de infraestrutura

✔ Código organizado e profissional

✨ Exemplo de execução

Rodar o projeto

Abrir:

https://localhost:{porta}/swagger


Criar uma URL

Acessar:

https://localhost:{porta}/{shortCode}


E ser redirecionado automaticamente 🎉
