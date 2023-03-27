using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinanceUtilities.UITests
{
    public class FinanceUtilitiesLandingPageTests
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                const string homeUrl = "http://localhost:3000/";

                driver.Navigate().GoToUrl(homeUrl);

                DemoHelper.Pause();

                Assert.Equal("Кредитинфо.мк", driver.Title);
                Assert.Equal(homeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]

        public void ReloadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                const string homeUrl = "http://localhost:3000/";

                driver.Navigate().GoToUrl(homeUrl);

                DemoHelper.Pause();

                driver.Navigate().Refresh();

                Assert.Equal("Кредитинфо.мк", driver.Title);
                Assert.Equal(homeUrl, driver.Url);

            }
        }
    }
}