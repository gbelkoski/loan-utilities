using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace FinanceUtilities.UITests
{
    [Trait("Category", "Applications")]
    public class LandingPageButtons
    {
        private const string HomeUrl = "http://localhost:3000/";
        private const string LandingUrl = "http://localhost:3000/home/";
        private const string LoansUrl = "http://localhost:3000/loans";
        private const string FAQUrl = "http://localhost:3000/FAQ";
        private const string ContactUrl = "http://localhost:3000/Contact";
        private const string AboutUsUrl = "http://localhost:3000/about";


        [Fact]
        public void Clickingonpocetnabutton()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                IWebElement pocetna = driver.FindElement(By.Name("Landing"));
                pocetna.Click();

                DemoHelper.Pause();

                Assert.Equal("Кредитинфо.мк", driver.Title);
                Assert.Equal(LandingUrl, "http://localhost:3000/home/");
            }
        }

        [Fact]
        [Trait("Category", "Applications")]
        public void Clickingonkreditibutton()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                IWebElement krediti = driver.FindElement(By.Name("Loans"));
                krediti.Click();

                DemoHelper.Pause();

                Assert.Equal("Кредитинфо.мк", driver.Title);
                Assert.Equal(LoansUrl, "http://localhost:3000/loans");
            }
        }

        [Fact]
        [Trait("Category", "Applications")]
        public void Clickingonchppbutton()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                IWebElement chpp = driver.FindElement(By.Name("FAQ"));
                chpp.Click();

                DemoHelper.Pause();

                Assert.Equal("Кредитинфо.мк", driver.Title);
                Assert.Equal(FAQUrl, "http://localhost:3000/FAQ");
            }
        }

        [Fact]
        [Trait("Category", "Applications")]
        public void Clickingonkontaktbutton()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                IWebElement Contact = driver.FindElement(By.Name("Contact"));
                Contact.Click();

                DemoHelper.Pause();

                Assert.Equal("Кредитинфо.мк", driver.Title);
                Assert.Equal(ContactUrl, "http://localhost:3000/Contact");

            }
        }

        [Fact]
        [Trait("Category", "Applications")]
        public void ClickingonAbotutUsbutton()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                IWebElement ZaNas = driver.FindElement(By.Name("About Us"));
                ZaNas.Click();

                DemoHelper.Pause();

                Assert.Equal("Кредитинфо.мк", driver.Title);
                Assert.Equal(AboutUsUrl, "http://localhost:3000/about");

            }
        }
    }
}

