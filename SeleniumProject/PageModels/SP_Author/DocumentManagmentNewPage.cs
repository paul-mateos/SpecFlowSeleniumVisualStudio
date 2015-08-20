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
        By DocumentRadioBtn = By.Id("Document");
        By FolderRadioBtn = By.Id("Folder");
        By Type = By.Name("Type");
        By Name = By.Name("name");
        By Source = By.Name("Source");
        By Description = By.XPath("//textarea[@name='description']");

        WebDriverWait wait;
        public DocumentManagmentNewPage(IWebDriver driver)
            : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));

            wait.Until(ExpectedConditions.ElementExists(Name));
        }

        public void clickDocument()
        {
            UICommon.ClickButton(DocumentRadioBtn, d);
        }

        public void clickFolder()
        {
            UICommon.ClickButton(FolderRadioBtn, d);
        }

        public void fillIn(string folderType, string folderName, string folderDescription)
        {

            UICommon.SelectListValue(Type, folderType, d);
                 UICommon.SetValue(Name, folderName, d);
                Thread.Sleep(3000);
                 UICommon.SetValue(Description, folderDescription, d);
                 
        }
    }
}








        


        
       