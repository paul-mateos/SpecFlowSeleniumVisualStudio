using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Author
{
    public class UserSelectorPage : BasePage
    {
        By Title = By.XPath("//div/span[(@id='kWindow0_wnd_title' and text() = 'User selector')]");
        By FindList = By.XPath("//div[@id='kWindow0']//table[@class='search-table list-search']//span[@class='k-select']");
        By SearchText = By.XPath("//div[@id='kWindow0']//div/input[@data-automation-id='usr-search-query']");
        By SearchBtn = By.XPath("//div[@id='kWindow0']//button[@title='Submit']");
        By userSelectorTable = By.XPath("//div[@id='kWindow0']//table[@role='grid']");
        By AddUserBtn = By.XPath("//div[@id='kWindow0']//button[@title='Add user(s)']");




        public UserSelectorPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until(ExpectedConditions.ElementExists(Title));
        }

        public void ConfirmUserSelector()
        {
            IWebElement rolePage = UICommon.GetElement(Title, d);
            if (!rolePage.Displayed)
            {
                throw new Exception("User Selector failed to open");
            }
            Assert.IsTrue(rolePage.Displayed);
        }


        public void SelectFindBy(string findBy)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(ExpectedConditions.ElementIsVisible(FindList)).Click();
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul[@role='listbox']/li[text()='" + findBy + "']"))).Click();
        }

        public void SetSearchText(string searchText)
        {
            UICommon.SetValue(SearchText, searchText, d);
        }

        public void ClickSearchButton()
        {
            UICommon.ClickButton(SearchBtn,d);
        }



        public void ClickSelectorRecord(string lookUpColumn, string searchText)
        {
            IWebElement searchTable = UICommon.GetSearchResultTable(userSelectorTable, d);
            Table table = new Table(searchTable);
            Assert.IsTrue(table.ClickCellValue(lookUpColumn, searchText, lookUpColumn, d), "Problem selecting value from table");
        }

        public void ClickAddUserButton()
        {
            UICommon.ClickButton(AddUserBtn, d);
        }
    }
}

