Feature: UserImportFeature
	In order to import users csv file
	As an administrator
	I want to import file from supportpoint using  User/Import webservice

Background: 
Given environment testFolder name and import file
And I have session ID

@UserImport
Scenario:  Post: Import Users 
            Given I want to "POST" a request
            And My webservice is "WebService.svc/rest_all/Users/Import"
			And I have path variables 
			| Key |  | Value  |
			| sid |  |  |
			| fn  |  |  |
            And I have a request body of 
			"""
			"""

            When I send request
            Then My result is response