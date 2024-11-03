Feature: Cadastro de Usuário

  Scenario: Usuário se cadastra com sucesso
    Given que eu estou na página de cadastro de usuário
    When eu envio os dados "Nome", "Email" e "Senha" válidos
    Then o sistema deve retornar um status code 200
    And o corpo da resposta deve conter a mensagem "Usuário cadastrado com sucesso"
    And o usuário deve ser salvo no banco de dados
