Feature: ChangePasswordAPI
	In order to change password for a various reasons including security/access
	As an administrator
	I want to be able to change my password

Scenario: ChangePassword 
            Given I want to "POST" a request
            And My webservice is "WebService.svc/rest_all/Users/ChangePassword"
			#set Empty values to create values in the background
			And I have path variables 
			|Key | |value|
			# Empty fields for username and password to use Environment Credentials
			And I have SessioID with username as "ac2" and password as "1"
			 # Create Empty request body when there is no request body
            And I have a request body of
			"""
			"SessionID":"",
			"""
			
			And I have a request body of
			"""
				"Instance":"localhost",
				"NewPassword":"2",
				"OldPassword":"1",
			"""
			When I send request
            Then My result is response