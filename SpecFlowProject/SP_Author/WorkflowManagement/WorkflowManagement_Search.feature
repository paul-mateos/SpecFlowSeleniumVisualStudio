Feature: WorkflowManagement_Search
	In order create a new workflow
	As a workflow manager
	I want to create a workflow that does not exist

Background: Logon to SP and navigate to Workflow Manager
Given I have logged in to SP as a new "workflow_managers"
And I Open SP Manager
When I Navigate to the Workflow Page
Then I am at Workflow Management page

@Regression
@WorkflowManagement_Search
Scenario: 2.1_Search for workflow
	Given I search for workflow by name for Automation
	Then the search should return the record
