using MarsAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V121.Storage;
using System;
using TechTalk.SpecFlow;

namespace MarsAutomation.StepDefinitions
{
    [Binding]
    
    public sealed class SkillFeatureStepDefinitions

    {
        private IWebDriver driver;
        SkillsPage skillPage = new SkillsPage();
        SignInPage signInPage= new SignInPage();

        public SkillFeatureStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        [Given(@"User signin into Mars Portal '([^']*)' '([^']*)'")]
        public void GivenUserSigninIntoMarsPortal(string email, string password)
        {
            signInPage.LoginActions(driver, email, password);
            signInPage.verifySignedInUser(driver);
        }
        [When(@"User clicks on skills tab and enters Skill Name and Skill level '([^']*)' (.*)")]
        public void WhenUserClicksOnSkillsTabAndEntersSkillNameAndSkillLevel(string skillName, int level)
        {
            skillPage.addNewSkill(driver, skillName, level);
        }

        [Then(@"The Skill gets added into user profile '([^']*)'")]
        public void ThenTheSkillGetsAddedIntoUserProfile(string skillName)
        {
            skillPage.verifySkillIsAdded(driver, skillName);
        }
        [Given(@"User signin into Mars Portal <email> <password>")]

        // Test for duplicate skill 
        [When(@"User can not add duplicate skill name '([^']*)' (.*)")]
        public void WhenUserCanNotAddDuplicateSkillName(string skillName, int level)
        {
            skillPage.veifyDuplicateSkillNameisNotAdded(driver, skillName, level);
        }
        //Test to update skills
        [When(@"user updates skill name and level '([^']*)' (.*)")]
        public void WhenUserUpdatesSkillNameAndLevel(string skillName, int level)
        {
            skillPage.updateSkills(driver, skillName, level);
        }

        [Then(@"The skill gets updated into users profile '([^']*)'")]
        public void ThenTheSkillGetsUpdatedIntoUsersProfile(string skillName)
        {
            skillPage.verifySkillisUpdated(driver, skillName);
        }

        //Test to delete the skill record

        [When(@"user deletes the skills")]
        public void WhenUserDeletesTheSkills()
        {
            skillPage.deleteSkill(driver);
        }

        [Then(@"The skills gets deleted from the users profile '([^']*)'")]
        public void ThenTheSkillsGetsDeletedFromTheUsersProfile(string skill)
        {
            skillPage.verifySkillIsDeleted(driver, skill);
        }


        // Test to verify skill name text box can not be empty

        [When(@"User can not add skill without skill name (.*)")]
        public void WhenUserCanNotAddSkillWithoutSkillName(int level)
        {
            skillPage.verifySkillNameIsNotEmpty(driver, level);
        }

        //Test to verify skill level can not be empty
        [When(@"User can not add skill without skill level '([^']*)'")]
        public void WhenUserCanNotAddSkillWithoutSkillLevel(string skill)
        {
            skillPage.verifySkillLevelIsNotEmpty(driver, skill);
        }


    }
}
