using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using SeleniumProject.Modules;
using SeleniumProject.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Modules
{
    public class DELETEDetailsandActions : BaseWebDriverModule
    {
        public DELETEDetailsandActions(IWebDriver d) : base(d)
        {
        }

      

        public void DetailsActions()
        {

            new SPManagerDetailsActionsPage(GetDriver()).clickDetailsandActions();

        }


        public void Edit()

        {
            new SPManagerDetailsActionsPage(GetDriver()).clickEdit();

        }


    }
}
