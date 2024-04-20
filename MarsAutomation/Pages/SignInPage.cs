using MarsAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;



namespace MarsAutomation.Pages
{
    public class SignInPage
    {
        public void LoginActions(IWebDriver driver, string username, string password)
        { 
            //Open Mars Portal and Sign in 
            driver.Manage().Window.Maximize();
            string baseUrl = "http://localhost:5000/Home";
            driver.Navigate().GoToUrl(baseUrl);
            Thread.Sleep(2000);
            IWebElement signInButton = driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));
            signInButton.Click();
            IWebElement emailIdTextbox = driver.FindElement(By.Name("email"));
            emailIdTextbox.SendKeys(username);
            IWebElement passwordTextBox = driver.FindElement(By.Name("password"));
            passwordTextBox.SendKeys(password);
            IWebElement logInButton = driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
            logInButton.Click();
            Thread.Sleep(2000);
        }

        public void verifySignedInUser(IWebDriver driver)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//body/div[@id='account-profile-section']/div[1]/div[1]/div[2]/div[1]/span[1]", 2);
            IWebElement profileName = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/div[1]/div[2]/div[1]/span[1]"));

            Assert.That((profileName.Text == "Hi Teju"), "User is not signed in");

        }
    }
}
