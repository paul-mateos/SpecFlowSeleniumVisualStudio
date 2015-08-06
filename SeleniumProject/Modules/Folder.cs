using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.Modules
{


    public class Folder : BaseWebDriverModule
    {
        public Folder(IWebDriver d) : base(d) { }

        /**
       *  Not implemented
       */
        public void VerifyFolderExist()
        {
            Assert.IsTrue(false, "Not implmented");
        }
    }
}
