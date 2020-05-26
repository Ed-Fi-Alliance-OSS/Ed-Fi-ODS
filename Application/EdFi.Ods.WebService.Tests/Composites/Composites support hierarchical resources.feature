@Composites @HierarchicalComposite @Ignore
Feature: Composites support hierarchical resources

Background: 
    Given the subject of the request is a new "Assessment"
    And ObjectiveAssessments are organized for the subject in a hierarchy as follows:
    | Code | Parent | Description  | Related Learning Objectives         |
    | 1    |        | Root 1       | Objective 1, Objective 11           |
    | 2    | 1      | Child 1a     | Objective 1a, Objective 11a         |
    | 3    | 1      | Child 1b     | Objective 1b, Objective 11b         |
    | 4    | 3      | Child 1b(i)  | Objective 1b(i), Objective 11b(i)   |
    | 5    | 3      | Child 1b(ii) | Objective 1b(ii), Objective 11b(ii) |
    | 6    |        | Root 2       | Objective 2, Objective 22           |
    | 7    | 6      | Child 2a     | Objective 2a, Objective 22a         |
    | 8    | 6      | Child 2b     | Objective 2b, Objective 22b         |
    | 9    | 8      | Child 2b(i)  | Objective 2b(i), Objective 22b(i)   |
    | 10   | 8      | Child 2b(ii) | Objective 2b(ii), Objective 22b(ii) |
    #    1          6
    #   / \        / \
    #  2   3      7   8
    #     / \        / \
    #    4   5      9  10

Scenario: Composite includes a hierarchical child resource
    When a GET (by id) request is submitted to the "AssessmentWithHierarchicalObjectiveAssessment" composite
    Then the hierarchical response model at path "objectiveAssessments" should contain the following members (for the "description" property):
    | Logical Path                     | Expected Values                     |
    | Root 1                           | Objective 1, Objective 11           |
    | Root 1 / Child 1a                | Objective 1a, Objective 11a         |
    | Root 1 / Child 1b                | Objective 1b, Objective 11b         |
    | Root 1 / Child 1b / Child 1b(i)  | Objective 1b(i), Objective 11b(i)   |
    | Root 1 / Child 1b / Child 1b(ii) | Objective 1b(ii), Objective 11b(ii) |
    | Root 2                           | Objective 2, Objective 22           |
    | Root 2 / Child 2a                | Objective 2a, Objective 22a         |
    | Root 2 / Child 2b                | Objective 2b, Objective 22b         |
    | Root 2 / Child 2b / Child 2b(i)  | Objective 2b(i), Objective 22b(i)   |
    | Root 2 / Child 2b / Child 2b(ii) | Objective 2b(ii), Objective 22b(ii) |

# -------------------------------------------------------------------------------------------
# NOTE: If support for hierarchical base resources is added, the following test should pass
# -------------------------------------------------------------------------------------------
# Scenario: Composite uses a hierarchical resource as its base resource
#    When the subject of the request is the ObjectiveAssessment with description of "Root 2"
#    And a GET (by id) request is submitted to the "HierarchicalObjectiveAssessment" composite
#    Then the hierarchical response model should contain the following members (based on "description"):
#    | Logical Path                     |
#    | Root 2                           |
#    | Root 2 / Child 2a                |
#    | Root 2 / Child 2b                |
#    | Root 2 / Child 2b / Child 2b(i)  |
#    | Root 2 / Child 2b / Child 2b(ii) |
#