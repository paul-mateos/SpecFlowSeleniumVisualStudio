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
    class SPManagerFolderPage : BasePage
    {
        By Folder = By.XPath("//div[@id=' docexplorertree']/ul/li[1]/div/span[2]");
        By NavFolder = By.XPath("//div[@id=' docexplorertree']/ul/li[1]/div/span[1]");
                   

        public SPManagerFolderPage(IWebDriver driver)
            : base(driver)
        {

        }


        public void clickFolder()
        {
           IWebElement elem = UICommon.GetElement(NavFolder, d);
            String cssvalue = elem.GetAttribute("class");
            if (cssvalue.Equals("k-icon k-plus"))
            {
                UICommon.DoubleClickButton(Folder, d);
            }
        }
    }
}
