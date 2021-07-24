using APITest.API.Model;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using TestAPI.API;

namespace TestAPI.UITest
{
    [TestFixture]
    public class UI_Test
    {

        [Test]

        public void UI_PostOrderTestCase()
        {
            IWebDriver driver = new ChromeDriver();

            //Create Data Object
            BillingOrder expectedOrder = new BillingOrder
            {
                addressLine1 = "Test",
                addressLine2 = "test1",
                city = "QL",
                comment = "hello",
                email = "john@hotmail.com",
                firstName = "John",
                lastName = "Wojtowicz",
                phone = "9876543221",
                zipCode = "123456",
                itemNumber = 1,
                state = "AL"
            };


            BillingOrderPage orderPage = new BillingOrderPage(driver);
            orderPage.SubmitBillingorder(expectedOrder);

        }


    }
}
