Feature: Pago con Yape
  As un usuario registrado en la aplicaci�n
  I want pagar con Yape
  To que pueda realizar transacciones de manera r�pida y segura

Scenario: Pago fallido con Yape
    Given estoy autenticado en la aplicaci�n con una cuenta Yape vinculada
    When sin saldo suficiente confirmo el monto a pagar de 50
    Then veo un mensaje de error indicando que no hay saldo suficiente