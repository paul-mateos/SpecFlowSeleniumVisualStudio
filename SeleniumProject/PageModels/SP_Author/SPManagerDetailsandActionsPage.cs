using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels
{
    public class SPManagerDetailsActionsPage : BasePage
    {
        By SaveBtn = By.XPath("//button[@title='Save']");
        By MoveBtn = By.XPath("//button[@title='Move']");
        By RemoveBtn = By.XPath("//button[@title='Remove']");
        By CancelBtn = By.XPath("//button[@title='Cancel']");
        By DeleteBtn = By.XPath("//button[@title='Delete']");

        By DetailsandActions = By.XPath("//a/span[text()='Details & Actions']");

        By New = By.XPath("//a[@data-automation-id='doc-details-actions-new']");
        By Properties = By.XPath("//a[@data-automation-id='doc-details-actions-properties']");
        By generalProperties = By.XPath("//a[@data-automation-id='doc-details-actions-general-properties']");
        By Rolemembership = By.XPath("//form[@name='usrForm']//div[1]/ul/li/div/a[2]");
        By TrainingObjectives = By.LinkText("Training objectives");
        By Readers = By.LinkText("Readers");
        By Writers = By.LinkText("Writers");
        By Notifications = By.XPath("//a[@data-automation-id='doc-details-actions-notifications']");
        By CustomProperties = By.LinkText("Custom properties");
        By Permissions = By.XPath("//a[@data-automation-id='doc-details-actions-permissions']");
        By RequiredApprovers = By.XPath("//div[@role='menu']/a[text()='Required approvers']");

        By EditBtn = By.XPath("//span[@title='Edit']");

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


        public void clickDetailsandActions()
        {
            UICommon.ClickLink(DetailsandActions, d);
            Thread.Sleep(1000);

        }

        public void clickEdit()
        {
                UICommon.ClickButton(EditBtn, d);
        }

        public void clickCancel()
        {
            UICommon.ClickButton(CancelBtn, d);
        }

        public void clickDelete()
        {
            UICommon.ClickButton(DeleteBtn, d);
            Thread.Sleep(3000);
        }

        public void clickSave()
        {
            UICommon.ClickButton(SaveBtn, d);
            Thread.Sleep(3000);
        }

        public void NoEdit()
        {
            Thread.Sleep(3000);
            IReadOnlyCollection<IWebElement> elements = UICommon.GetElements(EditBtn, d);
            Assert.IsTrue(elements.Count==0);
        }

        public void SelectFromDnAList(string detailsAction)
        {
            switch(detailsAction)
            {
                case "New":
                    UICommon.ClickLink(New, d);
                    break;
                case "Properties":
                    UICommon.ClickLink(Properties, d);
                    break;
                case "General properties":
                    UICommon.ClickLink(generalProperties, d);
                    break;
                case "Permissions":
                    UICommon.ClickLink(Permissions, d);
                    break;
                case "Required approvers":
                    UICommon.ClickLink(RequiredApprovers, d);
                    break;
                default:
                    break;
            }
            Thread.Sleep(1000);
        }

        
    }
}
