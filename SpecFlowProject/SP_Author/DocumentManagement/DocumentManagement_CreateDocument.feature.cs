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
namespace SpecFlowProject.SP_Author.DocumentManagement
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class DocumentManagement_CreateDoumentFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DocumentManagement_CreateDocument.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "DocumentManagement_CreateDoument", "In order to create a document\r\nAs an author with valid role access\r\nI want to cre" +
                    "ate documents of different types", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "DocumentManagement_CreateDoument")))
            {
                SpecFlowProject.SP_Author.DocumentManagement.DocumentManagement_CreateDoumentFeature.FeatureSetup(null);
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
#line 10
#line 12
testRunner.Given("I have logged in to SP as a new \"authors\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
testRunner.Then("I Open SP Manager", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("4.1.2.1_Create new Documents From Template")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DocumentManagement_CreateDoument")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("4.1.2.1_DocumentManagement_CreateNewTemplateDocument")]
        public virtual void _4_1_2_1_CreateNewDocumentsFromTemplate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("4.1.2.1_Create new Documents From Template", new string[] {
                        "4.1.2.1_DocumentManagement_CreateNewTemplateDocument"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line 10
this.FeatureBackground();
#line 18
 testRunner.Given("I am at Document Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.And("I select the Home,AutomationFolder DocumentFolder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.When("I press Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.And("I select New from Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I have selected Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("I have entered Type From template Name docTemplateName Description sel_docTemplat" +
                    "eDescription", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
 testRunner.And("I click on the Browse Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("I select the record Overview using column Name from the Document Selector table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I click on the Add document Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("I Click on the Remove Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I Confirm the Removal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("4.1.2.2_Create new Documents From Copy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DocumentManagement_CreateDoument")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("4.1.2.2_DocumentManagement_CreateNewCopyDocument")]
        public virtual void _4_1_2_2_CreateNewDocumentsFromCopy()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("4.1.2.2_Create new Documents From Copy", new string[] {
                        "4.1.2.2_DocumentManagement_CreateNewCopyDocument"});
#line 32
this.ScenarioSetup(scenarioInfo);
#line 10
this.FeatureBackground();
#line 33
 testRunner.Given("I am at Document Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
 testRunner.And("I select the Home DocumentFolder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.When("I press Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.And("I select New from Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("I have selected Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.Then("I have entered Type Copy Name docCopyName Description sel_docCopyDescription", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
 testRunner.And("I click on the Browse Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I select the record Welcome using column Name from the Document Selector table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("I click on the Add document Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I Click on the Remove Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("I Confirm the Removal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("4.1.2.3_Create new Documents From Blank")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DocumentManagement_CreateDoument")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("4.1.2.3_DocumentManagement_CreateNewBlankDocument")]
        public virtual void _4_1_2_3_CreateNewDocumentsFromBlank()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("4.1.2.3_Create new Documents From Blank", new string[] {
                        "4.1.2.3_DocumentManagement_CreateNewBlankDocument"});
#line 47
this.ScenarioSetup(scenarioInfo);
#line 10
this.FeatureBackground();
#line 48
 testRunner.Given("I am at Document Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
 testRunner.And("I select the Home DocumentFolder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.When("I press Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
 testRunner.And("I select New from Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I have selected Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.Then("I have entered Type Blank Name docBlankName Description sel_docBlankDescription", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.And("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("I Click on the Remove Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("I Confirm the Removal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create new Documents From Reusable Content")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DocumentManagement_CreateDoument")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("4.1.2.4_DocumentManagement_CreateNewReuseContentDocument")]
        public virtual void CreateNewDocumentsFromReusableContent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create new Documents From Reusable Content", new string[] {
                        "4.1.2.4_DocumentManagement_CreateNewReuseContentDocument"});
#line 59
this.ScenarioSetup(scenarioInfo);
#line 10
this.FeatureBackground();
#line 60
 testRunner.Given("I am at Document Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 61
 testRunner.And("I select the Home DocumentFolder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.When("I press Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
 testRunner.And("I select New from Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("I have selected Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.Then("I have entered Type Reusable content Name docReusableContentName Description sel_" +
                    "docReusableContentDescription", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
 testRunner.And("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("I Click on the Remove Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("I Confirm the Removal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("4.1.2.5_Create new Documents From Reference")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DocumentManagement_CreateDoument")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("4.1.2.5_DocumentManagement_CreateNewReferenceDocument")]
        public virtual void _4_1_2_5_CreateNewDocumentsFromReference()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("4.1.2.5_Create new Documents From Reference", new string[] {
                        "4.1.2.5_DocumentManagement_CreateNewReferenceDocument"});
#line 71
this.ScenarioSetup(scenarioInfo);
#line 10
this.FeatureBackground();
#line 72
 testRunner.Given("I am at Document Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 73
 testRunner.And("I select the Home DocumentFolder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.When("I press Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
 testRunner.And("I select New from Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("I have selected Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.Then("I have entered Reference document Type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 78
 testRunner.And("I click on the Browse Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("I select the Home,Templates Document Selector Folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("I select the record Overview using column Name from the Document Selector table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("I click on the Add document Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And("I Click on the Remove Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.And("I Confirm the Removal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("4.1.2.6_Create new Documents From Localisation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DocumentManagement_CreateDoument")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("4.1.2.6_DocumentManagement_CreateNewLocalisedDocument")]
        public virtual void _4_1_2_6_CreateNewDocumentsFromLocalisation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("4.1.2.6_Create new Documents From Localisation", new string[] {
                        "4.1.2.6_DocumentManagement_CreateNewLocalisedDocument"});
#line 87
this.ScenarioSetup(scenarioInfo);
#line 10
this.FeatureBackground();
#line 88
 testRunner.Given("I am at Document Management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
 testRunner.And("I select the Home DocumentFolder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.When("I press Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
 testRunner.And("I select New from Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("I have selected Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.Then("I have entered Type Localisation Name docLocalisationName Description sel_docLoca" +
                    "lisationDescription", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
 testRunner.And("I click on the Browse Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("I select the Home,Templates Document Selector Folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("I select the record Overview using column Name from the Document Selector table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("I click on the Add document Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I Click on the Remove Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("I Confirm the Removal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
