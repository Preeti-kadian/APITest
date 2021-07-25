using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BDD_BillingOrder
{
    [Binding]
    public sealed class Hooks
    { 
      public IWebDriver Driver;

    private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver = new ChromeDriver();
            _scenarioContext["ChromeDriver"] = Driver;  //making driver common to be a
            _scenarioContext["Username"] = "admin";
            _scenarioContext["password"]= "user";

            Driver.Manage().Window.Maximize();

        }

        [AfterScenario]
        public void AfterScenario()
        {
            
        }

       

        [BeforeFeature]
        public static void BeforeFeature()
        {
            // TODO: implement logic that has to run before executing each feature
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            // TODO: implement logic that has to run after executing each feature
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // TODO: implement logic that has to run before the entire test run
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            // TODO: implement logic that has to run after the entire test run
        }
    }
}
