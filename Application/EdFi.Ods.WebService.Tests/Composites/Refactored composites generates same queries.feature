@Composites
Feature: Refactored composites generates same queries

# =====================================================================================
# NOTE: Do not attempt to convert these into a ScenarioOutline.  They use ApprovalTests
# which works by writing out *.Received.txt files to disk (which are then compared to
# the *.Approved.txt files automatically).  ApprovalTests needs a distinct test method 
# name for each test in order to create distinct output files for comparison.
# =====================================================================================

Scenario:  School by Id is executed
    When the "School by Id" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Schools by Local Education Agency (Id) is executed
    When the "Schools by Local Education Agency (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Schools by Section (Id) is executed
    When the "Schools by Section (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Schools by Staff (Id) is executed
    When the "Schools by Staff (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Section by Id is executed
    When the "Section by Id" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Sections by Local Education Agency (Id) is executed
    When the "Sections by Local Education Agency (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Sections by School (Id) is executed
    When the "Sections by School (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Sections by Staff (Id) is executed
    When the "Sections by Staff (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Staff by Id is executed
    When the "Staff by Id" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Staffs by Local Education Agency (Id) is executed
    When the "Staffs by Local Education Agency (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Staffs by School (Id) is executed
    When the "Staffs by School (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Staffs by Section (Id) is executed
    When the "Staffs by Section (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Student by Id is executed
    When the "Student by Id" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Students by Local Education Agency (Id) is executed
    When the "Students by Local Education Agency (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Students by School (Id) is executed
    When the "Students by School (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Students by Section (Id) is executed
    When the "Students by Section (Id)" request is submitted
    Then the queries generated should all match previously approved values

Scenario:  Students by Staff (Id) is executed
    When the "Students by Staff (Id)" request is submitted
    Then the queries generated should all match previously approved values