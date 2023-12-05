using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinjitAssessment.Utility
{
    internal class Utils
    {
        private IWebDriver driver;

        public Utils(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void doClear(By locator)
        {
            driver.FindElement(locator).Clear();
        }

        public void doSendKeys(By locator, String value) 
        {
            doClear(locator);
            driver.FindElement(locator).SendKeys(value);
        }

        public void doDropDownSelectByText(By locator, string text)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByText(text);
        }

        public void doFileUpload(By locator, String filePath)
        {
           IWebElement upload = driver.FindElement(locator);
            upload.SendKeys(filePath);
        }

        
    }
}
