@API 
Feature: Profile definitions can include and exclude certain references on resources

Scenario Outline: The Read content type only includes certain reference properties
    Given the caller is using the "Test-Profile-Resource-References-IncludeOnly" profile
    When a GET (by id) request is submitted using <call mechanism> to schools with an accept header content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the response model should contain the id and the primary key properties of [schoolId]
    And the response model should contain the explicitly included regular reference properties
    And the response model should contain the explicitly included role-named reference properties
    And the number of properties on the response model should reflect the number of included properties plus the Id and primary key properties

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Read content type only excludes certain reference properties
    Given the caller is using the "Test-Profile-Resource-References-ExcludeOnly" profile
    When a GET (by id) request is submitted using <call mechanism> to schools with an accept header content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the response model should contain the id and the primary key properties of [schoolId]
    And the response model should not contain the explicitly excluded reference properties
    And the number of properties on the response model should reflect the number of properties (including the Id and primary key properties) less the excluded ones

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Write content type only includes certain reference properties
    Given the caller is using the "Test-Profile-Resource-References-IncludeOnly" profile
    When a PUT request with a completely updated resource is submitted using <call mechanism> to schools with a request body content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the persisted entity model should have unmodified primary key values
    And the only values changed should be the explicitly included regular and role-named references' properties

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Write content type only excludes certain reference properties
    Given the caller is using the "Test-Profile-Resource-References-ExcludeOnly" profile
    When a PUT request with a completely updated resource is submitted using <call mechanism> to schools with a request body content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the persisted entity model should have unmodified primary key values
    And the persisted entity model should not have new values assigned to the explicitly excluded references' properties
    And the only values not changed should be the explicitly excluded values, the id, and the primary key values

Examples:
    | call mechanism |
    | raw JSON       |