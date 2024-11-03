Feature: Cadastro De Coleta

  Scenario: Usuário cadastra coleta e retorna 201
    When eu envio os dados "tipoResiduo", "dataColeta" e "quantidade" válidos
    Then o sistema deve retornar um status code 401 caso usuário não gerou token
    Então o usuário se autentica e realiza novamente a tentativa de cadastro.
    O log retorna "Teste Realizado Com Sucesso! Coleta Cadastrada"

