using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Author
{
    public class DocumentSelectorPage : BasePage
    {

        //Search Criteria
        
        By addDocumentButton = By.XPath("//button[@title='Add document']");
        By docSelectorTable = By.XPath("//div[@id='docExplorerGrid']/table[@role='treegrid']/ancestor::div[@id='kWindow0']");
        By docSearchQuery = By.XPath("//input[@data-automation-id='doc-explorer-search-query']/../ancestor::div[@id='kWindow0']");
        By searchButton = By.XPath("//button[@data-automation-id='doc-explorer-search-submit']../ancestor::div[@id='kWindow0']");
        By findBy = By.XPath("//select[@data-automation-id='doc-explorer-search-type']/../ancestor::div[@id='kWindow0']");
        

        public DocumentSelectorPage(IWebDriver driver)
            : base(driver)
        {
            
        }

       

        public void ConfirmFoundRecord(string lookUpColumn, string searchText)
        {
            IWebElement searchTable = UICommon.GetSearchResultTable(docSelectorTable, d);
            Table table = new Table(searchTable);
            StringAssert.Contains(table.GetCellValue(lookUpColumn, searchText, lookUpColumn), searchText);
        }

        

        public void ClickSelectorRecord(string lookUpColumn, string searchText)
        {
            IWebElement searchTable = UICommon.GetSearchResultTable(docSelectorTable, d);
            Table table = new Table(searchTable);
            Assert.IsTrue(table.ClickCellValue(lookUpColumn, searchText, lookUpColumn, d), "Problem selecting value from table");
            Thread.Sleep(1000);
        }

        public void clickAddDocumentButton()
        {
            UICommon.ClickButton(addDocumentButton, d);
        }

        public void SelectFindBy(string FindBy)
        {

            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(ExpectedConditions.ElementIsVisible(findBy)).Click();
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(text(),'Name')]/../li[text()='" + FindBy + "']/ancestor::div[@id='kWindow0']"))).Click();
            
        }

        public void SetSearchText(string searchText)
        {
            UICommon.SetValue(docSearchQuery, searchText, d);
        }

        public void ClickSubmitSearchButton()
        {
            UICommon.ClickButton(searchButton, d);
        }

      
    }
    
}
