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
    public class DocumentManagementPage : BasePage
    {

        //Search Criteria
        By MultipleSelectionbtn = By.Id("multiple");
        By saveButton = By.XPath("//button[@type='button' and contains(text(), 'Save'))]");
        By addDocumentButton = By.XPath("//button[@title='Add document']");
        By addFolderButton = By.XPath("//button[@title='Add']");
        By applySelectionButton = By.XPath("//button[@title='Apply selection']");
        By docTable = By.Id("docExplorerGrid");
        By multiSelectGrid = By.XPath("//div[@class='container-padding-medium multiselect-selected-items']");
        By docSelectorTable = By.XPath("//div[@id='docExplorerGrid']/table[@role='treegrid']/ancestor::div[@id='kWindow0']");
        By documentName = By.XPath("//input[@name='name']");
        By moveButton = By.XPath("//button[@data-automation-id='doc-details-actions-move']");
        By moveintoButton = By.XPath("//button[@title='Move into']");
        By editButton = By.XPath("//button[@title='Edit']");
        By docSearchQuery = By.XPath("//input[@data-automation-id='doc-explorer-search-query']");
        By searchButton = By.XPath("//button[@data-automation-id='doc-explorer-search-submit']");
        By previewDocumentButton = By.XPath("//span[@title='Preview']");

        By readersPermissionsPane = By.XPath("//ul/li[descendent::span[contains(text(),'Readers')]]");
        By writersPermissionsPane = By.XPath("//ul/li[descendent::span[contains(text(),'Writers')]]");
        By permissionsAdminPermissionsPane = By.XPath("//ul/li[descendent::span[contains(text(),'Permissions administrators')]]");
        By removeWriterRolesBtn = By.XPath("//button[!title='Remove role(s) from writers']");
        By removeAdministratorsRolesBtn = By.XPath("//button[!title='Remove roles(s) from administrators']");
        By removeReadersRolesBtn = By.XPath("//button[!title='Remove role(s) from readers']");
        By folderIconTitle = By.XPath("//li[@aria-selected='true']/div/span/div");

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
            table.ClickCellValue(lookUpColumn, searchText, lookUpColumn, d);
        }


       

        public void clickAddDocumentButton()
        {
            UICommon.ClickButton(addDocumentButton, d);
        }


        public void clickAddFolderButton()
        {
            UICommon.ClickButton(addFolderButton, d);
        }

        public void clickApplySelectionButton()
        {
            UICommon.ClickButton(applySelectionButton, d);
        }

        public void SetDocumentName(string DocumentName)
        {
            UICommon.SetValue(documentName, DocumentName, d);

        }


        public void FindGridRecord(string recordString)
        {
            Assert.IsTrue(UICommon.FindGridRecord(recordString, multiSelectGrid, d), "record Cound Not be found");
        }

        public void ClickMoveButton()
        {
            UICommon.ClickButton(moveButton, d);
        }

        public void ClickMoveintoButton()
        {
            UICommon.ClickButton(moveintoButton, d);
        }

        public void VerifyButtonNotAvailable()
        {
            //IWebElement elem = d.FindElement(editButton);
            //Assert.IsFalse(elem.Displayed);

            if (!d.FindElement(editButton).Displayed)
            {
                Assert.IsTrue(!d.FindElement(editButton).Displayed);
            }
            throw new Exception("User Should not be able to Edit Documents");

        }

        public void SelectFindBy(string findBy)
        {

            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@data-automation-id='doc-explorer-search-type']/.."))).Click();
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(text(),'Name')]/../li[text()='" + findBy + "']"))).Click();
            
        }

        public void SetSearchText(string searchText)
        {
            UICommon.SetValue(docSearchQuery, searchText, d);
        }

        public void ClickSubmitSearchButton()
        {
            UICommon.ClickButton(searchButton, d);
        }

        public void clickPreviewDocumentButton(string documentTitle)
        {
            var currentBrowser = d.CurrentWindowHandle;
            UICommon.ClickButton(previewDocumentButton, d);
            UICommon.SwitchToNewBrowserWithTitle(d, documentTitle, currentBrowser);
        }

        public void ConfirmReadersPermissionsViewable()
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            IWebElement elem = UICommon.GetElement(writersPermissionsPane, d);
            //check if expanded
            if (elem.GetAttribute("aria-expanded") == "false")
            {
                elem.Click();
            }
        }

        public void ConfirmWritersPermissionsViewable()
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            IWebElement elem = UICommon.GetElement(writersPermissionsPane, d);
            //check if expanded
            if (elem.GetAttribute("aria-expanded") == "false")
            {
                elem.Click();
            }
        }

        public void ConfirmPermissionsAdminPermissionsViewable()
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            IWebElement elem = UICommon.GetElement(permissionsAdminPermissionsPane, d);
            //check if expanded
            if (elem.GetAttribute("aria-expanded") == "false")
            {
                elem.Click();
            }
        }

        public void makePermissionsTableEmpty(string tableName)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            IWebElement tableElem;
            By removeButton;
            //get the table
            switch (tableName)
            {
                case "Roles in readers permission:":
                     tableElem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/shr-role-grid-drct[@header-title='" + tableName + "'].//table")));
                     removeButton = removeReadersRolesBtn;
                     break;
                case "Roles in writers permission:":
                     tableElem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/shr-role-grid-drct[@header-title='" + tableName + "'].//table")));
                     removeButton = removeWriterRolesBtn;
                     break;

                case "Roles in permissions administrators:":
                     tableElem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/shr-role-grid-drct[@header-title='" + tableName + "'].//table")));
                     removeButton = removeAdministratorsRolesBtn;
                    break;
                default:
                    throw new Exception("Unknown table");
            }

            Table table = new Table(tableElem);
            if (table.GetNoRecordsInTable() == false)
            {

                for (int i = 1; i < table.GetRowCount(); i++)
                {
                    table.selectFirstTableRow();
                    IWebElement elem = UICommon.GetElement(removeButton, d);
                    if (elem.Enabled == true)
                    {
                        UICommon.ClickButton(removeButton, d);
                    }
                    else
                    {
                        throw new Exception("Button noe enabled");
                    }
                    SupportPoint.SPAuthorPage.ClickSaveButton();
                }
            }
           
        
        }

        public bool ConfirmPermissionsTableEmpty(string tableName)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            IWebElement tableElem;
            By removeButton;
            //get the table
            switch (tableName)
            {
                case "Roles in readers permission:":
                    tableElem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/shr-role-grid-drct[@header-title='" + tableName + "'].//table")));
                    removeButton = removeReadersRolesBtn;
                    break;
                case "Roles in writers permission:":
                    tableElem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/shr-role-grid-drct[@header-title='" + tableName + "'].//table")));
                    removeButton = removeWriterRolesBtn;
                    break;

                case "Roles in permissions administrators:":
                    tableElem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/shr-role-grid-drct[@header-title='" + tableName + "'].//table")));
                    removeButton = removeAdministratorsRolesBtn;
                    break;
                default:
                    throw new Exception("Unknown table");
            }

            Table table = new Table(tableElem);
            return table.GetNoRecordsInTable();


        }

        public string GetFolderIconTitle()
        {
            IWebElement elem = UICommon.GetElement(folderIconTitle, d);
            return elem.GetAttribute("title");
        }
    }
    
}
