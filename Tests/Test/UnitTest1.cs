using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void PageTitle_ShouldBeCorrect()
        {
            using var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5005");
            Assert.Equal("Калькулятор модульного дома", driver.Title);
        }

        [Fact]
        public void Calculate_ShouldReturnResults()
        {
            using var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5005");

            driver.FindElement(By.Id("area")).SendKeys("50");
            driver.FindElement(By.Id("type")).SendKeys("Дом");

            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.CssSelector("#city option[value='Екатеринбург']")).Click();

            driver.FindElement(By.Id("promo")).SendKeys("SGD10");
            driver.FindElement(By.Id("calculateBtn")).Click();

            var total = driver.FindElement(By.Id("total")).Text;
            Assert.Contains("Руб.", total);
        }

        [Fact]
        public void Calculate_ShouldShowError_WhenFieldsEmpty()
        {
            using var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("http://localhost:5005");

            var areaField = driver.FindElement(By.Id("area"));
            var typeField = driver.FindElement(By.Id("type"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value = '';", areaField);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value = '';", typeField);

            driver.FindElement(By.Id("calculateBtn")).Click();

            var alert = driver.SwitchTo().Alert();
            Assert.Equal("Заполните пустые поля", alert.Text);
            alert.Accept();
        }

        [Fact]
        public void Calculate_Delivery_ShouldChangeForDifferentCities()
        {
            using var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5005");

            driver.FindElement(By.Id("area")).SendKeys("50");
            driver.FindElement(By.Id("type")).SendKeys("Дом");


            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.CssSelector("#city option[value='Екатеринбург']")).Click();

            driver.FindElement(By.Id("promo")).Clear();
            driver.FindElement(By.Id("promo")).SendKeys("SGD10");
            driver.FindElement(By.Id("calculateBtn")).Click();

            var deliveryEkb = driver.FindElement(By.Id("delivery")).Text;


            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.CssSelector("#city option[value='Пермь']")).Click();

            driver.FindElement(By.Id("calculateBtn")).Click();

            var deliveryPerm = driver.FindElement(By.Id("delivery")).Text;

            Assert.NotEqual(deliveryEkb, deliveryPerm);
        }
    }
}