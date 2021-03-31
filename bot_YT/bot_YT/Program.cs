using System;
using System.Configuration;
using System.Threading;
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
                Console.WriteLine("Abre a url e espera");
                driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["link"]);

                Console.WriteLine("Da play no video");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.XPath("//*[@id='movie_player']/div[5]/button")).Click();

                Console.WriteLine("Verifica Anuncio");               
                IWebElement btn_AD = null;

                    try
                    {
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        btn_AD = driver.FindElement(By.XPath("//*[@id='ad-text:7']"));
                        btn_AD.Click();

                        Console.WriteLine("Assite por 30 seg");
                        Thread.Sleep(TimeSpan.FromSeconds(30));
                    }
                    catch (NoSuchElementException ex)
                    {

                        throw;
                    }
                                  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());                
            }
            finally
            {
                driver.Close();
                driver.Dispose();
            }
        }
    }
}
