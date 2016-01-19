using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Editor
{
    public class ImageMappingPage : BasePage
    {
        By Title = By.XPath("//div[@id='ImageMapSelector']//div[(@class='editor-modal-title' and text() = 'Image Mapping')]");
        By SaveBtn = By.XPath("//div[@id='ImageMapSelector']//div/button[text()='Save']");
        



        public ImageMappingPage(IWebDriver driver)
            : base(driver)
        {
           
        }

        public void ConfirmImageMapping()
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(ExpectedConditions.ElementExists(Title));
            Thread.Sleep(3000); // This needs to be removed once UI is fixed with loading method
        }



        public void ClickSaveButton()
        {
            UICommon.ClickButton(SaveBtn, d);
        }
        

    }
    
}

