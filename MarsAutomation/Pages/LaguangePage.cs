using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using MarsAutomation.Utilities;
using Microsoft.Extensions.DependencyModel;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V121.Debugger;
using OpenQA.Selenium.Support.UI;

namespace MarsAutomation.Pages
{
    public class LaguangePage
    {

        // Add new language record
        public void addnewlanguage(IWebDriver driver, string languageName, int level)
        {
            IWebElement addNew = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNew.Click();
            IWebElement languageTextbox = driver.FindElement(By.Name("name"));
            languageTextbox.SendKeys(languageName);
            SelectElement languageLevelDropdown = new SelectElement(driver.FindElement(By.Name("level")));
            languageLevelDropdown.SelectByIndex(level);
            IWebElement addlanguageButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addlanguageButton.Click();
        }
        // To verify language record has been added or not
        public void verifyLanguageisAdded(IWebDriver driver, string language)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            IWebElement languageadded = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That((languageadded.Text == language), "The language has not been added to the user profile");
        }

        // Verify same language can not be added twice
        public void verifyDuplicateLanguage(IWebDriver driver, string languageName, int level)
        {
            //Add language which is already present
            addnewlanguage(driver, languageName, level);    
            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@class='ns-box-inner']", 10);
            IWebElement toolTipMessage = driver.FindElement(By.XPath("//*[contains(text(),'This language is already exist in your language list.')]"));
            Assert.That((toolTipMessage.Text == "This language is already exist in your language list."), "User can enter duplicate skill name");    
            
        }

        // Verify user can add maximum four languages 

        public void verifyLanguageCount(IWebDriver driver, string languageName, int level)
        {


            // Get row count from language table
            var table = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]"));
            IList<IWebElement> languageTableRows = table.FindElements(By.TagName("tr"));
            int rowCount = languageTableRows.Count();
            if (rowCount <= 4)
            {
                addnewlanguage(driver, languageName, level);
                
            }
            else
            {
                Assert.Fail("The user can add maximum four languages");
            }
        }

        // Update language record

        public void updatelanguage(IWebDriver driver, string languageName, int level)
        {

            //click on update language icon

            IWebElement editLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
            editLanguageButton.Click();

                      
                IWebElement languageTextbox = driver.FindElement(By.Name("name"));
                languageTextbox.Clear();
                languageTextbox.SendKeys(languageName);
                SelectElement languageLevelDropdown = new SelectElement(driver.FindElement(By.Name("level")));
                languageLevelDropdown.SelectByIndex(level);
                IWebElement updateLanguageButton = driver.FindElement(By.XPath("//input[@value='Update']"));
                updateLanguageButton.Click();
           
        }
        //Verify language record has been updated or not
        public void verifyLanguageisUpdated(IWebDriver driver, string language)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//td[contains(text(),'Updated')]", 2);
            IWebElement updatedLanguage = driver.FindElement(By.XPath("//td[contains(text(),'Updated')]"));
            Assert.That((updatedLanguage.Text == language), "The language has not been updated successfully");

        }

        // Delete language record
        public void deletelanguage(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement deleteLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
            deleteLanguageButton.Click();
        }

        // verify language record has been deleted
        public void verifyLanguageisdeleted(IWebDriver driver, string languageName)
        {

            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 5);
            IWebElement deleteLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That((deleteLanguage.Text != languageName), "The language has not been deleted successfully");

        }

        //Verify add language texbox can not be empty
        public void verifyLanguageNameIsNotEmpty(IWebDriver driver, int level)
        {
            IWebElement addNew = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNew.Click();
            SelectElement languageLevelDropdown = new SelectElement(driver.FindElement(By.Name("level")));
            languageLevelDropdown.SelectByIndex(level);
            IWebElement addlanguageButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addlanguageButton.Click();

            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@class='ns-box-inner']", 10);
            IWebElement toolTipMessage = driver.FindElement(By.XPath("//*[contains(text(),'Please enter language and level')]"));
            Assert.That((toolTipMessage.Text == "Please enter language and level"), "User can add language without a language name");

        }

        // Verify language can not be added without selecting the level
        public void verifyLanguageLevelIsNotEmpty(IWebDriver driver, string languageName)
        {
            IWebElement addNew = driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNew.Click();
            IWebElement languageTextbox = driver.FindElement(By.Name("name"));
            languageTextbox.SendKeys(languageName); 
            IWebElement addlanguageButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addlanguageButton.Click();

            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@class='ns-box-inner']", 10);
            IWebElement toolTipMessage = driver.FindElement(By.XPath("//*[contains(text(),'Please enter language and level')]"));
            Assert.That((toolTipMessage.Text == "Please enter language and level"), "User can add language without selecting level");

        }

    }
}

