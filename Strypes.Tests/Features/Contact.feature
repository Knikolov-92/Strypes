Feature: Contact

Scenario Outline: Submit contact form with invalid email
	Given the 'Contact' page has been opened
	When the contact form data is submitted
    | First Name  | Last Name  | Email   | Company Name  | Message   | Agree with Policy | Subscribe   |
    | <firstName> | <lastName> | <email> | <companyName> | <message> | <agreeWithPolicy> | <subscribe> |
	Then the contact form error message "<errorMessage>" for invalid email is displayed

    Examples:
    | firstName | lastName | email              | companyName      | message     | agreeWithPolicy | subscribe | errorMessage                         |
    | Ivan      | Ivanov   |                    | The best Company | Hello World | false           | false     | Please complete this required field. |
    | Ivan      | Ivanov   | ivancho            | The best Company | Hello World | true            | true      | Email must be formatted correctly.   |
    | Ivan      | Ivanov   | ala-bala@olele.nok | The best Company | Hello World | false           | false     | Please enter a valid email address.  |