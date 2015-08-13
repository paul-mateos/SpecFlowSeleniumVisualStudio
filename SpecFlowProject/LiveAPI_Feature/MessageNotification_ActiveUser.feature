Feature: MessageNotification on logged in Viewer
	#- Configuration:

  #- Examples: Users
  #- | User Name   | Password | UserId | Description                           |
  #- | viewer      | viewer   | 123    | valid user with doc viewer permission |
  #- | viewer1     | viewer1  | 124    | valid user with doc viewer permission |
  #- | invalidUser |          |        | user doesn't exist                    |

  #-  Examples: Documents
  #-  | docuementId | Description |
  #-  |  111         | has 3 versions: 1.0, 2.0, 3.0 ; |
  #-                 version 1.0 has 1 page and 1 section, 1 achor
  #-                  version 2.0 has 2 pages and 2 sections with 1 section and 1 achor on each page, each page has different content 
  #-				   version 3.0 has 3 pages and 3 sections with 1 section  and 1 achor on each page, each page has different content
 
  # - Examples: Search documents
     # - backend should have the following documents setup: 
	 #-  search "ActionOnDoSearch2Results", then should have 2 docs returned
	 #-  search "ActionOnDoSearch1Result", then should have 1 doc returned	

Background:
    Given I login as a valid user with login is viewer and password is viewer
   
@MessageNotification_ActiveUser
Scenario: MessageNotification: No pending notification
	When there is no message notification
	Then message notification is invisible

