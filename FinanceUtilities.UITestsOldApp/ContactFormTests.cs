using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace FinanceUtilities.UITestsOldapp
{
    [Trait("Category", "Smoke")]
    public class ContactFormTests
    {
        private const string _homeUrl = "http://localhost:4200/";
        private const string _contactUrl = "http://localhost:4200/contactus/";

        [Fact]
        public void SuccessMessageWhenSendingEmailFromContactForm()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl("http://localhost:4200/contactus");

                DemoHelper.Pause();

                IWebElement ime = driver.FindElement(By.Name("name"));
                ime.Click();
                ime.SendKeys("Gjorgji");
                DemoHelper.Pause();

                IWebElement mejl = driver.FindElement(By.Name("email"));
                mejl.Click();
                mejl.SendKeys("gbelkoski@hotmail.com");
                DemoHelper.Pause();

                IWebElement telefonskibroj = driver.FindElement(By.Name("phone"));
                telefonskibroj.Click();
                telefonskibroj.SendKeys("075585505");
                DemoHelper.Pause();

                IWebElement poraka = driver.FindElement(By.Name("mailMessage"));
                poraka.Click();
                poraka.SendKeys("rabote");
                DemoHelper.Pause();

                IWebElement ButtonIsprati = driver.FindElement
                    (By.XPath("/html/body/app-root/div/div/contact-us/div/form/div[3]/button"));
                ButtonIsprati.Click();
                DemoHelper.Pause();

                IAlert alert = driver.SwitchTo().Alert();
                Assert.Equal("Пораката е успешно испратена!", alert.Text);
                alert.Accept();
                DemoHelper.Pause();
            }
        }

        [Fact]
        public void ValidationErrorWhenEmptyName()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl("http://localhost:4200/contactus");

                DemoHelper.Pause();

                IWebElement mejl = driver.FindElement(By.Name("email"));
                mejl.Click();
                mejl.SendKeys("gbelkoski@hotmail.com");
                DemoHelper.Pause();

                IWebElement ButtonIsprati = driver.FindElement
                    (By.XPath("/html/body/app-root/div/div/contact-us/div/form/div[3]/button"));
                ButtonIsprati.Click();
                DemoHelper.Pause();

                var validationName = driver.FindElement(By.ClassName("text-danger"));

                Assert.Equal("Името е задолжително.", validationName.Text);
            }
        }

        [Fact]
        public void ValidationErrorWhenEmptyEmail()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl("http://localhost:4200/contactus");

                DemoHelper.Pause();

                IWebElement ime = driver.FindElement(By.Name("name"));
                ime.Click();
                ime.SendKeys("ivonahaha");
                DemoHelper.Pause();

                IWebElement ButtonIsprati = driver.FindElement
                    (By.XPath("/html/body/app-root/div/div/contact-us/div/form/div[3]/button"));
                ButtonIsprati.Click();
                DemoHelper.Pause();

                var validationEmail =
                driver.FindElement(By.XPath("/html/body/app-root/div/div/contact-us/div/form/div[2]/div[2]/div/small"));

                Assert.Equal("Мејлот е задолжителен.", validationEmail.Text);
            }
        }

        [Fact]
        public void ValidationErrorWhenIncorrectEmail()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl("http://localhost:4200/contactus");

                DemoHelper.Pause();

                IWebElement ime = driver.FindElement(By.Name("name"));
                ime.Click();
                ime.SendKeys("ivonahaha");
                DemoHelper.Pause();

                //entering invalid email adress
                IWebElement mejl = driver.FindElement(By.Name("email"));
                mejl.Click();
                mejl.SendKeys("gbelkoski@dsdjrjrhhh");
                DemoHelper.Pause();

                IWebElement ButtonIsprati = driver.FindElement
                    (By.XPath("/html/body/app-root/div/div/contact-us/div/form/div[3]/button"));
                ButtonIsprati.Click();
                DemoHelper.Pause();

                var invalidmailmessage = driver.FindElements(By.CssSelector
                ("#content-wrap > contact-us > div > form > div.modal-body > div:nth-child(2) > div > small"));

                Assert.Single(invalidmailmessage);
                Assert.Equal("Внесете валиден email.", invalidmailmessage[0].Text);
            }
        }

        [Fact]
        public void ValidationErrorWhenEmptyNameAndEmail()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl("http://localhost:4200/contactus");

                DemoHelper.Pause();

                IWebElement ButtonIsprati = driver.FindElement
                    (By.XPath("/html/body/app-root/div/div/contact-us/div/form/div[3]/button"));
                ButtonIsprati.Click();
                DemoHelper.Pause();

                var validationerrors = driver.FindElements(By.ClassName("text-danger"));

                Assert.Equal(2, validationerrors.Count);
                Assert.Equal("Името е задолжително.", validationerrors[0].Text);
                Assert.Equal("Мејлот е задолжителен.", validationerrors[1].Text);
            }
        }

    }
}
