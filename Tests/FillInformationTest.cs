using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WinjitAssessment.BasePage;
using WinjitAssessment.Pages;

namespace WinjitAssessment
{
    [TestClass]
    public class FillInformationTest : BaseClass
    {
        SamplePage samplePage;
        DragDropPage dragDropPage;

        [TestMethod]
        public void VerifySubmissionOfSamplePage()
        {
            dragDropPage = new DragDropPage(driver);
            dragDropPage.ClickSamplePageLink();
            samplePage = new SamplePage(driver);
            samplePage.fillInformation("C:\\Users\\Pritish\\source\\repos\\WinjitAssessment\\Resources\\nature.jpg", "TestK", "test@xyz.com", "https://www.flipkart.com", "7-10", "Automation Testing", "Graduate", "Form filled...");
            Assert.AreEqual("Message Sent (go back)", samplePage.GetHeaderMessage());
        }
    }
}