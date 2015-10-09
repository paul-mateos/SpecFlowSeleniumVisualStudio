﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
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
            Assert.IsTrue(table.ClickCellValue(lookUpColumn, searchText, lookUpColumn), "Problem selecting value from table");
            Thread.Sleep(1000);
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
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul[@id='imgSearchType_listbox']/li[text()='"+findBy+"']"))).Click();
       
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
