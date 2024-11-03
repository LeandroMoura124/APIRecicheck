 Feature: Usuario Existe
 Scenario: Cadastro falha quando o usuário já existe
    Given que eu estou na página de cadastro de usuário
    And um usuário com o email "email@example.com" já existe no sistema
    When eu tento me cadastrar com os dados "Nome", "email@example.com" e "Senha"
    Then o sistema deve retornar um status code 409
    And o corpo da resposta deve conter a mensagem "Este nome de usuário já está em uso"
    And o usuário não deve ser salvo novamente no banco de dados