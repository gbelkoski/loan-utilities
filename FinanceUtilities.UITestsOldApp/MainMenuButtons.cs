using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace FinanceUtilities.UITestsOldapp
{
    [Trait("Category", "Applications")]
    public class MainMenuButtons
    {
        private const string _homeUrl = "http://localhost:4200/";
        private const string _loansUrl = "http://localhost:4200/loans/";
        private const string _faqUrl = "http://localhost:4200/faq/";
        private const string _contactUrl = "http://localhost:4200/contactus/";
        private const string _aboutUsUrl = "http://localhost:4200/aboutus/";

        [Fact]
        public void ClickingOnFirstButton()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(_homeUrl);
                DemoHelper.Pause();

                IWebElement pocetna = driver.FindElement(By.LinkText("Почетна"));
                pocetna.Click();

                Assert.Equal("КредитИнфо:Почетна", driver.Title);
                Assert.Equal("http://localhost:4200/", _homeUrl);
                DemoHelper.Pause();
            }
        }

        [Fact]
        public void ClickingOnSecondButton()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(_homeUrl);
                DemoHelper.Pause();

                IWebElement krediti = driver.FindElement(By.XPath("/html/body/app-root/div/div/nav/div/ul/li[2]/a"));
                krediti.Click();

                Assert.Equal("КредитИнфо:Спореди кредити", driver.Title);
                Assert.Equal("http://localhost:4200/loans/", _loansUrl);
                DemoHelper.Pause();
            }
        }

        [Fact]

        public void ClickingOnThirdButton()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(_homeUrl);
                DemoHelper.Pause();

                IWebElement chpp = driver.FindElement(By.XPath("/html/body/app-root/div/div/nav/div/ul/li[3]/a"));
                chpp.Click();

                Assert.Equal("КредитИнфо:ЧПП", driver.Title);
                Assert.Equal("http://localhost:4200/faq/", _faqUrl);
                DemoHelper.Pause();
            }
        }

        [Fact]
        public void ClickingOnForthButton()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(_homeUrl);
                DemoHelper.Pause();

                IWebElement Kontakt = driver.FindElement(By.XPath("/html/body/app-root/div/div/nav/div/ul/li[4]/a"));
                Kontakt.Click();
                DemoHelper.Pause();

                Assert.Equal("КредитИнфо:Контакт", driver.Title);
                Assert.Equal("http://localhost:4200/contactus/", _contactUrl);
                DemoHelper.Pause();
            }
        }

        [Fact]
        public void ClickingOnFifthButton()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(_homeUrl);
                DemoHelper.Pause();

                IWebElement ZaNas = driver.FindElement(By.XPath("/html/body/app-root/div/div/nav/div/ul/li[5]"));
                ZaNas.Click();

                Assert.Equal("КредитИнфо:За нас", driver.Title);
                Assert.Equal("http://localhost:4200/aboutus/", _aboutUsUrl);
                DemoHelper.Pause();
            }
        }
    }
}

