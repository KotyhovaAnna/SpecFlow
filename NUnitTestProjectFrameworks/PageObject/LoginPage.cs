﻿using NUnitTestProjectFrameworks.Business_Object;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
namespace NUnitTestProjectSeleniumWebDriverAdvanced
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement searchInputName => driver.FindElement(By.XPath("//input[@id='Name']"));
        private IWebElement searchInputPassword => driver.FindElement(By.XPath("//input[@id='Password']"));
        private IWebElement searchClick => driver.FindElement(By.XPath("//input[@class='btn btn-default']"));
        private IWebElement assertHome_page => driver.FindElement(By.XPath("//div[h2= 'Home page']"));

        public AddProductPage LoginMetod(Login login)
        {
            searchInputName.SendKeys(login.searchInputName);
            searchInputPassword.SendKeys(login.searchInputPassword);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            searchClick.Click();
            return new AddProductPage(driver);
        }

        public LoginPage LoginButton()
        {
            new Actions(driver).SendKeys(Keys.Enter).Build().Perform();
            return this;
        }
        public string AssertLogin()
        {
            return assertHome_page.Text;
        }
    }
}
