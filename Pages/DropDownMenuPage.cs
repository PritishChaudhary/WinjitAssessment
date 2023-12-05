using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinjitAssessment.Pages
{
    public class DropDownMenuPage
    {
        //Instance of Webdriver
        public static IWebDriver driver;

        //create the constructor
        public DropDownMenuPage(IWebDriver driver)
        {
            DropDownMenuPage.driver = driver;
        }

        //Web elements - page object By locators
        public static readonly By dropdownLocator = By.XPath("//div[@rel-title='Select Country']//p/select");

        //Page action methods
        public void SelectCountryDropDownValue(string text)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(dropdownLocator));
            selectElement.SelectByText(text);
        }

        public string GetSelectedDropdownValue()
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(dropdownLocator));
            return dropdown.SelectedOption.Text;
        }
    }
}
