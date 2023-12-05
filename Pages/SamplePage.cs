using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WinjitAssessment.Pages
{
    public class SamplePage
    {
        //Instance of Webdriver
        public static IWebDriver driver;

        //create the constructor
        public SamplePage(IWebDriver driver)
        {
            SamplePage.driver = driver;
        }

        //Web elements - page object By locators
        public static readonly By chooseFileBtn = By.XPath("//input[@name='file-553']");
        public static readonly By nameInput = By.XPath("//input[@class='name']");
        public static readonly By emailInput = By.XPath("//input[@class='email']");
        public static readonly By websiteInput = By.XPath("//input[@class='url']");
        public static readonly By experienceInYearsDropdown = By.CssSelector("select#g2599-experienceinyears");
        public static readonly By alertBtn = By.XPath("//button[text()='Alert Box : Click Here']");
        public static readonly By commentInput = By.CssSelector("#contact-form-comment-g2599-comment");
        public static readonly By submitBtn = By.XPath("//button[@type='submit']");
        public static readonly By headerMsg = By.XPath("//h3[contains(text(), 'Message Sent')]");

        //Page action methods
        public void SelectExpertiseCheckboxByValue(String checkboxValue)
        {
            By expertise = By.XPath("//input[@value='" + checkboxValue + "']");
            driver.FindElement(expertise).Click();
        }

        public void SelectEducationRadiobuttonByValue(String radiobuttonValue)
        {
            By education = By.XPath("//input[@value='" + radiobuttonValue + "']");
            driver.FindElement(education).Click();
        }

        public void UploadFile(String filePath)
        {
            System.Threading.Thread.Sleep(2000);
            IWebElement upload = driver.FindElement(chooseFileBtn);
            upload.SendKeys(filePath);
        }

        public void SelectExperienceDropdownByRangeValue(String rangeValue)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(experienceInYearsDropdown));
            selectElement.SelectByText(rangeValue);
        }

        public void AlertAccept()
        {
            IWebElement alertButton = driver.FindElement(alertBtn);
            alertButton.Click();
            IAlert al = driver.SwitchTo().Alert();
            al.Accept();
            al.Accept();
        }

        public void fillInformation(String picFilePath, String name, String email, String website, String expRangeValue, String expertiseValue, String educationValue, String commentText)
        {
            UploadFile(picFilePath);
            driver.FindElement(nameInput).SendKeys(name);
            driver.FindElement(emailInput).SendKeys(email);
            driver.FindElement(websiteInput).SendKeys(website);
            SelectExperienceDropdownByRangeValue(expRangeValue);
            SelectExpertiseCheckboxByValue(expertiseValue);
            SelectEducationRadiobuttonByValue(educationValue);
            AlertAccept();
            driver.FindElement(commentInput).SendKeys(commentText);
            driver.FindElement(submitBtn).Click();
        }

        public String GetHeaderMessage()
        {
            IWebElement confirmationMessage = driver.FindElement(headerMsg);
            return confirmationMessage.Text;

        }

    }
}
