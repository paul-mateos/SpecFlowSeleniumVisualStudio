using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Author
{
    public class AdminPage : BasePage
    {
        By adminTable = By.XPath("//div[@class='report-grid k-grid k-widget']");

        public AdminPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until((d) => { return d.Title.Contains("Administration : SupportPoint"); });
        }

        public void ClickRecord(string lookUpColumn, string searchText)

        {
            //   UICommon.ClickButton(adminTable, d);
            IWebElement searchTable = UICommon.GetSearchResultTable(adminTable, d);
            Table table = new Table(searchTable);
            table.ClickCellValue(lookUpColumn, searchText, lookUpColumn);



        }
    }
}
