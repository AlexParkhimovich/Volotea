﻿using OpenQA.Selenium;
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
        private string oneWayRadioXPath = "//div[@tab-index= '[1,2,3]']//li[2]";
        private string depCalendarXpath = "//input[@placeholder = 'Select your departure date'][1]";
        private string depDateCalendarXPath = "//td[@data-handler = 'selectDay']";
        private string findFlightsXPath = "//a[contains(text(), 'FIND FLIGHTS')]";

        public MainPage(BasePage bp) : base(bp)
        {
        }

        public BookingFirstStepPage SelectFlight(BasePage bp)
        {
            bp.Refresh();
            WebElementHelper.WaitAndClick(Driver, By.XPath(oneWayRadioXPath));
            Thread.Sleep(2000);
            WebElementHelper.WaitAndClick(Driver, By.XPath(depAirportXPath));
            Thread.Sleep(2000);
            WebElementHelper.WaitAndClick(Driver, By.XPath(depXPath));

            if (WebElementHelper.IsElementPresent(Driver, By.XPath(desXPath)))
            {
                Thread.Sleep(2000);
                WebElementHelper.WaitAndClick(Driver, By.XPath(desXPath));
            }
            else
            {
                Thread.Sleep(2000);
                WebElementHelper.WaitAndClick(Driver, By.XPath(desAirportXPath));
                Thread.Sleep(2000);
                WebElementHelper.WaitAndClick(Driver, By.XPath(desXPath));
            }
            
            if (WebElementHelper.IsElementPresent(Driver, By.XPath(depDateCalendarXPath)))
            {
                Thread.Sleep(2000);
                WebElementHelper.WaitAndClick(Driver, By.XPath(depDateCalendarXPath));
            }
            else
            {
                Thread.Sleep(2000);
                WebElementHelper.WaitAndClick(Driver, By.XPath(depCalendarXpath));
                Thread.Sleep(2000);
                WebElementHelper.WaitAndClick(Driver, By.XPath(depDateCalendarXPath));
            }

            Thread.Sleep(2000);
            WebElementHelper.WaitAndClick(Driver, By.XPath(findFlightsXPath));
            return new BookingFirstStepPage(bp);
        }
    }
}
