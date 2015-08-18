using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SP_Automation.PageModels;
using SP_Automation.PageModels.SP_Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.Modules
{
    /*
     *  Navigation Module
     * 
     */
    public class Actions : BaseWebDriverModule
    {

        public Actions(IWebDriver d) : base(d) { }

        public void ClickAction()
        {

            new SPManagerNavBarPage(GetDriver()).ClickActions();
           
        }

        public void ClickNewUser()
        {
            new UserActionPage(GetDriver()).ClickNewUser();
        }

        public void CreateNewUser(string name, string firstname, string lastname, string email, string password, string verifypassword)
        {
            new AddUserPage(GetDriver()).fillIn(name, firstname, lastname, email, password, verifypassword);
        }

        /*moved to DetailsandActions
        public void Save()
        {
            new SPManagerDetailsActionsPage(GetDriver()).clickSave();
        }

        public void MultipleSelection()
        {
            new SPManagerFolderPage(GetDriver()).clickMultipleSelection();
        }


        public void Move()
        {
            new SPManagerDetailsActionsPage(GetDriver()).clickMove();
        }

        public void DetailsandAction()
        {

            new SPManagerDetailsActionsPage(GetDriver()).clickDetailsandActions();

        }

        public void Rolemembership()

        { 
            new SPManagerDetailsActionsPage(GetDriver()).clickRolemembership();

        }*/

        public void AddUsertoRole()

        {
            new UserRolemembershipPage(GetDriver()).clickAddUsertoRole();

        }


        public void SearchRole(string rolename)
        {
            new RoleSelectorPage(GetDriver()).searchRole(rolename);
        }

    }
}
