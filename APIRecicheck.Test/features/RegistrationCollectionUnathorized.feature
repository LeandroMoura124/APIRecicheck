Feature: Cadastro Não autorizado

  Scenario: Usuário cadastra coleta e retorna 401
    When eu envio os dados "tipoResiduo", "dataColeta" e "quantidade" válidos
    Then o sistema deve retornar um status code 401 caso usuário não gerou token
    O log retorna "Não autorizado. Teste finalizado"

