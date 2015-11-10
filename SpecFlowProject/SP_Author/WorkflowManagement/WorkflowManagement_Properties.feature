Feature: WorkflowManagement_Properties
	In order modify a workflow
	As a workflow manager
	I want to modify a workflow
#WorkflowApprover user needs to exist before the test

Background: Logon to SP and navigate to Workflow Manager
Given I have logged in to SP as a new "workflow_managers"
And I Open SP Manager to Workflow Management : SupportPoint


@Regression
@WorkflowManagement_Properties
Scenario: 3.1.1_Set Workflow Name
	Given I search for workflow by name for Automation
	And the search should click on the record
	When I enter the workflow Name Automation1
	Then I click on the Save Button
	And I enter the workflow Name Automation
	And I click on the Save Button
	And the search should return the record

@Regression
@WorkflowManagement_Properties
Scenario: 3.1.(2,3,4)_Delete Workflow
	Given I click on Actions
	And I select New workflow from Actions
	When I enter the random workflow Name AutomationWorkflow
	#Workflow name wil be prefixed with a random number
	Then I click on the Save Button
	And I confirm the workflow Name
	And I Click on the Delete Button
	And I Confirm the Delete

@Regression
@WorkflowManagement_Properties
Scenario: 3.2.1_Required Approvers Add User
	Given I click on Actions
	
	And I select New workflow from Actions
	And I enter the random workflow Name AutomationWorkflow
	#Workflow name will be prefixed with a random number
	And I click on the Save Button
	And I confirm the workflow Name
	When I press Details & Actions
	And I select Required approvers from Details & Actions
	And I Click on the Add user Button
	Then the User Selector is opened
	#And I create a new "authors" user with username "WorkflowApprover"
	And I search for user WorkflowApprover in User Selector
	And I select the record WorkflowApprover using column Username from the User Selector table
	And I Click on the Add user selector Button
	And I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete Button
	And I Confirm the Delete

@Regression	
@WorkflowManagement_Properties
Scenario: 3.2.2_Required Approvers Add Role
	Given I click on Actions
	And I select New workflow from Actions
	And I enter the random workflow Name AutomationWorkflow
	#Workflow name wil be prefixed with a random number
	And I click on the Save Button
	And I confirm the workflow Name
	When I press Details & Actions
	And I select Required approvers from Details & Actions
	And I Click on the Add role Button
	Then the Role Selector is opened
	And I search for role for authors
	And I select the record authors using column Role from the Role Selector table
	And I Click on the Add roles Button
	And I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete Button
	And I Confirm the Delete
	