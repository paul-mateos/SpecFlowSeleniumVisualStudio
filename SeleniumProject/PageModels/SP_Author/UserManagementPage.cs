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
    public class UserManagementPage : BasePage
    {
        
       //Search Criteria
        //By roleName = By.XPath("//input[@name='name']");
        By SearchQuery = By.XPath("//input[@placeholder='Search']");
        By SearchButton = By.XPath("//button[@title='Submit']");
        By userTable = By.XPath("//table[@role='grid']");
        By rolesthatcanreadTable = By.XPath("//shr-role-grid-drct[@header-title='Role(s) that can read the details of this user:']/.//table");
        By usersthatcanreadTable = By.XPath("//shr-user-grid-drct[@header-title='User(s) that can read the details of this user:']/.//table");
        //By Namevalidation = By.XPath("//div/p[contains(text@,'Checking if the name requested is available.')]");
        //Buttons


        public UserManagementPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));
            wait.Until((d) => { return d.Title.Contains("User Management : SupportPoint"); }); 
        }


        public void SetSearchText(string searchText)
        {
            UICommon.SetValue(SearchQuery, searchText, d);
        }

        public void ClickSubmitSearchButton()
        {
            UICommon.ClickButton(SearchButton, d);
        }
        
        public void ClickUserRecord(string lookUpColumn, string searchText, string tableName)
        {
            IWebElement searchTable;
            switch (tableName)
            {
                case "UserTable":
                    searchTable = UICommon.GetSearchResultTable(userTable, d);
                    break;
                case "RolesthatcanreadTable":
                    searchTable = UICommon.GetSearchResultTable(rolesthatcanreadTable, d);
                    break;
                case "UsersthatcanreadTable":
                    searchTable = UICommon.GetSearchResultTable(usersthatcanreadTable, d);
                    break;
                default:
                    throw new Exception("Invalid User table");

            }

            Table table = new Table(searchTable);
            Assert.IsTrue(table.ClickCellValue(lookUpColumn, searchText, lookUpColumn, d), "Problem selecting value from table");
        }
        
    }
}
