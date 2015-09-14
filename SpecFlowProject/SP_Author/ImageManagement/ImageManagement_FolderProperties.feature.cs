﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlowProject.SP_Author.ImageManagement
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ImageManagement_FolderPropertiesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ImageManagement_FolderProperties.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ImageManagement_FolderProperties", "In order to change the folder properties\r\nAs a valid user\r\nI want to confirm that" +
                    " this can be done", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "ImageManagement_FolderProperties")))
            {
                SpecFlowProject.SP_Author.ImageManagement.ImageManagement_FolderPropertiesFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
testRunner.Given("I have SessioID with username as \"\" and password as \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
testRunner.And("I create the Automation Image Folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
testRunner.When("I have logged in to SP as a new \"authors\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("I Open SP Manager", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Move Folder To Folder")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ImageManagement_FolderProperties")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("2.1.1.1_ImageManagement_MoveToFolder")]
        public virtual void MoveFolderToFolder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Move Folder To Folder", new string[] {
                        "2.1.1.1_ImageManagement_MoveToFolder"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 15
 testRunner.Given("I am at Document Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.And("I Navigate to the Images Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I am at Image Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I search for image by ID for 2190", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("the search should return the image record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.When("I Click on the Move Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.And("I select the Images Image Popup Folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I Click on the Move Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("the search should return the image record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Remove Folder From Folder")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ImageManagement_FolderProperties")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("2.1.1.2_ImageMnanagement_RemoveFromFolder")]
        public virtual void RemoveFolderFromFolder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove Folder From Folder", new string[] {
                        "2.1.1.2_ImageMnanagement_RemoveFromFolder"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 27
 testRunner.Given("I am at Document Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.And("I Navigate to the Images Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I am at Image Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I search for image by ID for 3027", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("the search should return the image record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.When("I Click on the Remove Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.Then("I Confirm the Removal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
 testRunner.And("I select the Orphans Image Folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("the search should return the image record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Calcel Folder Detail Changes")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ImageManagement_FolderProperties")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("2.1.1.3_ImageManagement_CancelChanges")]
        public virtual void CalcelFolderDetailChanges()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calcel Folder Detail Changes", new string[] {
                        "2.1.1.3_ImageManagement_CancelChanges"});
#line 38
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 39
 testRunner.Given("I am at Document Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.And("I Navigate to the Images Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("I am at Image Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("I search for image by Name for 336a28215c215237ff39636e06e035cb.gif", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("the search should return the image record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.When("I enter the Image Name New Name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
 testRunner.Then("I click on the Cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
 testRunner.And("the search should return the image record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Save Folder Detail Changes")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ImageManagement_FolderProperties")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("2.1.1.4_ImageManagement_SaveChanges")]
        public virtual void SaveFolderDetailChanges()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Save Folder Detail Changes", new string[] {
                        "2.1.1.4_ImageManagement_SaveChanges"});
#line 49
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 50
 testRunner.Given("I am at Document Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.And("I Navigate to the Images Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I am at Image Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I search for image by Name for 336a28215c215237ff39636e06e035cb.gif", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("the search should return the image record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.When("I enter the Image Name New Image Name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.Then("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.And("I confirm the Image Name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("I enter the Image Name 336a28215c215237ff39636e06e035cb.gif", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
