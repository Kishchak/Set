using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Selenium.PajeObject
{
    public abstract class PajeObjectBase
    {
        protected readonly IWebDriver Driver;
        public PageObject (IWebDriver driver) => Driver => driver;
    }
}
