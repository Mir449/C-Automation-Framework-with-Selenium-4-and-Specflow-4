using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Dependency_Verification.Driver;

namespace Dependency_Verification.Support
{
    [Binding]
    [TestFixture]
    class Bindings 
    {
        static Dependency_Verification.Factory.Factory obj;
        public static Drivers driver = new Drivers();
        Bindings()
        {
            //Constructor
        
            
        }
        
        [BeforeTestRun]
        [OneTimeSetUp]
        public static void trial()
        {
            obj = new Factory.Factory();
            obj.xmlloader();
            #if NETCOREAPP
            string configFile = $"{Assembly.GetExecutingAssembly().Location}.config";
            string outputConfigFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            File.Copy(configFile, outputConfigFile, true);
            #endif

        }
        [AfterTestRun]
        [OneTimeTearDown]
        public static void trialend()
        {
            driver.Instance().Close();

        }
    }
}
