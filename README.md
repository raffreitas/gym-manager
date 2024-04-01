# Gym Manager

**Gym Manager** é uma aplicação que oferece uma plataforma para gerenciamento de check-ins em academias. Abaixo estão listadas as principais funcionalidades, requisitos funcionais, regras de negócio e requisitos não-funcionais do projeto.

## Funcionalidades
- Cadastro de usuários
- Autenticação de usuários
- Perfil do usuário logado
- Número de check-ins realizados pelo usuário logado
- Busca de academias próximas (até 10km)
- Busca de academias pelo nome
- Realização de check-in em uma academia
- Validação do check-in por um usuário administrador
- Cadastro de academias por administradores

###  Requisitos Funcionais (RFs)
 - Cadastro de usuário
 - Autenticação de usuário
 - Perfil do usuário logado
 - Número de check-ins realizados pelo usuário logado
 - Busca de academias próximas (até 10km)
 - Busca de academias pelo nome
 - Realização de check-in em uma academia
 - Validação do check-in por um usuário administrador
 - Cadastro de academias por administradores

### Regras de Negócio (RNs)
 - Cadastro de usuário com e-mail único
 - Restrição de 1 check-in por usuário por dia
 - Restrição de check-in apenas se o usuário estiver próximo (100m) da academia
 - Validação do check-in até 20 minutos após a criação
 - Validação do check-in apenas por administradores
 - Cadastro de academia apenas por administradores

### Requisitos Não-Funcionais (RNFs)
 - Senha do usuário criptografada
 - Identificação de usuário por meio de JWT (JSON Web Token)

## Tecnologias Utilizadas
- CQRS (Command Query Responsibility Segregation)
- Clean Architecture
- MediatR
- FluentValidation
- Testes Unitários com xUnit
- Banco de Dados SQL Server