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
        By searchName = By.Id("sr_title");
        By searchDescription = By.Id("sr_description");
        By searchKeywords = By.Id("sr_keywords");
        By searchText = By.Id("sr_text");
        By searchCustProperties = By.Id("sr_custom_prop");
        By showIcon = By.Id("sd_icon");
        By showSnippet = By.Id("sd_snippet");
        By showBreadcrumbs = By.Id("sd_breadcrumbs");
        By showLastUpdated = By.Id("sd_last_updated");
        By showFoundLocation = By.Id("sd_found_location");
        By showKeywords = By.Id("sd_keywords");
        By showDescription = By.Id("sd_description");
        By showUserRating = By.Id("sd_show_user_rating");
        By setPartialWordSearch = By.Id("viewer_partial_word_search");
        By indexExtDocuments = By.Id("index_external_docs");
        // By showCustomProperties = By.Id needs to be added

        public AdminPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));
            wait.Until((d) => { return d.Title.Contains("Administration : SupportPoint"); });
        }

        public void ClickRecord(string lookUpColumn, string searchText)

        {
            IWebElement searchTable = UICommon.GetSearchResultTable(adminTable, d);
            Table table = new Table(searchTable);
            table.ClickCellValue(lookUpColumn, searchText, lookUpColumn, d);
        }

        public void fillIn(string name, string description, string keywords, string text, string custproperties)
        {
            UICommon.SetValue(searchName, name, d);
            UICommon.SetValue(searchDescription, description, d);
            UICommon.SetValue(searchKeywords, keywords, d);
            UICommon.SetValue(searchText, text, d);
            UICommon.SetValue(searchCustProperties, custproperties, d);
        }
             public void setDisplay()
        {
            UICommon.SelectCheckbox(showIcon, d);
            UICommon.SelectCheckbox(showSnippet, d);
            UICommon.SelectCheckbox(showBreadcrumbs, d);
            UICommon.SelectCheckbox(showLastUpdated, d);
            UICommon.SelectCheckbox(showFoundLocation, d);
            UICommon.SelectCheckbox(showKeywords, d);
            UICommon.SelectCheckbox(showDescription, d);
            UICommon.SelectCheckbox(showUserRating, d);
            UICommon.DeselectCheckbox(setPartialWordSearch, d);

        }
    }
    
}
