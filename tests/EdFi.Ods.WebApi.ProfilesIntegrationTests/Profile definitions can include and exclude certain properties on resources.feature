@API 
Feature: Profile definitions can include and exclude certain properties on resources

Scenario Outline: The Read content type only includes certain properties
    Given the caller is using the "Test-Profile-Resource-IncludeOnly" profile
    When a GET (by id) request is submitted using <call mechanism> to schools with an accept header content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the response model should contain the id and the primary key properties of [schoolId]
    And the response model should contain the explicitly included properties of [nameOfInstitution, operationalStatusDescriptor, charterApprovalSchoolYearTypeReference, schoolTypeDescriptor, administrativeFundingControlDescriptor, addresses, schoolCategories]
    And the number of properties on the response model should reflect the number of included properties plus the primary key properties

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Read content type only excludes certain properties
    Given the caller is using the "Test-Profile-Resource-ExcludeOnly" profile
    When a GET (by id) request is submitted using <call mechanism> to schools with an accept header content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the response model should contain the id and the primary key properties of [schoolId]
    And the response model should not contain the explicitly excluded properties of [nameOfInstitution, operationalStatusType, charterApprovalSchoolYearTypeReference, schoolTypeDescriptor, administrativeFundingControlDescriptor, addresses, schoolCategories]
    And the number of properties on the response model should reflect the number of properties on the full School resource model less the explicitly excluded ones

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Write content type only includes certain properties
    Given the caller is using the "Test-Profile-Resource-IncludeOnly" profile
    When a PUT request with a completely updated resource is submitted using <call mechanism> to schools with a request body content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the persisted entity model should have unmodified primary key values
    And the only values changed should be the explicitly included values

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Write content type only excludes certain properties
    Given the caller is using the "Test-Profile-Resource-ExcludeOnly" profile
    When a PUT request with a completely updated resource is submitted using <call mechanism> to schools with a request body content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the persisted entity model should have unmodified primary key values
    And the persisted entity model should not have the new values assigned to the explicitly excluded properties 
    And the only values not changed should be the explicitly excluded values, the id, and the primary key values

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Read content only includes certain properties from derived association
    Given the caller is using the "StudentSpecialEducationProgramAssociation-Derived-Association-IncludeOnly" profile
    When a GET (by id) request is submitted using <call mechanism> to studentSpecialEducationProgramAssociations with an accept header content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the response model should contain the id and the primary key properties of [beginDate, educationOrganizationReference, programReference, studentReference]
    And the response model should contain the explicitly included properties of [specialEducationSettingDescriptor, specialEducationHoursPerWeek, endDate, reasonExitedDescriptor]
	And the number of properties on the response model should reflect the number of included properties plus the primary key properties
	  
Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Read content type only excludes certain properties from derived association
    Given the caller is using the "StudentSpecialEducationProgramAssociation-Derived-Association-ExcludeOnly" profile
    When a GET (by id) request is submitted using <call mechanism> to studentSpecialEducationProgramAssociations with an accept header content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the response model should contain the id and the primary key properties of [beginDate, educationOrganizationReference, programReference, studentReference]
    And the response model should not contain the explicitly excluded properties of [specialEducationSettingDescriptor, specialEducationHoursPerWeek, endDate, reasonExitedDescriptor]
    And the number of properties on the response model should reflect the number of properties on the full StudentSpecialEducationProgramAssociation resource model less the explicitly excluded ones

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Write content type only includes certain properties from derived association
    Given the caller is using the "StudentSpecialEducationProgramAssociation-Derived-Association-IncludeOnly" profile
    When a PUT request with a completely updated resource is submitted using <call mechanism> to studentSpecialEducationProgramAssociations with a request body content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the persisted entity model should have unmodified primary key values
    And the only values changed should be the explicitly included values

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Write content type only excludes certain properties from derived association
    Given the caller is using the "StudentSpecialEducationProgramAssociation-Derived-Association-ExcludeOnly" profile
    When a PUT request with a completely updated resource is submitted using <call mechanism> to studentSpecialEducationProgramAssociations with a request body content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the persisted entity model should have unmodified primary key values
    And the persisted entity model should not have the new values assigned to the explicitly excluded properties 
    And the only values not changed should be the explicitly excluded values, the id, and the primary key values

Examples:
    | call mechanism |
    | raw JSON       |