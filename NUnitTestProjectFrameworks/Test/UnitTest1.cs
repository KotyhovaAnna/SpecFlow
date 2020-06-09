using NUnit.Framework;
using NUnitTestProjectFrameworks.Business_Object;
using NUnitTestProjectFrameworks.Service.UI;
using NUnitTestProjectSeleniumWebDriverAdvanced;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace NUnitTestProjectFrameworks

{
    public class Tests
    {

        private IWebDriver driver;
        private AddProductPage addProductPage;
        private LoginPage loginPage;
        private HomePage homePage;
        protected const string name = "user";
        protected const string password = "user";
        private const string CheckLoginPage = "Home page";
        private const string CheckHomePage = "Home";
        private Product CreateProductNew = new Product("морс", "Produce", "Mayumi's", "30", "95", "9", "74", "8");


       [OneTimeSetUp]

        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            AddProductPage addProductPage = loginPage.LoginMetod(name, password);

        }

        [Test, Order(1)]

        public void Login()
        {
            Assert.AreEqual(CheckLoginPage, loginPage.AssertLogin());
        }

        [Test, Order(2)]

        public void NewProduct()
        {
            addProductPage = ProductService.SearchProduct(driver, CreateProductNew);

            Assert.AreEqual(CreateProductNew.searchProductName, addProductPage.AssertAddNewProducts(CreateProductNew.searchProductName));

        }

        [Test, Order(3)]

        public void Logout()
        {
            homePage = new HomePage(driver);
            homePage.Logout();

            Assert.AreEqual(expected: CheckHomePage, homePage.AssertLogout());
        }


        [OneTimeTearDown]

        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }

    }
}