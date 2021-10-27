@Composites
Feature: Composite resources can be defined through xml	

# Base -> No Properties
Scenario: Composite base resource contains no properties
    Given the subject of the request is a StudentEducationOrganizationAssociation
    When a GET (by id) request is submitted to the "BaseResourceCanContainNoProperty" composite
    Then the queries generated should all match previously approved values

# Display names applied to all members
Scenario: Composite members include display names
    Given the subject of the request is a school with student and staff associations
    When a GET (by id) request is submitted to the "MembersIncludeDisplayName" composite
    Then the queries generated should all match previously approved values

# Base -> Collections
Scenario: Composite includes specific collections
    Given the subject of the request is a StudentEducationOrganizationAssociation
    When a GET (by id) request is submitted to the "StudentEducationOrganizationAssociationCollection" composite
    Then the queries generated should all match previously approved values

# Base -> Linked Collections
Scenario: Composite includes specific linked collections
    Given the subject of the request is a student with a StudentAcademicRecord
    When a GET (by id) request is submitted to the "StudentLinkedCollection" composite
    Then  the queries generated should all match previously approved values

# Base -> Properties
Scenario: Composite includes specific properties
    Given the subject of the request is a student with values in all name properties
    When a GET (by id) request is submitted to the "StudentProperty" composite
    Then the queries generated should all match previously approved values

# Base -> Unflattened Reference
Scenario: Composite includes unflattened reference
    Given the subject of the request is a StudentSchoolAssociation
    When a GET (by id) request is submitted to the "StudentSchoolUnflattenedReference" composite
    Then the queries generated should all match previously approved values

#Base -> Flattened Reference
Scenario: Composite includes flattened reference
    Given the subject of the request is a StudentSchoolAssociation
    When a GET (by id) request is submitted to the "StudentSchoolFlattenedReference" composite
    Then the queries generated should all match previously approved values

# Flattened Reference -> Properties
Scenario: Composite includes specific references with flattened properties
    Given the subject of the request is a StudentSchoolAssociation with StudentAssessment
    When a GET (by id) request is submitted to the "StudentFlattenedReferencesWithProperty" composite
    Then  the queries generated should all match previously approved values

# Unflattened Reference -> Properties
Scenario: Composite includes specific references with properties
    Given the subject of the request is a StudentSchoolAssociation with StudentAssessment
    When a GET (by id) request is submitted to the "StudentUnflattenedReferenceWithProperty" composite
    Then the queries generated should all match previously approved values

# Flattened Reference -> Flattened Reference
Scenario: Composites include flattened references with flattened references
    Given the subject of the request is a StudentSchoolAssociation with School
    When a GET (by id) request is submitted to the "StudentFlattenedReferenceWithFlattenedReference" composite
    Then the queries generated should all match previously approved values

#Linked Collection -> Linked Collection
Scenario: Composite includes linked collection containing a linked collection
    Given the subject of the request is a student with a StudentAcademicRecord
    When a GET (by id) request is submitted to the "StudentLinkedCollectionWithLinkedCollection" composite
    Then the queries generated should all match previously approved values

#Linked Collection -> Flattened Reference
Scenario: Composite includes linked collection containing flattened reference
    Given the subject of the request is a student with a StudentAcademicRecord
    When a GET (by id) request is submitted to the "StudentLinkedCollectionWithFlattenedPropertyReference" composite
    Then the queries generated should all match previously approved values

# Linked Collection -> Unflattened Reference
Scenario: Composite includes linked collection containing unflattened reference
    Given the subject of the request is a student with a StudentAcademicRecord
    When a GET (by id) request is submitted to the "StudentLinkedCollectionWithUnflattenedReference" composite
    Then the queries generated should all match previously approved values

# Unflattened Reference -> Linked Collection
Scenario: Composite includes flattened reference with linked collection
    Given the subject of the request is a StudentSchoolAssociation with StudentAssessment
    When a GET (by id) request is submitted to the "StudentUnflattenedReferenceWithLinkedCollection" composite
    Then the queries generated should all match previously approved values

# Unflattened Reference -> Unflattened Reference
Scenario: Composite includes unflattened reference with unflattened reference
    Given the subject of the request is a StudentSchoolAssociation with School
    When a GET (by id) request is submitted to the "StudentUnflattenedReferenceWithUnflattenedReference" composite
    Then the queries generated should all match previously approved values

#Collection -> Properties 
Scenario: Composite includes collection with properties
    Given the subject of the request is a StudentEducationOrganizationAssociation
    When a GET (by id) request is submitted to the "StudentEducationOrganizationAssociationCollectionWithProperty" composite
    Then the queries generated should all match previously approved values

#Collection -> Collection
Scenario: Composite includes collection with collection
    Given the subject of the request is a StudentAssessment with ObjectAssessmentScoreResults
    When a GET (by id) request is submitted to the "StudentCollectionWithCollection" composite
    Then the queries generated should all match previously approved values

# Collection -> Unflattened reference
Scenario: Composite includes collection with unflattened reference
    Given the subject of the request is a StudentAssessment with StudentAssessmentStudentObjectiveAssessment
    When a GET (by id) request is submitted to the "StudentCollectionWithUnflattenedReference" composite
    Then the queries generated should all match previously approved values

# Collection -> Flattened reference
Scenario: Composite includes collection with flattened reference
    Given the subject of the request is a StudentAssessment with StudentAssessmentStudentObjectiveAssessment
    When a GET (by id) request is submitted to the "StudentCollectionWithFlattenedReference" composite
    Then the queries generated should all match previously approved values

# Unflattened reference -> flattened reference
Scenario: Composite includes unflattened reference with flattened reference
    Given the subject of the request is a StudentSchoolAssociation with School
    When a GET (by id) request is submitted to the "StudentUnflattenedReferenceWithflattenedReference" composite
    Then the queries generated should all match previously approved values

#Unflattened reference -> collection
Scenario: Composite includes unflattened reference with collection
    Given the subject of the request is a StudentSchoolAssociation with School
    When a GET (by id) request is submitted to the "StudentUnflattenedReferenceWithCollection" composite
    Then the queries generated should all match previously approved values

#Linked collection -> properties
@ignore
Scenario: Composite includes linked collection with properties
    Given the subject of the request is a student with a StudentSchoolAssociation
    When a GET (by id) request is submitted to the "StudentLinkedCollectionWithProperty" composite
    Then the queries generated should all match previously approved values

# Linked collection -> collection
Scenario: Composite includes linked collection with collection
    Given the subject of the request is a student with a StudentEducationOrganizationAssociation
    When a GET (by id) request is submitted to the "StudentLinkedCollectionWithCollection" composite
    Then the queries generated should all match previously approved values

# Flattened Reference -> Unflattened Reference
Scenario: Composites include flattened references with unflattened references
    Given the subject of the request is a StudentSchoolAssociation with School
    When a GET (by id) request is submitted to the "StudentFlattenedReferenceWithUnflattenedReference" composite
    Then the queries generated should all match previously approved values

# Flattened Reference -> Linked Collection
Scenario: Composites include flattened references with linked collection
    Given the subject of the request is a StudentSchoolAssociation with School and StudentAssessment
    When a GET (by id) request is submitted to the "StudentFlattenedReferenceWithLinkedCollection" composite
    Then the queries generated should all match previously approved values

#Flattened Reference -> Collection
Scenario: Composites include flattened references with collection
    Given the subject of the request is a StudentSchoolAssociation with School
    When a GET (by id) request is submitted to the "SchoolFlattenedReferenceWithCollection" composite
    Then the queries generated should all match previously approved values
