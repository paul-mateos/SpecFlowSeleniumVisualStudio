using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using SP_Automation.Commons;
using SP_Automation.Environments;
using SP_Automation.PageModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SP_Automation.Modules;
using SP_Automation.PageModels.SP_Author;
using SP_Automation.Utility;

namespace SP_Automation.Tests
{
    static public class SupportPoint 
    {
        static public IWebDriver WebDriver {get; set;}

        /* 
         * Modules
         */

        static public LogIn LogIn { get { return new LogIn(WebDriver); } set { LogIn = value; } }
        static public Nav Nav { get {return  new Nav(WebDriver);} set {Nav = value;} }
        static public Notification Notification { get { return new Notification(WebDriver); } set { Notification = value; } }
        static public SPManagerNavBarPage SPManagerNav { get { return new SPManagerNavBarPage(WebDriver); } set { SPManagerNav = value; } }
        static public SPManagerFindBarPage SPManagerFind { get { return new SPManagerFindBarPage(WebDriver); } set { SPManagerFind = value; } }
        static public Actions Actions { get { return new Actions(WebDriver); } set { Actions = value; } }
        //static public DetailsandActions DetailsActions { get { return new DetailsandActions(WebDriver); } set { DetailsActions = value; } }
        /*
         *  Page Models
         *  */

        static public DocumentManagementPage DocumentManagementPage { get { return new DocumentManagementPage(WebDriver); } set { DocumentManagementPage = value; } }
        static public SPManagerFolderPage SPManagerFolder { get { return new SPManagerFolderPage(WebDriver); } set { SPManagerFolder = value; } }
        static public ImageManagementPage ImageManagementPage { get { return new ImageManagementPage(WebDriver); } set { ImageManagementPage = value; } }
        static public DocumentManagmentNewPage DocumentManagmentNew { get { return new DocumentManagmentNewPage(WebDriver); } set { DocumentManagmentNew = value; } }
        static public SPManagerDetailsActionsPage SPManagerDetailsActionsPage { get { return new SPManagerDetailsActionsPage(WebDriver); } set { SPManagerDetailsActionsPage = value; } }
        static public PermissionsPage PermissionsPage { get { return new PermissionsPage(WebDriver); } set { PermissionsPage = value; } }
        static public RoleSelectorPage RoleSelectorPage { get { return new RoleSelectorPage(WebDriver); } set { RoleSelectorPage = value; } }
        static public SPAuthorPage SPAuthorPage { get { return new SPAuthorPage(WebDriver); } set { SPAuthorPage = value; } }

        /*
         * Open Support Point app: if there is existing one, it will kill it
         */
        static public void OpenSupportPoint()
        {
            
            ExitSuportPoint(); //just in case previous test not cleanup properly
            string environment = Properties.Settings.Default.Environment;
            var options = new InternetExplorerOptions()
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true
            };

            switch (Properties.Settings.Default.Browser)
            {
                case BrowserType.IE:
                    WebDriver = (new InternetExplorerDriver(options));
                    WebDriver.Navigate().GoToUrl("http://" + environment);
                    break;
                case BrowserType.Chrome:
                    WebDriver = (new ChromeDriver());
                    WebDriver.Navigate().GoToUrl("http://" + environment);

                    break;
                case BrowserType.NodeWebkit:
                    string FileLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Panviva\\SupportPoint\\Viewer\\configSPViewer.json";
                    SPConfigFileCreator.UpdateSPConfigFile(Properties.Settings.Default.Environment, FileLocation);
                    WebDriver = (new ChromeDriver(@"C:\Program Files (x86)\Panviva\SupportPoint Viewer\"));
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");
            }

            //Log on to site as user.
            InitialPage initialPage = new InitialPage(WebDriver);
            string BaseWindow = WebDriver.CurrentWindowHandle;
            UICommon.SwitchToNewBrowserWithTitle(WebDriver, "Login");

        }

        /**
         *  Exit and Cleanup
         */
        public static void ExitSuportPoint()
        {
            if (WebDriver != null)
            {
                try
                {
                    LogIn.LogOutAndCloseApp();
                    WebDriver.Quit();
                }
                catch (Exception) { }
            }
            WebDriver = null;
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
                    KillProcess("Viewer.exe");
                    KillProcess("chromedriver.exe");
                    KillProcess("nw.exe");
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");

            }
        }

        static public bool IsSupportPointOpen()
        {
            return WebDriver != null;
        }

        static public void SwitchToPage(string PageTitle)
        {
            string BaseWindowHandle = WebDriver.CurrentWindowHandle;
            UICommon.SwitchToNewBrowserWithTitle(WebDriver,PageTitle);
        }

        public static void KillProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName)))
            {
                process.Kill();
            }
        }

        public static void IsCurrentBrowser(string BrowserTitle)
        {
            string browserTitle = WebDriver.Title.ToString();
            Assert.AreEqual(BrowserTitle, browserTitle, "Current Browser is not: " + BrowserTitle + ". It is: " + browserTitle);
        }



 
    }
}