@MessageNotification_ActiveUser
Scenario Outline: MessageNotification: OpenDocument Notification to active user
	Given a OpenDocument is issued with '<ApiKey>' '<FindUserBy>' '<User>' '<DocumentID>' '<Version>' '<SectionID>' '<AnchorName>' '<DateTime>' '<Description>' '<Actions>' 
	Then I should see notifications pending on support point
	When I click on notifications
	Then I should see the Notification on the top of list of unread messages
	And  I should see Type of Messages, Alert level, Time, and Message description for the notifcation
	When I click on the Notfication item
	Then I should see the Notification Item disapear from notification list
	Then I should be redirected to the '<PageContentToVerify>' of the document in viewer

	 #- a document should be created with at least 3 versions: 
	 #- version 1.0 has 1 page and 1 section, 1 achor
	 #- version 2.0 has 2 pages and 2 sections with 1 section and 1 achor on each page, each page has different content
	 #- version 3.0 has 3 pages and 3 sections with 1 section  and 1 achor on each page, each page has different content

   Examples: valid section
  | ApiKey | FindUserBy | User   | DocumentID | Version | SectionID | AnchorName | DateTime | Description | Actions | PageContentToVerify |
  | key    |            | viewer | 111        | 1.0     |           |            |          |             |         | 1.0_Pg1             |

  | key    |            | viewer | 111        | 1.0     |    1       |            |          |            | prompt  | 1.0_Pg1 |
  | key    |            | viewer | 111        | 2.0     |    2       |            |          |             | prompt  | 2.0_Pg2 |
  | key    |            | viewer | 111        | 3.0     |    3       |            |          |             | prompt  | 3.0_pg3 |
 


   Examples: Invalid section
    | ApiKey | FindUserBy | User   | DocumentID | Version | SectionID | AnchorName | DateTime | Description | Actions | PageContentToVerify |
    | key    |            | viewer | 111        | 1.0     |    2       |            |          |             | prompt  | 1.0_Pg1 |
	| key    |            | viewer | 111        | 2.0     |    3       |            |          |             | prompt  | 1.0_Pg1 |
	| key    |            | viewer | 111        | 3.0     |    4       |            |          |             | prompt  | 1.0_Pg1 |

	Examples: Different Actions
	| ApiKey | FindUserBy | User   | DocumentID | Version | SectionID | AnchorName | DateTime | Description | Actions | PageContentToVerify |
	| key    |            | viewer | 111        | 1.0     |            |            |          |             |           | 1.0_Pg1 |
    | key    |            | viewer | 111        | 1.0     |    1       |            |          |             | flash     | 1.0_Pg1 |
	| key    |            | viewer | 111        | 2.0     |    2       |            |          |             | load      | 2.0_Pg2 |
	| key    |            | viewer | 111        | 2.0     |    2       |            |          |             | maximise  | 2.0_Pg2 |
	| key    |            | viewer | 111        | 2.0     |    2       |            |          |             | load      | 2.0_Pg2 |
	| key    |            | viewer | 111        | 2.0     |    2       |            |          |             | prompt    | 2.0_Pg2 |

	Examples: Different Descriptions
	| ApiKey | FindUserBy | User   | DocumentID | Version | SectionID | AnchorName | DateTime | Description | Actions | PageContentToVerify |
	| key    |            | viewer | 111        | 1.0     |            |            |          |             |           | 1.0_Pg1 |
    | key    |            | viewer | 111        | 1.0     |    1       |            |          |             | flash     | 1.0_Pg1 |
	| key    |            | viewer | 111        | 2.0     |    2       |            |          |             | load      | 2.0_Pg2 |
	| key    |            | viewer | 111        | 2.0     |    2       |            |          |             | maximise  | 2.0_Pg2 |
	| key    |            | viewer | 111        | 2.0     |    2       |            |          |             | load      | 2.0_Pg2 |
	| key    |            | viewer | 111        | 2.0     |    2       |            |          |             | prompt    | 2.0_Pg2 |

	Examples: Different Anchors
	| ApiKey | FindUserBy | User   | DocumentID | Version | SectionID | AnchorName | DateTime | Description | Actions | PageContentToVerify |
	| key    |            | viewer | 111        | 1.0     |            |    pg1     |          |             |           | 1.0_Pg1 |
    | key    |            | viewer | 111        | 1.0     |    1       |    pg1     |          | same   |                | 1.0_Pg1|
	| key    |            | viewer | 111        | 1.0     |            |    pg2     |          | invalidArchor   |       | 1.0_Pg1|
	| key    |            | viewer | 111        | 2.0     |    2       |    pg1     |          | notsure   |             | Notsure|
	| key    |            | viewer | 111        | 3.0     |            |    pg3     |          |             |           | 3.0_Pg3 |

	Examples: Different FindUserBy
	| ApiKey | FindUserBy | User   | DocumentID | Version | SectionID | AnchorName | DateTime | Description | Actions | PageContentToVerify |
	| key    | name       | viewer | 111        | 1.0     |           |            |          |             |         | 1.0_Pg1             |
	| key    |   id       | 123    | 111        | 3.0     |           |            |          |             |           | 3.0_Pg3 |
	
	Examples: Multiple users
  | ApiKey | FindUserBy | User                | DocumentID | Version | SectionID | AnchorName | DateTime | Description | Actions | PageContentToVerify |
  | key    |            | viewer1, viewer     | 111        | 1.0     |           |            |          |             |         | 1.0_Pg1             |
  | key    |            | invalidUser, viewer | 111        | 3.0     | 3         |            |          |             | prompt  | 3.0_pg3             |
 
   
