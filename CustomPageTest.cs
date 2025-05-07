using System.Threading.Tasks; //Permite usar métodos asíncronos (como Task)
using Microsoft.Playwright;   //Importa Playwright, la librería de automatización del navegador
using NUnit.Framework;        //Importa NUnit, el framework de testing que usas

namespace PlaywrightEnsayo;    //Define el espacio de nombres del proyecto

//Clase base para tus tests: prepara el navegador y la página antes de cada prueba
public class CustomPageTest
{
    protected IBrowser Browser;

    protected IBrowserContext Context;

    protected IPage Page;

    //Este método se ejecuta antes de cada test automáticamente
    [SetUp]
    public async Task SetUp()
    {
        //Inicializa Playwright (carga el motor de automatización)
        var playwright = await Playwright.CreateAsync();

        //Lanza el navegador Chromium en modo visible y lento para poder ver lo que pasa
        Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false, //false = muestra el navegador (modo visible)
            SlowMo = 100      //añade una pausa de 100ms entre acciones para verlas con claridad
        });

        Console.WriteLine("Navegador WebKit lanzado correctamente");

        //Crea un nuevo contexto (una sesión aislada)
        Context = await Browser.NewContextAsync();

        //Abre una nueva pestaña en el navegador
        Page = await Context.NewPageAsync();
    }

    //Este método se ejecuta después de cada test automáticamente
    [TearDown]
    public async Task TearDown()
    {
        await Browser.CloseAsync();
    }
}