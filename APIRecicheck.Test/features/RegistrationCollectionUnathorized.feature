Feature: Cadastro N�o autorizado

  Scenario: Usu�rio cadastra coleta e retorna 401
    When eu envio os dados "tipoResiduo", "dataColeta" e "quantidade" v�lidos
    Then o sistema deve retornar um status code 401 caso usu�rio n�o gerou token
    O log retorna "N�o autorizado. Teste finalizado"

