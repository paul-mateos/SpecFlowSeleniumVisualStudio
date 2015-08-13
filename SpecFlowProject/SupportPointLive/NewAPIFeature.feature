Feature: Call to get Application Status
	In order to get the status of the application
	As a viewer
	I want to call Webservice to get application Status

	#Background: 
   # Given API definition at "http://qa-spui-b/WebService.svc/rest/v1/ApplicationStatus"


@mytag
Scenario: Get Application Status
	Given I have called webservice "http://qa-spui-b/WebService.svc/rest/v1/ApplicationStatus"
	When I executed
	Then response is recieved
