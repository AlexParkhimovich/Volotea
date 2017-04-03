using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class MainPage : BasePage
    {
        private string depAirportXPath = "//input[@placeholder = 'Please choose departure airport']";
        private string depXPath = "//a[contains(text(), 'SXB')]";
        private string desAirportXPath = "//input[@placeholder = 'Please choose destination airport']";
        private string desXPath = "//a[contains(text(), 'NCE')]";
        private string findFlightsXPath = "//a[contains(text(), 'FIND FLIGHTS')]";

        public MainPage(BasePage bp) : base(bp)
        {
        }

        public BookingFirstStepPage SelectFlight(BasePage bp)
        {
            bp.Refresh();
            Thread.Sleep(2000);
            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //wait.Until(d => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(depAirportXPath));
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(depXPath));
            Thread.Sleep(500);
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(desAirportXPath));
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(desXPath));
            Thread.Sleep(2000);
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath("//input[@data-vol-search-i-check tabindex = '2']"));
            //WebElementHelper.MoveToElementAndClick(Driver, By.XPath("//label[contains(text(), 'One-way')]"));
            //WebElementHelper.MoveToElementAndClick(Driver, By.XPath(findFlightsXPath));
            return new BookingFirstStepPage(bp);
        }
    }
}
