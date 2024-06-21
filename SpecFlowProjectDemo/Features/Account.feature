Feature: Account statement

  Background:
    Given Account exists for Acc No. "12345678" with Name "Bob Smith"
    And deposits are made
      | Transaction | Amount | Date     |
      | INIT        | 200    | 05/06/24 |
      | DEP1        | 100    | 05/06/24 |
      | DEP2        | 450    | 11/06/24 |
      | DEP3        | 50     | 12/06/24 |
    And withdrawals are made
      | Transaction | Amount | Date     |
      | CHQ001      | 675.55 | 10/06/24 |
    When statement is produced

  @regression
  Scenario: Statement includes account details
    Then the statement includes "Name: Bob Smith"
    And the statement includes "Account: 12345678"

  @regression
  Scenario: Balance is calculated on the statement
    Then the statement includes "Balance: 124.45"

  @regression
  Scenario: Statement includes transaction details
    Then the statement includes "05/06/24: INIT: 200.0"
    And the statement includes "05/06/24: DEP1: 100.0"
    And the statement includes "11/06/24: DEP2: 450.0"
    And the statement includes "12/06/24: DEP3: 50.0"
    And the statement includes "10/06/24: CHQ001: -675.55"
