using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Verification.Driver
{
    public class Drivers
    {
        static IWebDriver driver;
        static WebDriverWait waitdriver;
        Dependency_Verification.Factory.Factory obj = new Factory.Factory();

        public Drivers()
        {
        }

        public Drivers(bool flag)
        {
            if (flag) {
                if (System.Configuration.ConfigurationManager.AppSettings["Browser"].ToString() =="chrome")
                {
                    String driverexepath = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\112.0.5615.138\\chromedriver.exe";
                driver = new ChromeDriver(driverexepath);
                }
                else
                {
                    driver = new FirefoxDriver();
                }
                waitdriver = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }
        }

        public WebDriverWait wait()
        {
            return waitdriver;
        }
        public IWebDriver Instance()
        {
            return driver;
        }

        public void GotoUrl(String url)
        {
            switch (System.Configuration.ConfigurationManager.AppSettings["Browser"])
            {
                case "firefox":
                    {
                        try
                        {
                            driver.Navigate().GoToUrl(url);
                        }
                        catch (Exception)
                        {
                            btn(obj.fetch_Element("Login_Advance_chrome").Locator);
                            btn(obj.fetch_Element("Login_Accept_chrome").Locator);
                        }
                    }
                    break;
                case "chrome":
                    {
                        try
                        { 
                        driver.Navigate().GoToUrl(url);
                        }
                        catch(Exception)
                        {
                            btn(obj.fetch_Element("Login_Advance_chrome").Locator);
                            btn(obj.fetch_Element("Login_Accept_chrome").Locator);
                        }
                        break;
                    }
                default:
                    throw new Exception("Wrong Type in App config on Browser, should be either firefox or chrome");
            }




            //Assert.True(driver.FindElement(By.TagName("body")).Text.Contains(u));
            waitdriver.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.TagName("body")));
            
        }


        public void txtbox(String Value, String Xpath)
        {
            waitdriver.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath))).SendKeys(Value);
        }


        public void pageisready()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Instance();
            if (js.ExecuteScript("return document.readyState").ToString().Equals("complete"))
            {
                return;
            }
        }
        public int iterator =0;
        public void btn(String Xpath)
        {
            try
            {
                 iterator++;
                //Thread.Sleep(20000);
                pageisready();
                // System.Diagnostics.Debug.WriteLine("This is Xpath : "+Xpath);

                waitdriver.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
                {
                    waitdriver.Until(ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                    {
                        waitdriver.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
                        {
                            IWebElement link = waitdriver.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
                            link.Click();
                        }
                    }
                }
            }
            catch (Exception)
            {
             Thread.Sleep(100);
            btn(Xpath);

                if (iterator == 10)
                {
                    return;
                }
            }
        }



    }
}
