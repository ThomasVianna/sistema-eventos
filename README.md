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
   ```
   git clone https://github.com/ThomasVianna/sistema-eventos.git
   ```
2. Instale as dependências do backend:
   ```
   cd sistema-eventos/backend
   dotnet restore
   ```
3. Inicie o backend:
   ```
   dotnet run
   ```
4. Abra o frontend:
   - Abra o arquivo `frontend/index.html` no seu navegador

## Estrutura do Projeto

```
sistema-eventos/
│
├── backend/           # Código do backend (API em C#)
├── frontend/          # Código do frontend (HTML, CSS, JS)
│   ├── index.html
│   ├── style.css
│   └── script.js
└── README.md
```

## Contribuição

Sinta-se à vontade para abrir issues ou enviar pull requests!

## Licença

Este projeto está licenciado sob a licença MIT.