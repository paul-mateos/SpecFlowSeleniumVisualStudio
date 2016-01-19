using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels
{
    class CertificateErrorPage : BasePage
    {
        //IWebDriver d;
        public CertificateErrorPage(IWebDriver driver)
            : base(driver)
        {
            d = driver; 
            //Wait for title to be displayed 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));
            wait.Until((D) => { return d.Title.Contains("SupportPoint"); }); 

        }

        

        public void ClickContinueLink()
        {
            UICommon.ClickLink(By.Id("overridelink"), d);

        }
        
    }
}
