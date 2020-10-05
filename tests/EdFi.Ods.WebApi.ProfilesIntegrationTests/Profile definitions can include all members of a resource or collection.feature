@API 
Feature: Profile definitions can include all members of a resource or collection

Scenario Outline: The Read content type includes all properties of a resource
    Given the caller is using the "Test-Profile-Resource-IncludeAll" profile
    When a GET (by id) request is submitted using <call mechanism> to schools with an accept header content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the response model should contain all of the resource model's properties

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Write content type includes all properties of a resource
    Given the caller is using the "Test-Profile-Resource-IncludeAll" profile
    When a PUT request with a completely updated resource is submitted using <call mechanism> to schools with a request body content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the persisted entity model should have unmodified primary key values
    And every non-primary key value on the entity should be changed

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Read content type includes all properties of a child collection
    Given the caller is using the "Test-Profile-Resource-Child-Collection-IncludeAll" profile
    When a GET (by id) request is submitted using <call mechanism> to schools with an accept header content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the number of properties on the response model's addresses collection items should reflect the number of properties on the full EducationOrganizationAddress resource model

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Write content type includes all properties of a child collection
    Given the caller is using the "Test-Profile-Resource-Child-Collection-IncludeAll" profile
    When a PUT request with a completely updated resource with preserved child collections is submitted using <call mechanism> to schools with a request body content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the only values not changed on the entity model's EducationOrganizationInternationalAddresses collection items should be the contextual primary key values of [AddressTypeDescriptor, AddressTypeDescriptorId]
    
Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Read content type includes all properties of a derived association
    Given the caller is using the "StudentSpecialEducationProgramAssociation-Derived-Association-IncludeAll" profile
    When a GET (by id) request is submitted using <call mechanism> to studentSpecialEducationProgramAssociations with an accept header content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the response model should contain all of the resource model's properties

Examples:
    | call mechanism |
    | raw JSON       |

Scenario Outline: The Write content type includes all properties of a  derived association
    Given the caller is using the "StudentSpecialEducationProgramAssociation-Derived-Association-IncludeAll" profile
    When a PUT request with a completely updated resource is submitted using <call mechanism> to studentSpecialEducationProgramAssociations with a request body content type of the appropriate value for the profile in use
    Then the response should indicate success
    And the persisted entity model should have unmodified primary key values
    And every non-primary key value on the entity should be changed

Examples:
    | call mechanism |
    | raw JSON       |
