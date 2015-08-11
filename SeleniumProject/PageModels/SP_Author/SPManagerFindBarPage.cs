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
   public class SPManagerFindBarPage : BasePage
    {
        //Search Criteria
        By findBy = By.Name("");
        By searchText = By.Name("");
        By searchButton = By.Name("");
       
        
        public SPManagerFindBarPage(IWebDriver driver)
            : base(driver)
        {

        }

       public void SearchByFor(string findByOption, string value)
       {
           UICommon.SelectListValue(findBy, findByOption, d);
           UICommon.SetValue(searchText, value, d);
           UICommon.ClickButton(searchButton, d);
       }
    }
}
