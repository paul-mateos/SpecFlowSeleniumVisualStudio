﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using SP_Automation.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        By Properties = By.XPath("//a[@data-automation-id='doc-details-actions-properties']");
        By generalProperties = By.XPath("//a[@data-automation-id='doc-details-actions-general-properties']");
        By Rolemembership = By.XPath("//form[@name='usrForm']//div[1]/ul/li/div/a[2]");
        By TrainingObjectives = By.LinkText("Training objectives");
        By Readers = By.LinkText("Readers");
        By Writers = By.LinkText("Writers");
        By Notifications = By.XPath("//a[@data-automation-id='doc-details-actions-notifications']");
        By CustomProperties = By.LinkText("Custom properties");
        By Permissions = By.XPath("//a[@data-automation-id='doc-details-actions-permissions']");
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

        //public void clickSave()
        //{
        //    UICommon.ClickButton(SaveBtn, d);
        //}

        //public void clickNew()
        //{
        //    UICommon.ClickLink(New, d);
        //}

        //public void clickPermissions()

        //{
        //    By verPermissionsPage = By.XPath("//button[@title='Add role to readers']");
         
        //    IReadOnlyCollection<IWebElement> elem = UICommon.GetElements(verPermissionsPage, d);

        //    if (elem.Count==0)
        //    {
        //        SupportPoint.DetailsActions.DetailsActions();
        //        UICommon.ClickLink(Permissions, d);
        //    }
        //}

        //public void clickMove()
        //{
        //    UICommon.ClickButton(MoveBtn, d);
        //}

        public void clickDetailsandActions()
        {
            UICommon.ClickLink(DetailsandActions, d);

        }

        //public void clickRolemembership()
        //{
        //    UICommon.ClickLink(Rolemembership, d);
        //}

        public void clickEdit()
        {
                UICommon.ClickButton(EditBtn, d);
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
                default:
                    break;
            }
            Thread.Sleep(1000);
        }
    }
}
