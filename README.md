# Sistema de Eventos

Sistema web simples para cadastro e visualização de eventos acadêmicos.

## Funcionalidades

- Cadastro de novos eventos com título, descrição, data/hora, palestrante e número de vagas
- Listagem de todos os eventos cadastrados
- Interface web responsiva e fácil de usar

## Tecnologias Utilizadas

- **Frontend:** HTML, CSS, JavaScript puro
- **Backend:** C# (.NET)
- **Banco de Dados:** MongoDB

## Como Executar

1. Clone este repositório:
   ```sh
   git clone https://github.com/ThomasVianna/sistema-eventos.git
   ```
2. Instale as dependências do backend:
   ```sh
   cd sistema-eventos
   dotnet restore
   ```
3. Configure o banco de dados MongoDB:
   - Certifique-se de que o MongoDB está instalado e rodando em `mongodb://localhost:27017`
   - O banco utilizado será `SistemaEventosDB` (configurável em `appsettings.json`)
4. Inicie o backend:
   ```sh
   dotnet run
   ```
   O backend estará disponível em `http://localhost:8099` (ou porta configurada).
5. Abra o frontend:
   - Abra o arquivo `frontend/index.html` no seu navegador

## Estrutura do Projeto

```
sistema-eventos/
│
├── Controllers/        # Controllers da API
├── Data/               # DbContext (caso use EF Core)
├── DTOs/               # Data Transfer Objects
├── Models/             # Modelos das entidades
├── Services/           # Serviços (ex: MongoService)
├── frontend/           # Código do frontend (HTML, CSS, JS)
│   ├── index.html
│   ├── style.css
│   └── script.js
├── appsettings.json    # Configurações do projeto
├── Program.cs          # Inicialização da aplicação
└── README.md
```

## Observações

- O backend utiliza MongoDB como banco principal.
- Caso queira usar SQL Server, ajuste as configurações e dependências conforme necessário.
- O frontend consome a API diretamente via fetch.

## Contribuição

Sinta-se à vontade para abrir issues ou enviar pull requests!

## Licença

Este projeto está licenciado sob a licença MIT.