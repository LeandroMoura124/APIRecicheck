Feature: Cadastro de Usu�rio

  Scenario: Usu�rio se cadastra com sucesso
    Given que eu estou na p�gina de cadastro de usu�rio
    When eu envio os dados "Nome", "Email" e "Senha" v�lidos
    Then o sistema deve retornar um status code 200
    And o corpo da resposta deve conter a mensagem "Usu�rio cadastrado com sucesso"
    And o usu�rio deve ser salvo no banco de dados
