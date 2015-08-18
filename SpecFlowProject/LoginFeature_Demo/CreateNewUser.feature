﻿Feature: Create new user
	In order to use SP I need to Login to SP
	As a Rolecreator
	I want to create a new user


Scenario: Create New User
	Given I login as a valid user with login is panviva and password is Burke6368
    And I am at User Management page
	When I press Action
	And I press New User
	And I have entered AdvAuthor, Adv, Author, test@panviva.com, password, password into the username, firstname, lastname, email, password, verify password
	And I press Save
	Then the result should be new user added

