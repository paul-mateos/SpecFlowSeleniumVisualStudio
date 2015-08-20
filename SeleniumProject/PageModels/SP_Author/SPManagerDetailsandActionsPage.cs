using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.PageModels
{
    public class SPManagerDetailsActionsPage : BasePage
    {
        By SaveBtn = By.XPath("//button[@title='Save']");
        By MoveBtn = By.XPath("//button[@title='Move']");
        By RemoveBtn = By.XPath("//button[@title='Remove']");
        By CancelBtn = By.XPath("//button[@title='Cancel']");
        //By DetailsandActions = By.XPath("//a[@data-automation-id='doc-details-actions']");
        By DetailsandActions = By.XPath("//a/span[text()='Details & Actions']");

        By New = By.XPath("//a[@data-automation-id='doc-details-actions-new']");
        By Properties = By.XPath("//form[@name='usrForm']//div[1]/ul/li/div/a[1]");
        By Rolemembership = By.XPath("//form[@name='usrForm']//div[1]/ul/li/div/a[2]");
        By TrainingObjectives = By.LinkText("Training objectives");
        By Readers = By.LinkText("Readers");
        By Writers = By.LinkText("Writers");
        By Notifications = By.LinkText("Notifications");
        By CustomProperties = By.LinkText("Custom properties");


        
        public SPManagerDetailsActionsPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool DetailsandActionsExists()
        {
            IReadOnlyCollection<IWebElement> elemets = d.FindElements(DetailsandActions);
            if (elemets.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void clickSave()
        {
            UICommon.ClickButton(SaveBtn, d);
        }

        public void clickNew()
        {
            UICommon.ClickLink(New, d);
        }

        public void clickMove()
        {
            UICommon.ClickButton(MoveBtn, d);
        }

        public void clickDetailsandActions()
        {
            UICommon.ClickLink(DetailsandActions, d);

        }

        public void clickRolemembership()
        {
            UICommon.ClickLink(Rolemembership, d);
        }

        

        

       

    }
}
