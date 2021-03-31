using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions; // para usar o teclado sem nenhum input


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
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                Console.WriteLine("Da play no video");
                new Actions(driver).SendKeys("k").Perform(); // Aperta tecla K para dar play no video
                                                             // isso evita casos de xpath diferentes no botao play
                Console.WriteLine("Verifica Anuncio");               
                IWebElement btn_AD = null;
                    try
                    {
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        btn_AD = driver.FindElement(By.XPath("//*[@id='ad-text:7']"));
                        Console.WriteLine("Skipa AD");  
                        btn_AD.Click();
                    }
                    catch (NoSuchElementException ex)
                    {
                        Console.WriteLine(ex.ToString());       
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());                
            }
            finally
            {
                Console.WriteLine("Assiste por 40 seg");
                Thread.Sleep(TimeSpan.FromSeconds(40));
                driver.Close();
                driver.Dispose();
            }
        }
    }
}
