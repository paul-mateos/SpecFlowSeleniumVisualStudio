﻿using SeleniumProject.Tests;
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

        [Given(@"I search for image by (.*) for (.*)")]
        [When(@"I search for image by (.*) for (.*)")]
        [Then(@"I search for image by (.*) for (.*)")]
        public void WhenISearchForImageByFindByForSearchText(String findBy, 
            String searchText)
        {
            FeatureContext.Current.Add("FindBy", findBy);
            FeatureContext.Current.Add("SearchBy", searchText);
            SupportPoint.ImageManagementPage.SelectFindBy(findBy);
            SupportPoint.ImageManagementPage.SetSearchText(searchText);
            SupportPoint.ImageManagementPage.ClickSubmitSearchButton();


        }

        [Given(@"the search should return the image record")]
        [When(@"the search should return the image record")]
        [Then(@"the search should return the image record")]
        public void ThenTheSearchShouldReturnTheImageRecord()
        {

            SupportPoint.ImageManagementPage.ConfirmFoundImage(FeatureContext.Current.Get<string>("FindBy"), 
                FeatureContext.Current.Get<string>("SearchBy"));
            
        }

        //public string childFolder;
        [Given(@"I select the (.*) Image Folder")]
        [When(@"I select the (.*) Image Folder")]
        [Then(@"I select the (.*) Image Folder")]
        public void WhenISelectAImageFolder(string folderString)
        {
            char[] splitter = { ',' };
            string[] folders = folderString.Split(splitter);
            //childFolder = folders[folders.Length - 1];
            FeatureContext.Current.Add("childFolder", folders[folders.Length - 1]);
            SupportPoint.SPManagerFolder.ClickOnFolder("Image", folders);
        }

        [Given(@"I select the (.*) Image Popup Folder")]
        [When(@"I select the (.*) Image Popup Folder")]
        [Then(@"I select the (.*) Image Popup Folder")]
        public void WhenISelectAImagePopupFolder(string folderString)
        {
            char[] splitter = { ',' };
            string[] folders = folderString.Split(splitter);
            FeatureContext.Current.Add("childFolder",folders[folders.Length - 1]);
            SupportPoint.SPManagerFolder.ClickOnFolder("Image Selector", folders);
        }

        [Given(@"I Click on the Image Move Button")]
        [When(@"I Click on the Image Move Button")]
        [Then(@"I Click on the Image Move Button")]
        public void WhenIClickOnTheImageMoveButton()
        {
            SupportPoint.ImageManagementPage.ClickMoveButton();
        }

        [Given(@"I enter the Image Name (.*)")]
        [When(@"I enter the Image Name (.*)")]
        [Then(@"I enter the Image Name (.*)")]
        public void WhenIEnterTheImageNameNewName(string imageName)
        {
            SupportPoint.ImageManagementPage.SetImageName(imageName);
            FeatureContext.Current.Add("ImageName", imageName);
        }

        [Given(@"I click on the Cancel Button")]
        [When(@"I click on the Cancel Button")]
        [Then(@"I click on the Cancel Button")]
        public void ThenIClickOnTheCancelButton()
        {
            SupportPoint.ImageManagementPage.ClickCancelButton();
        }

        [Given(@"I click on the Image Save Button")]
        [When(@"I click on the Image Save Button")]
        [Then(@"I click on the Image Save Button")]
        public void ThenIClickOnTheImageSaveButton()
        {
            //SupportPoint.ImageManagementPage.ClickSaveButton();
            SupportPoint.SPAuthorPage.ClickSaveButton();
        }

        [Given(@"I confirm the Image Name")]
        [When(@"I confirm the Image Name")]
        [Then(@"I confirm the Image Name")]
        public void ThenIConfirmTheImageName()
        {
            string imageName = FeatureContext.Current.Get<string>("ImageName");
            SupportPoint.ImageManagementPage.ConfirmImageName(imageName);
        }

       



    }
}
