using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace csharp_coingecko_selenium_example
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--log-level=3"); // Suppress logs
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.coingecko.com/en/coins/bitcoin");
            var title = driver.Title;
            Console.WriteLine("Page title is: " + title);            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(50);
            var bitcoinPrice = driver.FindElements(By.XPath("//span[@data-price-btc='1.0']"));

            foreach (var price in bitcoinPrice)
            {
                if (price.GetAttribute("data-coin-id") != null && price.GetAttribute("data-coin-id") == "1" && price.Text != "")
                {
                    Console.WriteLine("Current Bitcoin price on Coingecko is: " + price.Text);
                    break;
                }
            }
            
            driver.Quit();
        }
    }
}