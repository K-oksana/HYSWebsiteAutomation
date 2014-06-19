using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Drawing;

namespace TestLibrary1
{
    [TestFixture]
    public class TestClass
    {

        public static IWebDriver WebDriver;

        // Use TestInitialize to run code before running each test

        [SetUp]
        public void testInitialize()
        {
            var capabilitiesInternet = new OpenQA.Selenium.Remote.DesiredCapabilities();
            capabilitiesInternet.SetCapability("ignoreProtectedModeSettings", true);
            WebDriver = new ChromeDriver(@"C:\chromedriver_win32\");

        }


        [Test]
        public void testScreenshot()
        {
            //WebDriver = new ChromeDriver(@"C:\chromedriver_win32\");
            WebDriver.Navigate().GoToUrl("http://google.com");
            StringAssert.Contains("Google", WebDriver.Title);
            SaveScreenShot(WebDriver.Title);
            System.Threading.Thread.Sleep(2000);
           // cleanUp();
        }


        private static void SaveScreenShot(string screenshotFirstName)
        {
            var screenshot = ((ITakesScreenshot)WebDriver).GetScreenshot();
            var filename = new StringBuilder("C:\\");
            filename.Append(screenshotFirstName);
            filename.Append(DateTime.Now.ToString("dd-mm-yyyy HH_mm_ss"));
            filename.Append(".png");
            screenshot.SaveAsFile(filename.ToString(), System.Drawing.Imaging.ImageFormat.Png);

        }

        [TearDown]
        public void cleanUp()
        {
            WebDriver.Close();
        }

    }
}
