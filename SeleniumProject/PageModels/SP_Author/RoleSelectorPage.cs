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
    public class RoleSelectorPage : BasePage
    {
        //public static int waitsec = Properties.Settings.Default.WaitTime;

        By Title = By.Id("kWindow0_wnd_title");
        By Find = By.XPath("//div[@id='kWindow0']//table/tbody/tr/td[2]/input");
        By SearchBtn = By.XPath("//span[@title='Search']");
        By addRoleButton = By.XPath("//div[@id='kWindow0']//button[@title='Add role(s)']");
        By roleSelectorList = By.TagName("table");
        By roleSelectorTable = By.XPath("//div[@id='kWindow0']//table[@role='grid']");
       


        public RoleSelectorPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until(ExpectedConditions.ElementExists(Title));
        }

        public void ConfirmRoleSelector()
        {
            IWebElement rolePage = UICommon.GetElement(Title, d);
            if (!rolePage.Displayed)
            {
                throw new Exception("Role Selector failed to open");
            }
            Assert.IsTrue(rolePage.Displayed);
        }


        public void searchRole(string rolename)
        {
            UICommon.SetValue(Find, rolename, d);
            UICommon.ClickButton(SearchBtn, d);
        }

        public void confirmFoundRole(string SearchText)
        {
          //  By roleTables = By.XPath(".//*[@id='kWindow0']/div/div[1]/rol-select-drct/div/div[1]/div/rol-list-drct/div[1]]");
            By role = By.XPath("//*[@id='kWindow0']//thead/tr/th[2]/a");
            

            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
           IWebElement roleTable = wait.Until(ExpectedConditions.ElementIsVisible(roleSelectorList));
            IReadOnlyCollection<IWebElement> roles = roleTable.FindElements(By.XPath("./tbody/tr"));

            Table table = new Table(roleTable);
            StringAssert.Contains(table.GetCellValue("Role", SearchText, "Role"), SearchText);


            IWebElement rolename = UICommon.GetElement(role, d);

            string text = rolename.Text;

        }



        public void ClickSelectorRecord(string lookUpColumn, string searchText)
        {
            IWebElement searchTable = UICommon.GetSearchResultTable(roleSelectorTable, d);
            Table table = new Table(searchTable);
           //Thread.Sleep(5000);
            Assert.IsTrue(table.ClickCellValue(lookUpColumn, searchText, lookUpColumn, d), "Problem selecting value from table");
        }

        
        public void ClickAddRoleButton()
        {
            UICommon.ClickButton(addRoleButton, d);
        }
    }
}
