using NUnitTestProjectFrameworks.Business_Object;
using NUnitTestProjectSeleniumWebDriverAdvanced;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;


namespace NUnitTestProjectFrameworks.Service.UI
{
    public class ProductService
    {
        public static AddProductPage SearchProduct(IWebDriver driver, Product product)
        {
            AddProductPage addProductPage = new AddProductPage(driver);
            addProductPage.AddNewProduct(product);
            return new AddProductPage(driver);
        }

    }
}
