using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using SP_Automation.Modules;
using SP_Automation.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.Modules
{
    public class DELETEDetailsandActions : BaseWebDriverModule
    {
        public DELETEDetailsandActions(IWebDriver d) : base(d)
        {
        }

        //public void Save()
        //{
        //    new SPManagerDetailsActionsPage(GetDriver()).clickSave();
        //}

        //public void Move()
        //{
        //    new SPManagerDetailsActionsPage(GetDriver()).clickMove();
        //}

        public void DetailsActions()
        {

            new SPManagerDetailsActionsPage(GetDriver()).clickDetailsandActions();

        }

        //public void New()
        //{
        //    new SPManagerDetailsActionsPage(GetDriver()).clickNew();
        //}

        //public void Permissions()
        //{
        //    new SPManagerDetailsActionsPage(GetDriver()).clickPermissions();
        //}

        //public void Rolemembership()

        //{
        //    new SPManagerDetailsActionsPage(GetDriver()).clickRolemembership();

        //}

        public void Edit()

        {
            new SPManagerDetailsActionsPage(GetDriver()).clickEdit();

        }


    }
}
