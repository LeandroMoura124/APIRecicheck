Feature: Cadastro De Coleta

  Scenario: Usu�rio cadastra coleta e retorna 201
    When eu envio os dados "tipoResiduo", "dataColeta" e "quantidade" v�lidos
    Then o sistema deve retornar um status code 401 caso usu�rio n�o gerou token
    Ent�o o usu�rio se autentica e realiza novamente a tentativa de cadastro.
    O log retorna "Teste Realizado Com Sucesso! Coleta Cadastrada"

