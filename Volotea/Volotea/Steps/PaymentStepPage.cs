using OpenQA.Selenium;
using System.Threading;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class PaymentStepPage : BasePage
    {
        private string flexWindowXPath = "//a[@id = 'closeFlexLink']";
        private string cvvXPath = "//input[@id = 'cvv1']";
        private string cvv = "123";
        private string bookThisFlightButtonXPath = "//a[@id = 'ControlGroupPaymentNewBottom_LinkButtonSubmit']";

        public PaymentStepPage(BasePage bp) : base(bp)
        {
        }

        public WaitingPage BookThisFlight(BasePage bp)
        {

            //there is popup window on page, i can not disable it or change driver focus to web page from popup window

            Thread.Sleep(2000);
            WebElementHelper.WaitAndClick(Driver, By.XPath(flexWindowXPath));
            Thread.Sleep(2000);
            WebElementHelper.WaitAndSendKeys(Driver, By.XPath(cvvXPath), cvv);
            Thread.Sleep(2000);
            WebElementHelper.WaitAndClick(Driver, By.XPath(bookThisFlightButtonXPath));
            return new WaitingPage(bp);
        }
    }
}