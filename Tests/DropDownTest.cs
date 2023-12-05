using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WinjitAssessment.BasePage;
using WinjitAssessment.Pages;

namespace WinjitAssessment
{
    [TestClass]
    public class DropDownTest : BaseClass
    {
        DropDownMenuPage dropDownMenuPage;
        DragDropPage dragDropPage;

        [TestMethod]
        public void VerifyCountryDropDownSelection()
        {
            dragDropPage = new DragDropPage(driver);
            dragDropPage.ClickDropDownLink();
            dropDownMenuPage = new DropDownMenuPage(driver);
            String expectedValue = "India";
            dropDownMenuPage.SelectCountryDropDownValue(expectedValue);
            // Assert the selected dropdown value
            String actualValue = dropDownMenuPage.GetSelectedDropdownValue();
            Assert.AreEqual(expectedValue, actualValue, "Dropdown selection verification failed.");

        }
    }
}