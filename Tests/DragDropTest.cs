using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WinjitAssessment.BasePage;
using WinjitAssessment.Pages;

namespace WinjitAssessment
{
    [TestClass]
    public class DragDropTest : BaseClass
    {
        public DragDropPage? dragDropPage;

        [TestMethod]
        public void verifyDragDropToTrash()
        {
            dragDropPage = new DragDropPage(driver);
            dragDropPage.SwitchToIframe();
            dragDropPage.PerformDragAndDrop();
            Assert.IsNotNull(dragDropPage.DoesTrashElementContainDraggedElement());
        }
    }
}