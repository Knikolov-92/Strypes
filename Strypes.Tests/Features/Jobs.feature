Feature: Jobs

Scenario: View job description
	Given the 'Careers' page has been opened
	When a search for open positions in "Technology" department is made
    And the open position "Automation Quality Assurance Engineer" is viewed
	Then the job description for the position "Automation Quality Assurance Engineer" is displayed
