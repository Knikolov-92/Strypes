Feature: Blogs

Scenario: View recent news
	Given the 'Blogs' page has been opened by navigating from navigation bar
	When the blogs sub-tab 'News' is opened
	Then the number of displayed blogs is greater than or equal to '7'
