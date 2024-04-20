using MarsAutomation.Pages;
using MarsAutomation.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace MarsAutomation.StepDefinitions
{
    
    [Binding]
    public sealed class LanguageFeatureStepDefinitions
    {
        private IWebDriver driver; 
        SignInPage signin = new SignInPage();
        LaguangePage languagefeature = new LaguangePage();

        public LanguageFeatureStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
       

        [When(@"User enters Language Name and Language level '([^']*)' (.*)")]
        public void WhenUserEntersLanguageNameAndLanguageLevel(string language, int level)
        {
            languagefeature.addnewlanguage(driver, language, level);
        }


        [Then(@"The language gets added into user profile '([^']*)'")]
        public void ThenTheLanguageGetsAddedIntoUserProfile(string language)
        {
           languagefeature.verifyLanguageisAdded(driver, language);
        }

        //Test to update language 

        [Given(@"User signin into Mars Portal <email> <password> '([^']*)' '([^']*)'")]
        public void GivenUserSigninIntoMarsPortalEmailPassword(string email, string password)
        {
            signin.LoginActions(driver,email,password);
        }


        [When(@"user updates language name and level '([^']*)' (.*)")]
        public void WhenUserUpdatesLanguageNameAndLevel(string language, int level)
        {
            languagefeature.updatelanguage(driver,language,level);
        }


        [Then(@"The language gets updated into users profile '([^']*)'")]
        public void ThenTheLanguageGetsUpdatedIntoUsersProfile(string language)
        {
           languagefeature.verifyLanguageisUpdated(driver, language);
        }

        // Test to delete the language record

        [When(@"user deletes the language")]
        public void WhenUserDeletesTheLanguage()
        {
            languagefeature.deletelanguage(driver);
        }
                [Then(@"The language gets deleted from the users profile French")]
        public void ThenTheLanguageGetsDeletedFromTheUsersProfileFrench()
        {
            throw new PendingStepException();
        }

        [Then(@"The language gets deleted from the users profile '([^']*)'")]
        public void ThenTheLanguageGetsDeletedFromTheUsersProfile(string languageName)
        {
            languagefeature.verifyLanguageisdeleted(driver, languageName);
        }


        // Verify same language can not be added twice
        [When(@"User enters Language duplicate Name and Language level system generates error message '([^']*)' (.*)")]
        public void WhenUserEntersLanguageDuplicateNameAndLanguageLevelSystemGeneratesErrorMessage(string languageName, int level)
        {
            languagefeature.verifyDuplicateLanguage(driver, languageName, level);
        }

        [When(@"User enters four languages")]
        public void WhenUserEntersFourLanguages()
        {
           //throw new PendingStepException();
        }

        [Then(@"After adding four languages user is not able to add more languages '([^']*)' (.*)")]
        public void ThenAfterAddingFourLanguagesUserIsNotAbleToAddMoreLanguages(string language, int level)
        {
            languagefeature.verifyLanguageCount(driver,language,level);
        }
        //Test to verify Add language textbox can not be empty
        [When(@"User add language without language name then system generates an error (.*)")]
        public void WhenUserAddLanguageWithoutLanguageNameThenSystemGeneratesAnError(int level)
        {
            languagefeature.verifyLanguageNameIsNotEmpty(driver, level);
        }

        [When(@"User add language without level then system generates an error message '([^']*)'")]
        public void WhenUserAddLanguageWithoutLevelThenSystemGeneratesAnErrorMessage(string languageName)
        {
            languagefeature.verifyLanguageLevelIsNotEmpty(driver, languageName);
        }





    }
}
