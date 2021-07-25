using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD_BillingOrder
{
    public static class WebDriverExtension
    {
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
        public static readonly TimeSpan ImplicitWait = TimeSpan.FromSeconds(3);
        public static readonly TimeSpan NoWait = TimeSpan.Zero;

        public static IWebElement FindByWithWait(this IWebDriver driver, By by)
        {
            driver.WaitUntilElementIsDisplay(by);
            return driver.FindElement(by);

        }

        public static bool WaitUntilElementIsDisplay(this IWebDriver driver, By by, TimeSpan? timeout = null)
        {
            var wait = new WebDriverWait(driver, timeout ?? DefaultTimeout);

            try
            {
                return wait.Until(d => d.FindElement(by).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return wait.Until(d => d.FindElement(by).Displayed);
            }
        }

        public static void TakeScreenshot(this IWebDriver driver, string path)
        {
            Directory.CreateDirectory(path);

            var testName = TestContext.CurrentContext.Test.Name;
            var correctTestName = string.Join("", testName.Split(Path.GetInvalidFileNameChars()));
            var fileName = $"{Path.Combine(path, correctTestName)}_{DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss")}.png";
            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();

            screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);


        }
    }
}
