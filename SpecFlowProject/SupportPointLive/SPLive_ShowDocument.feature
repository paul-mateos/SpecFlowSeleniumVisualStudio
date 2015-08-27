Feature: SPLive_ShowDocument
	In order to show document in Viewer
	As an user
	I want to use SPLive API to show document to the viewer

#Configure API Key Enable in Admin Portal
#Setup Support with right Environment
Background: 
Given I have a new "authors"
And I have an apiKey
And I have logged into SupportPoint
#Given I have a new User

@mytag
Scenario: Show Document
    Given I want to "POST" a request
    And My webservice is "WebService.svc/rest/v1/Live/Doc"
	#And I have a request body of 
	#"""
	#"""
	#And I have a request body of 
	#"""
	#"AuthToken":{
	#"""
	#And I have a request body of 
	#"""
	#	"AuthKey":"",
	#"""
	#And I have a request body of 
	#"""
	#	"AuthType":APIKey,
	#	"Instance":"localhost"
	#},
	#"DocumentID":536,
	#"FindUserBy":ID,
	#"Version":0
	#
	#"""
	#And I have a request body of 
	#"""
	#"User":"uName",
	#"""
	And I Have a xml Requestbody
	"""
	<ApiShowDocumentRequest xmlns="http://schemas.datacontract.org/2004/07/Panviva.SPUI.WebApiDto.Notifications">
	 <AuthToken>
	 """
	 And I Have a xml Requestbody
	 """
		<AuthKey xmlns="http://schemas.datacontract.org/2004/07/Panviva.SPUI.WebApiDto.Common"></AuthKey>
	"""
	And I Have a xml Requestbody
	"""
		<AuthType xmlns="http://schemas.datacontract.org/2004/07/Panviva.SPUI.WebApiDto.Common">APIKey</AuthType>
		<Instance xmlns="http://schemas.datacontract.org/2004/07/Panviva.SPUI.WebApiDto.Common"></Instance>
	 </AuthToken>
	<DocumentID>536</DocumentID>
	<FindUserBy>ID</FindUserBy>
	<SessionID>2147483647</SessionID>
	<Version>0</Version>
	"""
	And I Have a xml Requestbody
	"""
	<User>""</User>
	 """
	 And I Have a xml Requestbody
	 """
	</ApiShowDocumentRequest>
	""" 	
    When I send request
    Then My result is response
	And waitForResponse