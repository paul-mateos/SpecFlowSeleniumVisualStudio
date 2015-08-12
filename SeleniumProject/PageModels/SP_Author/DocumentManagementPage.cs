using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.PageModels.SP_Author
{
    public class DocumentManagementPage : BasePage
    {
       
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

       

        public void ConfirmFoundRecord(string searchText)
        {
            IWebElement searchTable = UICommon.GetSearchResultTable("docExplorerGrid", d);
            Table table = new Table(searchTable);
            StringAssert.Contains(table.GetCellValue("Name", searchText, "Name"), searchText);
        }
    }
}
