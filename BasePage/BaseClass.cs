using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinjitAssessment.BasePage
{
    /*
     *  Intialize the driver - Setup driver
     */
    public class BaseClass
    {
        public static IWebDriver driver;
        [TestInitialize]
        public void Init()
        {
            //create an instance for webdriver
            driver = new ChromeDriver();
            //navigate to site url
            driver.Navigate().GoToUrl("https://www.globalsqa.com/demo-site/draganddrop/");
            //maximize the browser window
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
        }
    }
}
