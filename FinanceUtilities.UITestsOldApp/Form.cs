using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Xunit.Abstractions;
using OpenQA.Selenium.Support.UI;

namespace FinanceUtilities.UITestsOldapp
{
    public class Form
    {
        private const string _homeUrl = "http://localhost:4200/";
        private const string _loansUrl = "http://localhost:4200/loans/";

        private readonly ITestOutputHelper output;

        public Form(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void SquareButtons()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl("http://localhost:4200/");

                DemoHelper.Pause();

                ReadOnlyCollection<IWebElement> squarebuttonsElements = driver.FindElements(By.ClassName("imgCard"));
                squarebuttonsElements[0].Click();
                DemoHelper.Pause();
                driver.Navigate().Back();


                ReadOnlyCollection<IWebElement> squarebuttonsElements1 = driver.FindElements(By.ClassName("imgCard"));
                squarebuttonsElements1[1].Click();
                DemoHelper.Pause();
                driver.Navigate().Back();


                ReadOnlyCollection<IWebElement> squarebuttonsElements2 = driver.FindElements(By.ClassName("imgCard"));
                squarebuttonsElements2[2].Click();
                DemoHelper.Pause();
                driver.Navigate().Back();
                DemoHelper.Pause();

                Assert.Equal(_homeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void PopulateForm()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(_homeUrl);

                ReadOnlyCollection<IWebElement> squarebuttonsElements = driver.FindElements(By.ClassName("imgCard"));
                squarebuttonsElements[0].Click();
                DemoHelper.Pause();

                IWebElement loanTypeSelectElement = driver.FindElement
                    (By.XPath("/html/body/app-root/div/div/loan-calculator/div[2]/div/form/div/div[1]/div/select"));
                loanTypeSelectElement.Click();
                DemoHelper.Pause();

                SelectElement loanType = new SelectElement(loanTypeSelectElement);

                ///проверувам дека дифолт селектираната опција е станбен
                Assert.Equal("Станбен", loanType.SelectedOption.Text);

                foreach(IWebElement option in loanType.Options)
                {
                    output.WriteLine($"Value: {option.GetAttribute("value")} Text: {option.Text}");
                }

                DemoHelper.Pause();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void PopulateAmountInForm()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(_homeUrl);
                DemoHelper.Pause(3000);
                ReadOnlyCollection<IWebElement> squarebuttonsElements = driver.FindElements(By.ClassName("imgCard"));
                squarebuttonsElements[0].Click();
                DemoHelper.Pause(5000);

                IWebElement amountOfLoan = driver.FindElement
                (By.XPath("/html/body/app-root/div/div/loan-calculator/div[2]/div/form/div/div[2]/div/div/input"));
                amountOfLoan.Click();
                DemoHelper.Pause(5000);
                                
                amountOfLoan.Click();
                amountOfLoan.Clear();
                
                amountOfLoan.SendKeys("20000");
                DemoHelper.Pause();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void PopulateYearsInForm()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(_homeUrl);
                DemoHelper.Pause(3000);
                ReadOnlyCollection<IWebElement> squarebuttonsElements = driver.FindElements(By.ClassName("imgCard"));
                squarebuttonsElements[0].Click();
                DemoHelper.Pause(5000);

                IWebElement numberOfYears = driver.FindElement
                (By.XPath("/html/body/app-root/div/div/loan-calculator/div[2]/div/form/div/div[3]/div/input"));
                numberOfYears.Click();
                DemoHelper.Pause(5000);

                numberOfYears.Click();
                numberOfYears.Clear();

                numberOfYears.SendKeys("1");
                DemoHelper.Pause();
            }
        }

        [Fact]
        [Trait("Category","Smoke")]
        public void ButtonPresmetaj()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(_homeUrl);

                ReadOnlyCollection<IWebElement> squarebuttonsElements = driver.FindElements(By.ClassName("imgCard"));
                squarebuttonsElements[0].Click();
                DemoHelper.Pause(5000);
                
                IWebElement amount = driver.FindElement
                    (By.XPath("/html/body/app-root/div/div/loan-calculator/div[2]/div/form/div/div[4]/input"));
                amount.Click();
                DemoHelper.Pause();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void AmortPlan()
        {
            using (IWebDriver driver = new ChromeDriver("."))
            {
                driver.Navigate().GoToUrl(_homeUrl);

                ReadOnlyCollection<IWebElement> squarebuttonsElements = driver.FindElements(By.ClassName("imgCard"));
                squarebuttonsElements[0].Click();
                DemoHelper.Pause(5000);

                IWebElement amortPlanbutton = driver.FindElement
                    (By.CssSelector("#amortBtn > b"));
                amortPlanbutton.Click();
                DemoHelper.Pause();

                IWebElement amortPlanReport = driver.FindElement
                    (By.ClassName("amort-modal"));
                DemoHelper.Pause();
                Assert.Equal("Аморт. план", amortPlanReport.Text);
            }
        }
    }
}