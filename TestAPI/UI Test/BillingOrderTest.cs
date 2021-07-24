// Generated by Selenium IDE

using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using APITest.API.Model;

[TestFixture]
public class BillingOrderPage
{
    private IWebDriver driver;

    public BillingOrderPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    [Test]
    public void SubmitBillingorder(BillingOrder order)
    {
        driver.Navigate().GoToUrl("http://qaauto.co.nz/billing-order-form/");
        driver.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).Click();
        driver.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).SendKeys("Testing");
        driver.FindElement(By.Id("wpforms-submit-locked-24")).Click();
        Thread.Sleep(1000);
        driver.FindElement(By.Id("wpforms-24-field_0")).SendKeys(order.firstName);
        driver.FindElement(By.Id("wpforms-24-field_0-last")).SendKeys(order.lastName);
        driver.FindElement(By.Id("wpforms-24-field_1")).SendKeys(order.email);
        driver.FindElement(By.Id("wpforms-24-field_2")).SendKeys(order.phone);
        driver.FindElement(By.Id("wpforms-24-field_3")).SendKeys(order.addressLine1);
        driver.FindElement(By.Id("wpforms-24-field_3-address2")).SendKeys(order.addressLine2);
        driver.FindElement(By.Id("wpforms-24-field_3-city")).SendKeys(order.city);
        driver.FindElement(By.Id("wpforms-24-field_3-postal")).SendKeys(order.zipCode);
        {
            var dropdown = driver.FindElement(By.Id("wpforms-confirmation-24"));
            dropdown.FindElement(By.XPath("//option[.='Iowa']")).Click();
        }
        driver.FindElement(By.Id("wpforms-24-field_4-container")).Click();
        driver.FindElement(By.XPath("//*[@id='wpforms-24-field_4']/li[2]/label")).Click();


        driver.FindElement(By.Id("wpforms-24-field_6")).SendKeys("Order created");
        var elements = driver.FindElements(By.CssSelector("#wpforms-confirmation-24 > p"));
        driver.FindElement(By.Id("wpforms-form-page-page")).Click();
        driver.FindElement(By.Id("wpforms-submit-24")).Click();
    }
}
