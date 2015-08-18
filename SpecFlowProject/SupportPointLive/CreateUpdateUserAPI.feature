Feature: CreateUpdateUserAPI
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@createUser
Scenario: Import Users list file
		Given an API to create user "http://qa-spui-b/WebService.svc/rest_all/Users/CreateUpdate?"
		And request body as
		"""
		{	"Instance":"String content",
			"IsDisabled":true,
			"IsSsoUser":true,
			"RoleID":2147483647,
			"SessionID":"String content",
			"User":{
				"Email":"String content",
				"FirstName":"String content",
				"LastName":"String content",
				"Password":"String content",
				"UserID":"String content",
				"UserName":"String content"
				}
		}
			"""

		When request executed
		Then newuser created with response status as "ok" 
