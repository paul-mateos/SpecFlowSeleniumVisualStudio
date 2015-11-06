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
namespace SpecFlowProject.SP_Author.UserManagement
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class UserManager_WritersFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "UserManager_Writers.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UserManager_Writers", "", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "UserManager_Writers")))
            {
                SpecFlowProject.SP_Author.UserManagement.UserManager_WritersFeature.FeatureSetup(null);
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
#line 4
#line 5
testRunner.Given("I have logged in to SP as a new \"rolecreators\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
testRunner.When("I Open SP Manager", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
testRunner.Then("I Navigate to the Users Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("3.5(1,2)_AddRolesToWriters")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UserManager_Writers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("UserManagement_Readers")]
        public virtual void _3_512_AddRolesToWriters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("3.5(1,2)_AddRolesToWriters", new string[] {
                        "Regression",
                        "UserManagement_Readers"});
#line 11
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 12
 testRunner.Given("I search for user currentuser in User Management", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
 testRunner.And("I select the record currentuser using column Username from the User table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.When("I press Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.And("I select Writers from Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("I Click on the Add roles to writers Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("the Role Selector is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I select the record authors using column Role from the Role Selector table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("I Click on the Add roles Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.Then("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.And("I select the record authors using column Role from the Roles that can edit table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I Click on the Remove roles from writers Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I press Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("I select Properties from Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I Click on the Delete user Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("I Confirm the Delete", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("3.5(3,4)_AddUsersToWriters")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UserManager_Writers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("UserManagement_Readers")]
        public virtual void _3_534_AddUsersToWriters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("3.5(3,4)_AddUsersToWriters", new string[] {
                        "Regression",
                        "UserManagement_Readers"});
#line 33
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 34
 testRunner.Given("I search for user currentuser in User Management", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.And("I select the record currentuser using column Username from the User table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.When("I press Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.And("I select Writers from Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("I Click on the Add users to writers Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("the User Selector is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I search for user administrator in User Selector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("I select the record administrator using column Username from the User Selector ta" +
                    "ble", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("I Click on the Add user Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.Then("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.And("I select the record administrator using column Username from the Users that can e" +
                    "dit table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("I Click on the Remove users from writers Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.Then("I click on the Save Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.And("I press Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("I select Properties from Details & Actions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("I Click on the Delete user Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("I Confirm the Delete", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
