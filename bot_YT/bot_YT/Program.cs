using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace bot_YT
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["link"]);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.XPath("//*[@id='movie_player']/div[4]/button")).Click();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());                
            }

        }
    }
}
