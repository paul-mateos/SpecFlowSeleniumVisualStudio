﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.PageModels;
using SeleniumProject.PageModels.SP_Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Modules
{
    /*
     *  Navigation Module
     * 
     */
    public class DELETEActions : BaseWebDriverModule
    {

        public DELETEActions(IWebDriver d) : base(d) { }

        public void ClickAction()
        {

            new SPManagerNavBarPage(GetDriver()).ClickActions();
           
        }

       

        public void CreateNewUser(string name, string firstname, string lastname, string email, string password, string verifypassword)
        {
            new AddUserPage(GetDriver()).fillIn(name, firstname, lastname, email, password, verifypassword);
        }


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
