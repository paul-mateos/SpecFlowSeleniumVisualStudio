using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using SP_Automation.Environments;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.Tests
{
    [TestClass]
    public abstract class BaseTest
    {
        protected IWebDriver driver;
        protected TestEnvironment environment;
        
        
        public IWebDriver getDriver()
        {
            return driver;
        }

        public void setDriver(IWebDriver d)
        {
            driver = d;
        }

        public BaseTest setPrevTest(BaseTest t)
        {
            driver = t.getDriver();
            return this;
        }

        [TestInitialize]
        public void Initialize()
        {
            TestCleanUp(); //just in case previous test not cleanup properly
            var options = new InternetExplorerOptions()
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true
            };

            switch (Properties.Settings.Default.Browser)
            {
                case BrowserType.IE:
                    //driver = new InternetExplorerDriver(options);
                    driver = new InternetExplorerDriver(options);
                    break;
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.NodeWebkit: 
                    driver = new ChromeDriver(@"C:\Program Files (x86)\Panviva\SupportPoint Viewer\");
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");
            }

            //driver.Navigate().GoToUrl(TestEnvironment.GetEnvironment().Url);
            //driver.Manage().Window.Maximize();

        }

        [TestCleanup]
        public void TestCleanUp()
        {
            if (driver != null) driver.Quit();

            switch (Properties.Settings.Default.Browser)
            {
                case BrowserType.IE:
                   
                    KillProcess("iexplorer.exe");
                    KillProcess("IEDriverServer.exe");
                    break;
                case BrowserType.Chrome:                 
                    KillProcess("chrome.exe");
                    break;
                case BrowserType.NodeWebkit:
                    KillProcess("viewer.exe");
                    KillProcess("chromedriver.exe");
                    KillProcess("nw.exe");
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");

            }
        }

        public static void SetDriver()
        {

        }

        public static void KillProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName)))
            {
                process.Kill();
            }
        }
    }
}
