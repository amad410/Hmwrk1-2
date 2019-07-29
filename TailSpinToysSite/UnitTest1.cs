using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TailSpinToysSite
{
    [TestClass]
    public class UnitTest1
    {
        //Creating driver reference declared globally at class level scope. 
        //For more on C# scope see - https://www.geeksforgeeks.org/scope-of-variables-in-c-sharp/
        IWebDriver driver;

        [TestMethod]
        public void Hmwrk1_TailSpinToysSite()
        {
            //Introducing finding a collection of elements and iterating through them
            //& Assertion class for validation

            //A collection of elements (array or list of elements) are zero indexed. 
            //That means that the first element in the collection is referenced by the 
            //array index of 0.  If you want to find the second element in the collection
            //it can be found using the array index of 1. 


            driver.Navigate().GoToUrl("http://tailspintoys.azurewebsites.net/");
            //chaining commands findElement and Click
            driver.FindElement(By.LinkText("Model Airplanes")).Click();
            driver.FindElement(By.LinkText("Fourth Coffee Flyer")).Click();
            driver.FindElement(By.ClassName("add-cart")).Click();
            driver.FindElement(By.ClassName("checkout")).Click();
            
            driver.FindElement(By.Id("FirstName")).SendKeys("John");
            driver.FindElement(By.Id("LastName")).SendKeys("Doe");
            driver.FindElement(By.Id("Email")).SendKeys("JohnDoe@gmail.com");
            driver.FindElement(By.Id("Street1")).SendKeys("4334 Cason Cover Lane");
            driver.FindElement(By.Id("City")).SendKeys("Tampa");
           
            IWebElement countryDropdown = driver.FindElement(By.Id("countrySelect"));
            SelectElement countrySelect = new SelectElement(countryDropdown);
            countrySelect.SelectByText("USA");
            //im selecting by value
            //countrySelect.SelectByValue("USA");
            //im selecting the first option in the drop down using index
            //countrySelect.SelectByIndex(0);

            IWebElement stateDropdown = driver.FindElement(By.Id("stateSelect"));
            SelectElement stateSelect = new SelectElement(stateDropdown);
            stateSelect.SelectByText("Florida");

            driver.FindElement(By.Id("Zip")).SendKeys("33578");

            driver.FindElement(By.ClassName("textbutton")).Click();

            //Getting a collection of elements matching some criteria and interating through 
            //them to find the element we want to interact with.
            //We found 3 elements in the collection matchin the criteria of having a name attribute
            // of "id."  Using zero indexed collection {0,1,2}, we found the 3rd element that we want to interact with
            //in the list of elements by the index value of 2.  
            
            IList<IWebElement> shippingRadioButtons = driver.FindElements(By.Name("id"));
            shippingRadioButtons[2].Click();

            driver.FindElement(By.ClassName("textbutton")).Click();

            IList<IWebElement> confirmations = driver.FindElements(By.TagName("cufontext"));

            //Assert.AreEqual("actual", "expected")

            
            Assert.AreEqual(confirmations[0].GetAttribute("innerHTML"), "Receipt:");
            Assert.IsNotNull(confirmations[1].GetAttribute("innerHTML"));


        }

        [TestMethod]
        public void Hmwrk2_EcommerceSite()
        {
            //Sometimes you have to wait for elements to be displayed on the page.
            //There could be a delay of elements rendering from the page due to:
            // API or JavaScript calls doing some work in the background

            //Using a Thread.Sleep(Amount of Time to Wait) to halt the execution of code
            //for some amount of time.  Not the best practice, but it worked.  We will walk
            //through better ways to wait in our next session
            //In theory we could have checked for elements to be displayed, enabled, or found 
            //through the size property. Alternately, we could use implicit or explicit waits. 

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.LinkText("Faded Short Sleeve T-shirts")).Click();
            driver.FindElement(By.Name("Submit")).Click();
            
            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.FindElement(By.ClassName("continue")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.FindElement(By.ClassName("sf-with-ul")).Click();
            driver.FindElement(By.LinkText("Printed Summer Dress")).Click();
            driver.FindElement(By.Name("Submit")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.FindElement(By.ClassName("button-medium")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.FindElement(By.ClassName("standard-checkout")).Click();
            driver.FindElement(By.Id("email")).SendKeys("test@agilethought.com");
            driver.FindElement(By.Id("passwd")).SendKeys("Amad7511");
            driver.FindElement(By.Id("SubmitLogin")).Click();
            driver.FindElement(By.Name("processAddress")).Click();
            driver.FindElement(By.Id("cgv")).Click();
            
            driver.FindElement(By.Name("processCarrier")).Click();
            driver.FindElement(By.ClassName("bankwire")).Click();
            IList<IWebElement> button = driver.FindElements(By.ClassName("button-medium"));
            button[1].Click();

            //Validate text of an element matches what we expect to see.  
            //Assert.AreEqual("actual", "expected")
            Assert.AreEqual(driver.FindElement(By.ClassName("cheque-indent")).Text, "Your order on My Store is complete.", "The order confirmation message is not matching what is expected.");
            driver.FindElement(By.ClassName("logout")).Click();
            
          




















        }

        [TestMethod]
        public void DemoQASite()
        {
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-radiobutton-demo.html");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            IList<IWebElement> elems = driver.FindElements(By.Name("optradio"));
            elems[0].Click();

        }

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();

        }
    }
}
