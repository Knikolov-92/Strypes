Feature: Search

Scenario: Search by a keyword
	Given the 'Home' page has been opened
	When a search by keyword "developer" is made
	Then the search results for "developer" are displayed
    And the search results contain the keyword "developer"
