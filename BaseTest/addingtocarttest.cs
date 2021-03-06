using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Tests
{
    [TestFixture]
    public class BaseTest
    {
        private static readonly string url = "http://automationpractice.com/index.php";
        private static readonly TimeSpan implicitWait = TimeSpan.FromSeconds(3);
            
        private readonly IWebDriver driver;
        private WebDriverWait wait;
        

        public BaseTest()
        {
            
            driver = new ChromeDriver(Directory.GetCurrentDirectory());
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = implicitWait;
            driver.Navigate().GoToUrl(url);
            
        }
        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();
        
        [Test]
        public void Addingtocarttest()
        {
            driver.FindElement(By.ClassName("sf-with-ul")).Click();
            driver.FindElement(By.ClassName("img")).Click();
            driver.FindElement(By.ClassName("img")).Click();
            driver.FindElement(By.ClassName("product_img_link")).Click();
            driver.FindElement(By.Id("add_to_cart")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
           
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(250));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
           
            bool isaddingok = wait.Until(x => x.FindElements(By
                    .XPath("//div[@id='layer_cart']//div[@class='button-container']")))
                .Any();
            Assert.That(isaddingok, "adding is not ok");
            System.Threading.Thread.Sleep(4000);
        }
    }
} 
