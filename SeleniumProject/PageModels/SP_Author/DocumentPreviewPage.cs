using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Author
{
    public class DocumentPreviewPage : BasePage
    {
       
        //Search Criteria
        By moreButton = By.XPath("//div[@title='More']");
        By closePreview = By.XPath("//nav[@id='more_nav']//li/span/a[contains(text(),'Close')]");

        public DocumentPreviewPage(IWebDriver driver)
            : base(driver)
        {
        
        }

        public void confirmPreviewBrowserOpen(string documentTitle)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until((driver) => { return d.Title.Contains(documentTitle); });
        }


        public void closeOpenPreviewBrowser()
        {
            //var currentBrowser = d.CurrentWindowHandle;
            UICommon.ClickButton(moreButton, d);
            UICommon.ClickLink(closePreview, d);
            UICommon.SwitchToNewBrowserWithTitle(d, "Document Management");
        }
    }
}
