using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


class Program
{
    static void Main()
    {
        // Configurar o caminho para o ChromeDriver
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("start-maximized");

        IWebDriver driver = new ChromeDriver(chromeOptions);

        // Navegar até a URL
        driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");

        //  Verificar se a página está acessível
        if (VerificarPaginaAcessada(driver))
        {
            Console.WriteLine("A página foi acessada com sucesso!");
        }
        else
        {
            Console.WriteLine("Falha ao acessar a página.");
        }

        // Encontrar o campo de primeiro nome e inserir um primeiro nome
        IWebElement campoPrimeiroNome = driver.FindElement(By.CssSelector(":nth-child(1) > :nth-child(2) > .form-control"));
        campoPrimeiroNome.SendKeys("Francielly");

        // Encontrar o botão de Refresh e clicar
        IWebElement botaoAtualizar = driver.FindElement(By.CssSelector("#Button1"));
        botaoAtualizar.Click();

        // Aguardar um tempo para garantir que a página foi recarregada
        Thread.Sleep(2000);

        // Refazer a localização do campo após o refresh
        campoPrimeiroNome = driver.FindElement(By.CssSelector(":nth-child(1) > :nth-child(2) > .form-control"));

        // Verificar se o campo ficou vazio
        string textoNoCampo = campoPrimeiroNome.GetAttribute("Francielly");
        if (string.IsNullOrEmpty(textoNoCampo))
        {
            Console.WriteLine("O campo está vazio após o refresh.");
        }
        else
        {
            Console.WriteLine("O campo não está vazio após o refresh.");
        }

        // Encontrar o botão de Submit e clicar sem preencher nenhum campo
        IWebElement botaoEnviar = driver.FindElement(By.CssSelector("#submitbtn"));
        botaoEnviar.Click();

        // Aguardar um tempo para garantir pra que a página seja atualizada
        Thread.Sleep(2000);

        // Refazer a localização do campo primeiro nome após clicar em submit
        campoPrimeiroNome = driver.FindElement(By.CssSelector(":nth-child(1) > :nth-child(2) > .form-control"));

        // Verificar se o campo ficou vazio
        string campoVazio = campoPrimeiroNome.GetAttribute("");
        if (string.IsNullOrEmpty(campoVazio))
        {
            Console.WriteLine("O campo obrigatório está vazio.");
        }
        else
        {
            Console.WriteLine("O campo obrigatório não está vazio.");
        }

        // Fechar o navegador
        driver.Quit();
    }

    static bool VerificarPaginaAcessada(IWebDriver driver)
    {
        try
        {
            // Verificar a presença de um elemento pelo seu CssSelector
            IWebElement elemento = driver.FindElement(By.CssSelector(":nth-child(1) > :nth-child(2) > .form-control"));

            return true;
        }
        catch (NoSuchElementException)
        {
            // Se ocorrer uma exceção, a página não foi acessada com sucesso
            return false;
        }
    }
}