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

@Regression
@3.1(2,3,4)_WorkflowManagement_Properties
Scenario: Delete Workflow
	Given I click on Actions
	And I select New workflow from Actions
	When I enter the random workflow Name AutomationWorkflow
	#Workflow name wil be prefixed with a random number
	Then I click on the Save Button
	And I confirm the workflow Name
	And I Click on the Delete Button
	And I Confirm the Delete

@3.2.1_WorkflowManagement_Properties
Scenario: Required Approvers Add User
	Given I click on Actions
	And I select New workflow from Actions
	And I enter the random workflow Name AutomationWorkflow
	#Workflow name wil be prefixed with a random number
	And I click on the Save Button
	And I confirm the workflow Name
	When I press Details & Actions
	And I select Required approvers from Details & Actions
	And I Click on the Add user Button
	Then the User Selector is opened
	And I search for user by User for aut10526
	#And I Click on the Delete Button
	#And I Confirm the Delete