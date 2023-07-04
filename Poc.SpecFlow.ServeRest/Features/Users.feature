Feature: Users

    Manage users, list login data and register administrator

    Scenario: List users
        Given I access the users route http://localhost:3001/usuarios
        Then I should have only 1 registered users
        And should be admin
        And your name should be Fulano da Silva
    
    Scenario: List user by id
        Given I access the users route http://localhost:3001/usuarios
        And that the user with ID 0uxuPY0cbmQhpEz1 exists
        When I list the user with ID 0uxuPY0cbmQhpEz1
        Then the status code should be 200
        And the returned object should not be empty
        And the _id field should be equal to the passed ID
        And the name field should be Fulano da Silva
        
    # Scenario: Create user
    #     Given I access the users route http://localhost:3001/usuarios
    #     When XPTO happen
    #     Then I should have only 1 registered users
    #     And should be admin
    #     And your name should be Fulano da Silva
        
    # Scenario: Update user
    #     Given I access the users route http://localhost:3001/usuarios
    #     Then I should have only 1 registered users
    #     And should be admin
    #     And your name should be Fulano da Silva
        
    # Scenario: Delete user
    #     Given I access the users route http://localhost:3001/usuarios
    #     Then I should have only 1 registered users
    #     And should be admin
    #     And your name should be Fulano da Silva
