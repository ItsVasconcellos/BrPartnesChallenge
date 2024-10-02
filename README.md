# BrPartnesChallenge

Este projeto implementa um sistema de CRUD para cadastro de clientes com a possibilidade de conter diferentes tipos de endereços (Fiscal, Cobrança, Entrega) usando ASP.NET MVC Core com modelagem DDD (Domain-Driven Design). O projeto faz uso do Entity Framework para o gerenciamento e alterações no banco de dados SQL Server e das grids da biblioteca DevExpress para exibir os dados nas interfaces.

## Funcionalidades

- Cadastro de Clientes com informações como nome, e-mail, telefone, sexo e idade.
- Gerenciamento de Endereços (Fiscal, Cobrança, Entrega) vinculados a cada cliente.
- Exibição dos dados em telas utilizando grids da DevExpress. (Não finalizado)
- Uso de ASP.NET Core MVC para a arquitetura de controle e visualização.
- Implementação baseada no padrão DDD (Domain-Driven Design) para separar as camadas de domínio e aplicação.
- Integração com o SQL Server para armazenamento de dados.
- Entity Framework Core utilizado para mapeamento e controle das entidades no banco de dados.

## Tecnologias Utilizadas
**ASP.NET Core MVC**: Framework para o desenvolvimento de aplicações web.
**Entity Framework Core**: Ferramenta ORM para gerenciamento e interação com o banco de dados SQL Server.
**SQL Server**: Banco de dados relacional utilizado para armazenamento dos dados.
**DevExpress**: Biblioteca para componentes de interface (UI), especialmente as grids, que ajudam na exibição e manipulação de dados.
**Domain-Driven Design (DDD)**: Padrão arquitetural utilizado para separar responsabilidades em camadas como Domínio, Infraestrutura e Aplicação.
**Visual Studio**: IDE utilizada para desenvolvimento e execução do projeto.

## Requisitos
- Visual Studio 2022
- SQL Server
- .NET 6.0 SDK
- DevExpress Free Trial (para utilizar as grids nas interfaces)
- Instalação e Execução

## Guia de execução

#### Passo 1: Clonar o Repositório
Clone este repositório para sua máquina local utilizando o Git.

```bash
git clone https://github.com/seu-usuario/nome-do-repositorio.git
```
#### Passo 2: Configurar a String de Conexão com o SQL Server
No arquivo appsettings.json, configure a string de conexão com o seu banco de dados SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO_DE_DADOS;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}
```

#### Passo 3: Executar as Migrações do Entity Framework
Abra o Package Manager Console no Visual Studio e execute os seguintes comandos para aplicar as migrações e criar o banco de dados:

```bash
Update-Database
```
Este comando irá criar as tabelas de Clientes e Endereços no banco de dados SQL Server.

#### Passo 4: Baixar e Configurar DevExpress
Acesse DevExpress Free Trial.
Baixe a versão de avaliação e siga as instruções de instalação.
Após a instalação, configure os componentes nas telas de cadastro de clientes e endereços utilizando os grids da DevExpress.

#### Passo 5: Executar o Projeto
No Visual Studio:

Defina o ClientController como controlador inicial ou configure a rota inicial para a interface de listagem de clientes.
Pressione F5 ou clique em "Iniciar" para rodar o projeto.
A aplicação será iniciada e você poderá acessar as funcionalidades de CRUD diretamente no navegador.

## Estrutura de Pastas
O projeto segue o padrão DDD, com uma clara separação de responsabilidades:

```bash
/Backend
  /Domain
    /Entities        # Contém as classes de domínio, como Client e Address
    /Repositories    # Definições das interfaces de repositórios
    /Services        # Lógica de negócio e validações
  /Infra
    /Data            # Configurações do Entity Framework e SQL Server
    /Repositories    # Implementações dos repositórios
  /UI
    /Controllers     # Controladores ASP.NET MVC
    /Views           # Views utilizando grids da DevExpress
  /DTOs              # Data Transfer Objects para expor os dados ao frontend
```

## Funcionalidades das Rotas
- **GET /api/Client/getAllClients**: Retorna todos os clientes e seus respectivos endereços.
- **GET /api/Client/getClient/{id}**: Retorna um cliente específico com seus endereços.
- **POST /api/Client/createClient**: Cria um novo cliente e seus endereços.
- **PUT /api/Client/updateClient**: Atualiza os dados de um cliente existente.
- **DELETE /api/Client/{id}**: Exclui um cliente do sistema.

