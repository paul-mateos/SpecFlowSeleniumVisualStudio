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

@SPLive_ShowDocument
Scenario: SPUI-10229_SPLIVE_Show Document
    Given I want to "POST" a request
    And My webservice is "WebService.svc/rest/v1/Live/Doc"
	And I have a request body of 
	"""
	"AuthToken":{
	"""
	And I have a request body of 
	"""
		"AuthKey":"",
	"""
	And I have a request body of 
	"""
		"AuthType":1,
		"Instance":"localhost"
	},
	"DocumentID":536,
	"FindUserBy":0,
	"SessionID":2147483647,
	"Version":2,
	
	"""
	And I have a request body of 
	"""
	"User":"uName"
	"""
	  When waitBeforeRequest
	 When I send request
	 Then waitForResponse
	 And My result is response
	 And Delete user
	 
	#And I Have a xml Requestbody
	#"""
	#<ApiShowDocumentRequest xmlns="http://schemas.datacontract.org/2004/07/Panviva.SPUI.WebApiDto.Notifications">
	# <AuthToken>
	# """
	# And I Have a xml Requestbody
	# """
	#	<AuthKey xmlns="http://schemas.datacontract.org/2004/07/Panviva.SPUI.WebApiDto.Common"></AuthKey>
	#"""
	#And I Have a xml Requestbody
	#"""
	#	<AuthType xmlns="http://schemas.datacontract.org/2004/07/Panviva.SPUI.WebApiDto.Common">APIKey</AuthType>
	#	<Instance xmlns="http://schemas.datacontract.org/2004/07/Panviva.SPUI.WebApiDto.Common"></Instance>
	# </AuthToken>
	#<DocumentID>536</DocumentID>
	#<FindUserBy>ID</FindUserBy>
	#<SessionID>2147483647</SessionID>
	#<Version>0</Version>
	#"""
	#And I Have a xml Requestbody
	#"""
	#<User>""</User>
	# """
	 #And I Have a xml Requestbody
	# """
	#</ApiShowDocumentRequest>
	#""" 	
   