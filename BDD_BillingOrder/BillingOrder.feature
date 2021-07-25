Feature: BillingOrder
	
	
@mytag
Scenario: Create Billing order
	Given Open Billing Order Page
    When Enter user details
	And Submit user details
	Then All details submitted successfully

@mytag
Scenario: Gmail Login
	Given Open Gmail Login Page
    When User Enter Valid Creential
	And Submit User Details
	Then Successful Login into account