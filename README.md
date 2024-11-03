# APIRecicheck

## Descrição
APIRecicheck é uma Web API desenvolvida em C# para gerenciar o processo de reciclagem. Esta API permite criar, ler, atualizar e deletar informações relacionadas ao processo de reciclagem.

## Pré-requisitos
- .NET 7.0 SDK ou superior
- Visual Studio ou Visual Studio Code
- Git

## Instalação

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/LeandroMoura124/APIRecicheck.git


### Via Visual Studio

1. Abra o projeto no Visual Studio.
2. Navegue até a aba **Test Explorer**.
3. Selecione os testes que deseja executar.
4. Clique em **Run** para executar os testes.
   
## Estrutura dos Testes

Os testes estão organizados em classes que herdam de `IClassFixture<WebApplicationFactory<APIRecicheck.Program>>` para configurar o ambiente de teste. Aqui estão alguns exemplos de testes implementados:

- **UserRegistrationTests.cs**: Testa a funcionalidade de login e valida a obtenção de um token.
- **RegistrationCollectionUnauthorized.cs**: Testa a funcionalidade de registro de coleta e lida com cenários de autorização.

## Cenários de Teste BDD

Os cenários de teste BDD são escritos utilizando a linguagem Gherkin. Aqui estão alguns exemplos:

### Cenário 1: Login com Credenciais Válidas

```gherkin
Dado que o usuário possui credenciais válidas
Quando ele tenta fazer login
Então ele deve receber um token de autenticação
