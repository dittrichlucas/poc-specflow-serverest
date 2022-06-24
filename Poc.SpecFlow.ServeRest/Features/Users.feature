Feature: Users

    Manage users, list login data and register administrator

    Scenario: List users
        Given I access the users route http://localhost:3001/usuarios
        Then I should have only 1 registered users
        And should be admin
        And your name should be Fulano da Silva
