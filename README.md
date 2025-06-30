Este projeto é uma API REST simples desenvolvida em C# (.NET) que implementa as operações CRD (Create, Read e Delete).

Funcionalidades da API:

- `POST /users/register` – Registra um novo usuário.
- `GET /users/list` – Lista todos os usuários.
- `DELETE /users/{id}` – Deletar usuários por ID.

Todos os dados são armazenados em um JSON local (users.json).

Tecnologias Utilizadas

- ASP.NET Core Web API
- Console Application
- JSON como base de dados local
- Postman (para testes de rota)
  
Console Client

A aplicação de console permite:

- Inserir usuários manualmente via terminal.
- Enviar requisições para a API.
- Deletar usuários por ID via terminal.
