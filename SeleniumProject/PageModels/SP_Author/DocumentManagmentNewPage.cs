using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_Automation.PageModels.SP_Author
{
    public class DocumentManagmentNewPage : BasePage
    {
        By Type = By.Name("Type");
        By Name = By.Name("name");
        By Source = By.Name("Source");
        By Display = By.Name("Display");
        By Description = By.XPath("//textarea[@name='description']");

        WebDriverWait wait;
        public DocumentManagmentNewPage(IWebDriver driver)
            : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));

            wait.Until(ExpectedConditions.ElementExists(Name));
        }

        public void clickFolder(string newtype)
        {
            By newRadioBtn = null;
            if (newtype.Equals("Folder"))
            {
                newRadioBtn = By.Id("Folder");
            }
            else if (newtype.Equals("Document"))
            {
                newRadioBtn = By.Id("Document");
            }

                UICommon.ClickButton(newRadioBtn, d);
        }

        public void fillIn(string type, string name, string description)
        {
            UICommon.SelectListValue(Type, type, d);
            UICommon.SetValue(Name, name, d);
            UICommon.SetValue(Description, description, d);
                 
        }

       
    }
}








        


        
       