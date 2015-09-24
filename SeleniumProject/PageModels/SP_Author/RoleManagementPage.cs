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
    public class RoleManagementPage : BasePage
    {
        
       //Search Criteria
        //By roleName = By.XPath("//input[@name='name']");
        By SearchQuery = By.XPath("//input[@placeholder='Search']");
        By SearchButton = By.XPath("//button[@title='Submit']");
        By roleTable = By.XPath("//table[@role='grid']");
        //By Namevalidation = By.XPath("//div/p[contains(text@,'Checking if the name requested is available.')]");
        //Buttons


        public RoleManagementPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));
            wait.Until((d) => { return d.Title.Contains("Role Management : SupportPoint"); }); 
        }

        //public string SetRoleName(string RoleName)
        //{

        //    UICommon.SetValue(roleName, RoleName, d);
        //    var wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
        //    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Namevalidation));
        //    return RoleName;

        //}

        //public string SetRandomRoleName(string RoleName)
        //{
        //    string newName = UICommon.getRandomName(RoleName);
        //    UICommon.SetValue(roleName, newName, d);
        //    var wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
        //    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Namevalidation));
        //    return newName;

        //}


        //public void ConfirmWorkflowName(string RoleName)
        //{
        //    Assert.IsTrue(UICommon.GetElementAttribute(roleName, "value", d) == RoleName);
        //}

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
            IWebElement searchTable = UICommon.GetSearchResultTable(roleTable, d);
            Table table = new Table(searchTable);
            StringAssert.Contains(table.GetCellValue(lookUpColumn, searchText, lookUpColumn), searchText);
        }

        public void ClickFoundRecord(string lookUpColumn, string searchText)
        {
            IWebElement searchTable = UICommon.GetSearchResultTable(roleTable, d);
            Table table = new Table(searchTable);
            table.ClickCellValue(lookUpColumn, searchText, lookUpColumn);
        }
    }
}
