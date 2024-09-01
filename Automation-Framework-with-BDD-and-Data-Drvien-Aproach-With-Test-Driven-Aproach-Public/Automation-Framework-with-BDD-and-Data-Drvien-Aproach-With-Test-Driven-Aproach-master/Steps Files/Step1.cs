using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Dependency_Verification.Factory;
using Dependency_Verification.Locators;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Dependency_Verification.Driver;
using System.Security.Permissions;
using OpenQA.Selenium.Support.Extensions;
using Dependency_Verification.Common;

namespace Dependency_Verification.Steps_Files
{
    [Binding]
    [TestFixture]
    public class Step1
    {
        Dependency_Verification.Factory.Factory factory = new Factory.Factory();
        static Drivers driver;
        static Helper helper= new Helper();
        static Context contxt = new Context();

        [Given(@"I am on the page URL ""([^""]*)""")]
        public void GivenIAmOnThePageURL(string p0)
        {
            driver = new Drivers(true);

            // instance = new Configuration();
            String url = System.Configuration.ConfigurationManager.AppSettings[p0].ToString() ?? "Not Found";
            driver.GotoUrl(url);
        }

        [Given(@"Core is connected")]
        public void GivenCoreIsConnected()
        {
            contxt.connectssh();
        }



        [Given(@"the test case title is '([^']*)'")]
        public void GivenTheTestCaseTitleIs(string p0)
        {
            System.Diagnostics.Debug.WriteLine(p0);
        }

        [Then(@"I am giving '([^']*)' in '([^']*)'")]
        [When(@"I am giving '([^']*)' in '([^']*)'")]
        [Given(@"I am giving '([^']*)' in '([^']*)'")]
        public void GivenIAmGivingIn(string p0, string p1)
        {
            driver.txtbox(p0, factory.fetch_Element(p1).Locator);
        }
            
        [When(@"I am ""([^""]*)"" on ""([^""]*)""")]
        public void WhenIAmOn(string validator, string module)
        {

            //String module = "Bulk Operations";
            Element xml_module;
            if (!string.IsNullOrEmpty(module) && module.ToString().Contains(','))
            {
                foreach (string modulee in module.Split(','))
                { 
                    xml_module = factory.fetch_Element(modulee);
                    helper.dynamite(validator, xml_module.Locator);
                }
            }
            else if (!string.IsNullOrEmpty(module))
            {
                xml_module = factory.fetch_Element(module);
                helper.dynamite(validator, xml_module.Locator);
            }
            else
            {
                throw new Exception(string.Format("NULL VALUE IN {MODULE} XPATH TO SELECT OR CLICK"));
            }
        }





        [Given(@"I am on the page '([^']*)'")]
        public void GivenIAmOnThePage(string p0)
        {
            String url = System.Configuration.ConfigurationManager.AppSettings[p0].ToString() ?? "Not Found";
            driver.GotoUrl(url);
        }

        [When(@"I am verifying the page loaded successfully")]
        public void WhenIAmVerifyingThePageLoadedSuccessfully()
        {

            Thread.Sleep(30000);
            
           /* string au = driver.Instance().Url;
            var iterator = 0;
            while (!(au == "https://192.168.2.230:2213/SPARROW_MIDORIYA_102_111111/Home/Notifications") || iterator == 20) 
            {
                au = driver.Instance().Url;
                iterator++;
                Thread.Sleep(100);
            }*/
            
           // var ao = driver.Instance().ExecuteJavaScript("return document.readyState == 'complete'");
        }



        [When(@"I am clicking on '([^']*)'")]
        public void WhenIAmClickingOn(string p0)
        {
            
            driver.btn(factory.fetch_Element(p0).Locator);
        }


    }
}
