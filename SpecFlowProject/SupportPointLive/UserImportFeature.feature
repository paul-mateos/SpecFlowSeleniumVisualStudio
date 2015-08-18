Feature: UserImportFeature
	In order to import users csv file
	As an administrator
	I want to import file from supportpoint using  User/Import webservice

Background: 
Given environment testFolder name and import file
And I have session ID

@UserImport
	Scenario: Import Users list file
		Given an API definition "http://qa-spui-b/WebService.svc/rest_all/Users/Import?"
		And request type "sid" , "fn" 
		When the request is executed
		Then response status as "ok" , "Success" as "true"

