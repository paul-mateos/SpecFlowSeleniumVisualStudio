using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_Automation.PageModels.SP_Author
{
    public class DocumentManagementPage : BasePage
    {
       
        //Search Criteria
        By MultipleSelectionbtn = By.Id("multiple");
        By saveButton = By.XPath("//button[@type='button' and contains(text(), 'Save'))]");
        By addDocumentButton = By.XPath("//button[@title='Add document']");
        By addFolderButton = By.XPath("//button[@title='Add']");
        By docTable = By.Id("docExplorerGrid");
        By docSelectorTable = By.XPath("//div[@id='docExplorerGrid']/table[@role='treegrid']/ancestor::div[@id='kWindow0']");
        
        public DocumentManagementPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until((d) => { return d.Title.Contains("Document Management : SupportPoint"); }); 
        }

        public static string GetElementText(By findBy, string findString)
        {
            IWebElement elem = UICommon.GetElement(By.XPath(""), d);
            return elem.Text;

        }

       

        public void ConfirmFoundRecord(string lookUpColumn, string searchText)
        {
            IWebElement searchTable = UICommon.GetSearchResultTable(docTable, d);
            Table table = new Table(searchTable);
            StringAssert.Contains(table.GetCellValue(lookUpColumn, searchText, lookUpColumn), searchText);
        }

        public void clickMultipleSelectionBTN()
        {
            UICommon.ClickButton(MultipleSelectionbtn, d);
        }

        public void ClickRecord(string lookUpColumn, string searchText)
        {
            IWebElement searchTable = UICommon.GetSearchResultTable(docTable, d);
            Table table = new Table(searchTable);
            table.ClickCellValue(lookUpColumn, searchText, lookUpColumn);
        }

        public void ClickSelectorRecord(string lookUpColumn, string searchText)
        {
            IWebElement searchTable = UICommon.GetSearchResultTable(docSelectorTable, d);
            Table table = new Table(searchTable);
            Thread.Sleep(5000);
            Assert.IsTrue(table.ClickCellValue(lookUpColumn, searchText, lookUpColumn), "Problem selecting value from table");
        }

        public void clickAddDocumentButton()
        {
            UICommon.ClickButton(addDocumentButton, d);
        }


        public void clickAddFolderButton()
        {
            UICommon.ClickButton(addFolderButton, d);
        }

    }
}
