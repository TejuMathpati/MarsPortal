using MarsAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarsAutomation.Pages
{
    public class SkillsPage
    {
        
        // Add new skills record
        public void addNewSkill(IWebDriver driver, string skillName, int level)
        {
            IWebElement skillsTab = driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
            skillsTab.Click();
            IWebElement addNewSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewSkill.Click();
            IWebElement skillNameTextbox = driver.FindElement(By.Name("name"));
            skillNameTextbox.SendKeys(skillName);
            SelectElement skillLevelDropdown = new SelectElement(driver.FindElement(By.Name("level")));
            skillLevelDropdown.SelectByIndex(level);
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();
        }

        public void verifySkillIsAdded(IWebDriver driver, string skillname)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            IWebElement addedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That((addedSkill.Text == skillname), "Skill record has not been added successfully");
        }

        // Verify same skill record can not be added twice
        public void veifyDuplicateSkillNameisNotAdded(IWebDriver driver, string skillName, int level)
        {       
            // Add skill Name which is already present
               addNewSkill(driver, skillName, level);
               WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@class='ns-box-inner']", 10);
               IWebElement toolTipMessage = driver.FindElement(By.XPath("//*[contains(text(),'This skill is already exist in your skill list.')]"));
               Assert.That((toolTipMessage.Text == "This skill is already exist in your skill list."), "User can enter duplicate skill name");                         
        }

        // Update skills record

        public void updateSkills(IWebDriver driver, string skillName, int level)
        {
                IWebElement skillsTab = driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
                skillsTab.Click();
            Thread.Sleep(2000);
                IWebElement editSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[2]/tr/td[3]/span[1]/i"));
                editSkillButton.Click();
                IWebElement skillsTextbox = driver.FindElement(By.Name("name"));
                skillsTextbox.Clear();
                skillsTextbox.SendKeys(skillName);
                SelectElement skillLevelDropdown = new SelectElement(driver.FindElement(By.Name("level")));
                skillLevelDropdown.SelectByIndex(level);
                IWebElement updateSkillButton = driver.FindElement(By.XPath("//input[@value='Update']"));
                updateSkillButton.Click();      
            
            
        }
        //Verify skill record has been updated or not
        public void verifySkillisUpdated(IWebDriver driver, string skillName)
        {
            
            IList<IWebElement> skills = driver.FindElements(By.TagName("td"));
            List<String> skillList = new List<String>();
            foreach (var skill in skills )
            {
                skillList.Add(skill.Text);
            }

            Assert.That((skillList.Contains(skillName)), "The skill is not updated successfully");
        }
        
        
        // Delete skills record
        public void deleteSkill(IWebDriver driver)
        {
            
            IWebElement skillsTab = driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
            skillsTab.Click();
            IWebElement deleteSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
            deleteSkillButton.Click();
        }

        // verify skill record has been deleted
        public void verifySkillIsDeleted(IWebDriver driver, string skillName)
        {
            Thread.Sleep(3000); 
            IWebElement deleteSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            Assert.That((deleteSkill.Text != skillName), "The language has not been deleted successfully");

        }
        //Verify add skill texbox can not be empty
        public void verifySkillNameIsNotEmpty(IWebDriver driver, int level)
        {
            IWebElement skillsTab = driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
            skillsTab.Click();
            IWebElement addNewSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewSkill.Click();
            SelectElement skillLevelDropdown = new SelectElement(driver.FindElement(By.Name("level")));
            skillLevelDropdown.SelectByIndex(level);
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();

            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@class='ns-box-inner']", 10);
            IWebElement toolTipMessage = driver.FindElement(By.XPath("//*[contains(text(),'Please enter skill and experience level')]"));
            Assert.That((toolTipMessage.Text == "Please enter skill and experience level"), "User can add skill without a skill name");

        }
        // Verify skill can not be added without selecting the level
        public void verifySkillLevelIsNotEmpty(IWebDriver driver, string skillName)
        {
            IWebElement skillsTab = driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
            skillsTab.Click();
            IWebElement addNewSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewSkill.Click();
            

            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();
            IWebElement skillNameTextbox = driver.FindElement(By.Name("name"));
            skillNameTextbox.SendKeys(skillName);
            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@class='ns-box-inner']", 10);
            IWebElement toolTipMessage = driver.FindElement(By.XPath("//*[contains(text(),'Please enter skill and experience level')]"));
            Assert.That((toolTipMessage.Text == "Please enter skill and experience level"), "User can add skill without a skill name");

        }
    }
}
