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
    public class CopyPage : BasePage
    {
        //Search By
        By CancelBtn = By.XPath("//div[@id='print-modal-controls']//button[text()='Cancel']");


        public CopyPage(IWebDriver driver)
            : base(driver)
        {
            //Wait for title to be displayed 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));
            wait.Until((D) => { return d.Title.Contains("Copy"); });
            //d.SwitchTo().Frame("print-modal-content");

        }

        
        public void clickCancel()
        {
            UICommon.ClickButton(CancelBtn, d);

        }

    }
}
