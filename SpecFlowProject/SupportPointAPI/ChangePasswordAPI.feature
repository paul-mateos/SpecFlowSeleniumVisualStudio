Feature: ChangePasswordAPI
	In order to change password for a various reasons including security/access
	As an administrator
	I want to be able to change my password

Scenario: ChangePassword 
            Given I want to "POST" a request
            And My webservice is "WebService.svc/rest_all/Users/ChangePassword"
			And I have path variables 
			|Key | |value|

			And 


            And I have a request body of 
			"""
				"Instance":"localhost",
				"NewPassword":"2",
				"OldPassword":"1",
				"SessionID":"SID"
			"""
            When I send request
            Then My result is response

