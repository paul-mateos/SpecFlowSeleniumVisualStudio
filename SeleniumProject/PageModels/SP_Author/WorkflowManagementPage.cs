using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumProject.PageModels;
using SeleniumProject.Tests;

namespace SeleniumProject.PageModels.SP_Author
{
    public class WorkflowManagementPage : BasePage
    {
        
       //Search Criteria
        By workflowName = By.XPath("//input[@name='name']");
        By SearchQuery = By.XPath("//input[@placeholder='Search']");
        By SearchButton = By.XPath("//button[@title='Submit']");
        By workflowTable = By.XPath("//table[@role='grid']");
        //Buttons


        public WorkflowManagementPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until((d) => { return d.Title.Contains("Workflow Management : SupportPoint"); }); 
        }

        public string SetWorkflowName(string WorkflowName)
        {
            string newName = UICommon.getRandomName(WorkflowName);
            UICommon.SetValue(workflowName, newName, d);
            return newName;

        }

        public void ConfirmWorkflowName(string WorkflowName)
        {
            Assert.IsTrue(UICommon.GetElementAttribute(workflowName, "value", d) == WorkflowName);
        }

        public void SetSearchText(string searchText)
        {
            UICommon.SetValue(SearchQuery, searchText, d);
        }

        public void ClickSubmitSearchButton()
        {
            UICommon.ClickButton(SearchButton, d);
        }

        public void ConfirmFoundRecord(string lookUpColumn, string searchText)
        {
            IWebElement searchTable = UICommon.GetSearchResultTable(workflowTable, d);
            Table table = new Table(searchTable);
            StringAssert.Contains(table.GetCellValue(lookUpColumn, searchText, lookUpColumn), searchText);
        }
    }
}
