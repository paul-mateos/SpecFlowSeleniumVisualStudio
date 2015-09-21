Feature: WorkflowManagement_Properties
	In order modify a workflow
	As a workflow manager
	I want to modify a workflow

Background: Logon to SP and navigate to Workflow Manager
Given I have logged in to SP as a new "workflow_managers"
And I Open SP Manager
When I Navigate to the Workflow Page
Then I am at Workflow Management page

@Regression
@3.1.1_WorkflowManagement_Properties
Scenario: Set Workflow Name
	Given I search for workflow by name for Automation
	And the search should click on the record
	When I enter the workflow Name Automation1
	Then I click on the Save Button
	And I enter the workflow Name Automation
	And I click on the Save Button
	And the search should return the record
