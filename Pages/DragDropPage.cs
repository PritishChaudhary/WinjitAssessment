using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinjitAssessment.Pages
{
    public class DragDropPage
    {
        //Instance of Webdriver
        public static IWebDriver driver;

        //create the constructor
        public DragDropPage(IWebDriver driver)
        {
            DragDropPage.driver = driver;
        }

        //Web elements - page object By locators
        public static readonly By iframeWindow = By.XPath("//iframe[@class='demo-frame lazyloaded']");
        public static readonly By sourceImg = By.XPath("//li[@class='ui-widget-content ui-corner-tr ui-draggable ui-draggable-handle']");
        public static readonly By trash = By.XPath("//div[@id='trash']");
        public static readonly By trashGallery = By.XPath("//div[@id='trash']//li");
        public static readonly By dropDownMenuLink = By.XPath("//span[@class='link_span'][text()='DropDown Menu']");
        public static readonly By samplePageLink = By.XPath("//span[@class='link_span'][text()='Sample Page Test']");

        //Page action methods
        public void SwitchToIframe()
        {
            driver.SwitchTo().Frame(driver.FindElement(iframeWindow));
        }

        public void PerformDragAndDrop()
        {
            IReadOnlyCollection<IWebElement> sourceImages = driver.FindElements(sourceImg);
            IWebElement trashCan = driver.FindElement(trash);
            Actions actions = new Actions(driver);
            foreach (IWebElement sourceImage in sourceImages)
            {
                actions.DragAndDrop(sourceImage, trashCan).Perform();
                System.Threading.Thread.Sleep(1000);
            }
            // Wait for the images to be deleted
            System.Threading.Thread.Sleep(2000);

            // Switch back to the default content
            driver.SwitchTo().DefaultContent();
        }

        public bool DoesTrashElementContainDraggedElement()
        {
            return trashGallery.Equals(sourceImg);
        }

        public void ClickDropDownLink()
        {
            driver.FindElement(dropDownMenuLink).Click();
        }

        public void ClickSamplePageLink()
        {
            //Actions actions = new Actions(driver);
            //actions.SendKeys(Keys.PageDown).Build().Perform();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            js.ExecuteScript("window.scrollBy(0, 500);");
            // Optional: You can add a sleep or wait to give the page some time to load content after scrolling
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(samplePageLink).Click();
        }

    }
}
