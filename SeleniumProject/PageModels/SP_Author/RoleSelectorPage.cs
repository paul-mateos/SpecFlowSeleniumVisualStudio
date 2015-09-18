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
        public static int waitsec = Properties.Settings.Default.WaitTime;

        By Title = By.Id("kWindow0_wnd_title");
        By Find = By.XPath("//div[@id='kWindow0']//table/tbody/tr/td[2]/input");
        By SearchBtn = By.XPath("//span[@title='Search']");
        By roleSelectorList = By.TagName("table");
       



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

        //public void confirmFoundRole(string SearchText)
        //{
        //    Thread.Sleep(5000);

        //    WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
        //    IWebElement roleTable = wait.Until(ExpectedConditions.ElementIsVisible(roleSelectorList));
        //    IReadOnlyCollection<IWebElement> roles = roleTable.FindElements(By.XPath("./tbody/tr"));
        //    //Debug.WriteLine("role count" + roles.Count);
        //    if (roles.Count == 0)
        //    {
        //        throw new Exception("No Records Found");
        //    }
        //    //foreach (IWebElement r in roles)
        //    //{

        //    //    string hh = "";
        //    //    // elem.Click();
        //    //}

        //    for (int i = 0; i < roles.Count; i++)
        //    {
        //        Thread.Sleep(2000);

        //        IWebElement elem = roles.....(By.XPath("./tbody/span"), d);

        //        Debug.WriteLine("role" + elem);

        //        if (elem.Equals(SearchText))
        //        {
        //            elem.Click();
        //        }

        //    }
        //}



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



    }
}
