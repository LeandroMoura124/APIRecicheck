Feature: Atualizacao de Usuário

  Scenario: Usuário se atualiza com sucesso
    Given que eu estou na página de edicao de usuário
    When eu envio os dados "Nome", "Email" e "Senha" válidos
    Then o sistema deve retornar um status code 200
    And o corpo da resposta deve conter a mensagem "Usuário atualizado com sucesso"
    And o usuário deve ser salvo no banco de dados
