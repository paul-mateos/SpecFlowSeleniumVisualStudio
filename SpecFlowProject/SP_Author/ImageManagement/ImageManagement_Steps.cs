using SP_Automation.Tests;
using SpecFlowProject.ContextInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.ImageManagement
{
    [Binding]
    public class ImageManagement_Steps: Steps
    {
  
        //public string FindBy;
        //public string SearchText;


        private readonly FindByData findByData = new FindByData();
        public ImageManagement_Steps(FindByData findByData) // use it as ctor parameter
        { 
            this.findByData = findByData;
        }
        [Given(@"I search for image by (.*) for (.*)")]
        [When(@"I search for image by (.*) for (.*)")]
        [Then(@"I search for image by (.*) for (.*)")]
        public void WhenISearchForImageByFindByForSearchText(String findBy, String searchText)
        {
            findByData.FindBy = findBy;
            findByData.searchBy = searchText;
            SupportPoint.ImageManagementPage.SelectFindBy(findBy);
            SupportPoint.ImageManagementPage.SetSearchText(searchText);
            SupportPoint.ImageManagementPage.ClickSubmitSearchButton();


        }

        [Given(@"the search should return the image record")]
        [Then(@"the search should return the image record")]
        public void ThenTheSearchShouldReturnTheImageRecord()
        {
            
            SupportPoint.ImageManagementPage.ConfirmFoundImage(findByData.FindBy, findByData.searchBy);
            
        }

        public string childFolder;
        [When(@"I select the (.*) Image Folder")]
        public void WhenISelectAImageFolder(string folderString)
        {
            char[] splitter = { ',' };
            string[] folders = folderString.Split(splitter);
            childFolder = folders[folders.Length - 1];
            SupportPoint.SPManagerFolder.ClickOnFolder("Image", folders);
        }


        [When(@"I select the (.*) Image Popup Folder")]
        public void WhenISelectAImagePopupFolder(string folderString)
        {
            char[] splitter = { ',' };
            string[] folders = folderString.Split(splitter);
            childFolder = folders[folders.Length - 1];
            SupportPoint.SPManagerFolder.ClickOnFolder("Image Popup", folders);
        }


        [When(@"I Click on the Move Button")]
        public void WhenIClickOnTheMoveButton()
        {
            SupportPoint.ImageManagementPage.ClickMoveButton();
        }



        
    }
}
