Feature: WorkflowManagement_CreateNew
	In order create a new workflow
	As a workflow manager
	I want to create a workflow that does not exist

Background: Logon to SP and navigate to Workflow Manager
Given I have logged in to SP as a new "workflow_managers"
#And I Open SP Manager to Document Management : SupportPoint
And I Open SP Manager to Workflow Management : SupportPoint
#When I Navigate to the Workflow Page
And I am at Workflow Management page
#And I Open SP Manager to Workflow Management : SupportPoint

@Regression
@WorkflowManagement_CreateNew
Scenario: 1.1_Create New Workflow
	
	Given I click on Actions
	And I select New workflow from Actions
	When I enter the random workflow Name AutomationWorkflow
	#Workflow name wil be prefixed with a random number
	Then I click on the Save Button
	And I confirm the workflow Name
	And I Click on the Delete Button
	And I Confirm the Delete
	