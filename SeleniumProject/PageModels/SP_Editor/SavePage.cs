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
    public class SavePage : BasePage
    {
        By Title = By.XPath("//div[@id='EditorSaveDialogBindingContainer']//div[(@class='editor-modal-title' and text() = 'Save')]");
        By SaveBtn = By.Id("btnSaveDocument");
        



        public SavePage(IWebDriver driver)
            : base(driver)
        {
           
        }

        public void ConfirmSavePage()
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(ExpectedConditions.ElementExists(Title));
            Thread.Sleep(3000); // This needs to be removed once UI is fixed with loading method
        }



        public void ClickSaveButton()
        {
            UICommon.ClickButton(SaveBtn, d);
            UICommon.confirmEditorToastSuccessMessage("Document successfully saved.", d);
        }
        

    }
    
}

