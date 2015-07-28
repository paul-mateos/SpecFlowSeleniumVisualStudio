Feature: Login
	In order to demostrate Specflow for Panviva
	As a tester
	I want to be able to automate login process

@login
Scenario: login 
	Given Support Portal is opened
	When I login as a valid user with login is panviva and password is Burke6368 
	Then I should be logged in successfully
	When I logout
	Then I should be logged out

