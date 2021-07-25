using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace BDD_BillingOrder
{
    [Binding]
    public class BillingOrderSteps
    {
        IWebDriver browser;
        private readonly ScenarioContext scenarioContext;

        public BillingOrderSteps(ScenarioContext scenarioContext)
        { 
            this.scenarioContext = scenarioContext;
        }

        [Given(@"Open Billing Order Page")]
        public void GivenOpenBillingOrderPage()
        {
            browser = (IWebDriver)scenarioContext["ChromeDriver"];
            string username= (String)scenarioContext["Username"];
            string password = (String)scenarioContext["password"]; ;

            browser.Url = "http://google.com";
        }

        [When(@"Enter user details")]
        public void WhenEnterUserDetalis()
        {

             
        }

        //[And(@"Submit user details")]
        //public void AndSubmitUserDetails()
        //{

        //}

        [Then("All details submitted successfully")]
        public void ThenAllDetailsSubmitted()
        {
           
        }
    }
}
