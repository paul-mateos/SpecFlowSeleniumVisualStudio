Feature: Login_Demo
	any test environment or prerequisite goes here:
	prerequisite: 
	 The following two users should be valid
	  viewer/viewer 
	  viewer1/viewer1

Background: 
    Given Support Portal is opened
	And just demo another Given

@login
Scenario: Demo login Scenario
	When I login as a valid user with login is viewer and password is viewer
	And just demo another When
	Then I should be logged in successfully
	And just demo another Then 
	When I logout
	Then I should be logged out

@login
Scenario Outline: Demo Login Outline Test
	When I login as a valid user with login is <UserName> and password is <Password> 
	Then I should be logged in successfully
	When I logout
	Then I should be logged out
	
	Examples:
	| UserName | Password |
	| viewer   | viewer   |
	| viewer1  | viewer1  |