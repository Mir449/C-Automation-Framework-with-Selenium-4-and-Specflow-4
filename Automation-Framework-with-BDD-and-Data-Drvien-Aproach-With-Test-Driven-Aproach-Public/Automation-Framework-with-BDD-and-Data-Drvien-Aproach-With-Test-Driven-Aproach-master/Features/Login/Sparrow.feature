Feature: UI loogin

@02_core
Scenario: Connecting Core
Given the test case title is 'title'
And Core is connected


@01_login @DataSource:Data/login.xlsx
Scenario:Loging in UI
Given the test case title is '<title>'
Given I am on the page URL "UI"
And I am giving '<username>' in 'Login_userid'
And I am giving '<password>' in 'Login_password'
When I am clicking on 'Login_btn'
And I am verifying the page loaded successfully
And I am clicking on 'Security_locator'
And I am clicking on 'Security_Roles'
And I am clicking on 'Security_Roles_Add'
And I am giving '<role_id>' in 'Security_Roles_ID'
And I am giving '<name>' in 'Security_Roles_Name'
And I am giving '<description>' in 'Security_Roles_Description'
And I am "clicking" on "Security_Roles_Add_Permissions_Configuration"
And I am "clicking" on "Security_Roles_Add_Permissions_Institution"
And I am "clicking" on "Security_Roles_Add_Permissions_Customer_Management"
And I am "selecting" on "<select_module>"
And I am clicking on 'Security_Users_Add_Application-user-Save'