@MessageNotification_ActiveUser
Scenario Outline: MessageNotification: DoSearch Notification to active user
	Given a DoSearch is issued with '<ApiKey>' '<FindUserBy>' '<User>' '<Query>' '<Filters>' '<DateTime>' '<Description>' '<ShowFirstResult>' '<Actions>' 
	Then I should see notifications pending on support point
	When I click on notifications
	Then I should see the Notification on the top of list of unread messages
	And I should see Type of Messages, Alert level, Time, and Message description for the notifcation
	When I click on the Notfication item
	Then I should see the Notification Item disapear from notification list
	Then I should be redirected to the search result and should see <NumOfDocsShouldShow> docs

	 #- backend should have the following document setup: 
	 #-  search "ActionOnDoSearch2Results", then should have 2 docs returned
	 #-  search "ActionOnDoSearch1Result", then should have 1 doc returned

   Examples: search without filter
    | ApiKey | FindUserBy | User   | Query | Filters  | DateTime | Description  | ShowFirstResult  | Actions  | NumOfDocsShouldShow |
	| key    |            | viewer | ActionOnDoSearch2Results |   |  | search   | false  |   | 2 |
	| key    |            | viewer | ActionOnDoSearch1Results |   |  | search   | false  |   | 1 |

	Examples: search with filter
    | ApiKey | FindUserBy | User   | Query | Filters  | DateTime | Description  | ShowFirstResult  | Actions  | NumOfDocsShouldShow |
	#- need detailed information about filter values

	Examples: search with different FindUserBy
    | ApiKey | FindUserBy | User   | Query | Filters  | DateTime | Description  | ShowFirstResult  | Actions  | NumOfDocsShouldShow |
	| key    |   name       | viewer | ActionOnDoSearch2Results |   |  | search   | false  |   | 2 |
	| key    |   id         | 123 | ActionOnDoSearch1Results |   |  | search   | false  |   | 1 |

  Examples: search with showfirstresult
    | ApiKey | FindUserBy | User   | Query | Filters  | DateTime | Description  | ShowFirstResult  | Actions  | NumOfDocsShouldShow |
	| key    |            | viewer | ActionOnDoSearch2Results |   |  | search   | true  |    | 1 |
	| key    |            | viewer | ActionOnDoSearch1Results |   |  | search   | true  |    | 1 |
 Examples: Multiple users
    | ApiKey | FindUserBy | User               | Query                    | Filters | DateTime | Description | ShowFirstResult | Actions | NumOfDocsShouldShow |
    | key    |            | viewer1, viewer    | ActionOnDoSearch2Results |         |          | search      | true            |         | 1                   |
    | key    |            | invalidUser,viewer | ActionOnDoSearch1Results |         |          | search      | true            |         | 1                   |   
		
@MessageNotification_ActiveUser
Scenario Outline: MessageNotification: DoCshSearch Notification to active user
	Given a DoCshSearch is issued with '<ApiKey>' '<FindUserBy>' '<User>' '<Query>' '<Filters>' '<DateTime>' '<Description>' '<ShowFirstResult>' '<Actions>' 
	Then I should see notifications pending on support point
	When I click on notifications
	Then I should see the Notification on the top of list of unread messages
	And I should see Type of Messages, Alert level, Time, and Message description for the notifcation
	When I click on the Notfication item
	Then I should see the Notification Item disapear from notification list
	Then I should be redirected to the search result and should see <NumOfDocsShouldShow> docs

	 #- backend should have the following document setup: 
	 #-  search "ActionOnDoSearch2Results", then should have 2 docs returned
	 #-  search "ActionOnDoSearch1Result", then should have 1 doc returned

   Examples: search without filter
    | ApiKey | FindUserBy | User   | Query                    | Filters | DateTime | Description | ShowFirstResult | Actions | NumOfDocsShouldShow |
    | key    |            | viewer | ActionOnDoSearch2Results |         |          | search      | false           |         | 2                   |
    | key    |            | viewer | ActionOnDoSearch1Results |         |          | search      | false           |         | 1                   |

    Examples: search with showfirstresult
    | ApiKey | FindUserBy | User   | Query                    | Filters | DateTime | Description | ShowFirstResult | Actions | NumOfDocsShouldShow |
    | key    |            | viewer | ActionOnDoSearch2Results |         |          | search      | true            |         | 1                   |
    | key    |            | viewer | ActionOnDoSearch1Results |         |          | search      | true            |         | 1                   |

	Examples: search with different FindUserBy
    | ApiKey | FindUserBy | User   | Query                    | Filters | DateTime | Description | ShowFirstResult | Actions | NumOfDocsShouldShow |
    | key    | name       | viewer | ActionOnDoSearch2Results |         |          | search      | false           |         | 2                   |
    | key    | id         | 123    | ActionOnDoSearch1Results |         |          | search      | false           |         | 1                   |

	Examples: Multiple users
    | ApiKey | FindUserBy | User               | Query                    | Filters | DateTime | Description | ShowFirstResult | Actions | NumOfDocsShouldShow |
    | key    |            | viewer1, viewer    | ActionOnDoSearch2Results |         |          | search      | true            |         | 1                   |
    | key    |            | invalidUser,viewer | ActionOnDoSearch1Results |         |          | search      | true            |         | 1                   |



