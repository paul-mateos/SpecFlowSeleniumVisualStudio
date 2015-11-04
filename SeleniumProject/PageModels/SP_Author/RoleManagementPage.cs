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
        By SearchQuery = By.XPath("//input[@placeholder='Search']");
        By SearchButton = By.XPath("//button[@title='Submit']");
        By roleTable = By.XPath("//table[@role='grid']");
        By rolesinthisroleTable = By.XPath("//shr-role-grid-drct[@header-title='Roles in this role']/.//table");
   

        public RoleManagementPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));
            wait.Until((d) => { return d.Title.Contains("Role Management : SupportPoint"); }); 
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
            IWebElement searchTable = UICommon.GetSearchResultTable(roleTable, d);
            Table table = new Table(searchTable);
            StringAssert.Contains(table.GetCellValue(lookUpColumn, searchText, lookUpColumn), searchText);
        }

        public void ClickFoundRecord(string lookUpColumn, string searchText)
        {
            IWebElement searchTable = UICommon.GetSearchResultTable(roleTable, d);
            Table table = new Table(searchTable);
            table.ClickCellValue(lookUpColumn, searchText, lookUpColumn, d);
        }

        public void ClickRecord(string lookUpColumn, string searchText, string tableName)
        {
            IWebElement searchTable;
            switch(tableName)
            {
                case "RoleTable":
                    searchTable = UICommon.GetSearchResultTable(roleTable, d);
                break;
                case "RolesinthisroleTable":
                searchTable = UICommon.GetSearchResultTable(rolesinthisroleTable, d);
                break;
                default:
                    throw new Exception("invalid Role table");

            }
            
            Table table = new Table(searchTable);
            table.ClickCellValue(lookUpColumn, searchText, lookUpColumn, d);
        }
    }
}
