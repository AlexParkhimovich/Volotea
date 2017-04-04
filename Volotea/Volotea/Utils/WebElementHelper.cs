using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Volotea.Utils
{
    public static class WebElementHelper
    {
        public static IWebElement WaitUntilElementVisible(IWebDriver Driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            return Driver.FindElement(by);
        }

        public static void WaitAndClick(IWebDriver Driver, By by)
        {
            WaitUntilElementVisible(Driver, by).Click();
        }

        public static void WaitAndSendKeys(IWebDriver Driver, By by, string str)
        {
            WaitUntilElementVisible(Driver, by).SendKeys(str);
        }

        public static void MoveToElementAndClick(IWebDriver Driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(by));
            Actions act = new Actions(Driver);
            act.MoveToElement(Driver.FindElement(by)).Click();
            act.Perform();
        }

        public static IWebElement WaitUntilElementEnable(IWebDriver Driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(by));
            return Driver.FindElement(by);
        }

        public static bool IsElementPresent(IWebDriver Driver, By by)
        {
            try
            {
                WaitUntilElementVisible(Driver, by);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }
    }
}
