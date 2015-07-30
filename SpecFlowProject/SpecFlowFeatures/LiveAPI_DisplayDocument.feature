Feature: LiveAPI Display Document
	In order to test LiveAPI which enables SupportPoint Desktop to respond proactively to desktop events
	As a tester
	I want to be able to issue LiveAPI calls and check SupportPoint desktop for result

@mytag
Scenario: Display a document to a logged in user
	Given Support Portal is opened
	#-And I login as a valid user with login is aa and password is aa
	When issues DisplayDocuementAPI to display DocumentId=2223 to User Name in aa, bb,cc
	And SectionID=222
	And AnchorName=achorName
	Then documentId=2223 should be displayed in SupportPoint Viewer

Scenario: Display an invalid document
	Given Support Portal is opened
	#-And I login as a valid user with login is aa and password is aa
	When issues DisplayDocuementAPI to display DocumentId=3555 to User Name in aa, bb,cc
	And SectionID=222
	And AnchorName=achorName
	Then should get response with StatusCode=400
