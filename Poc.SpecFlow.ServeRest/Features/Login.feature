Feature: Login

Scenario: Login
    Given I access the route http://localhost:3001/login
    When I pass the fulano@qa.com and teste password
    Then I should get a token for authentication
