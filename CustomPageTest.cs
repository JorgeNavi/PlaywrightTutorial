using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightEnsayo;

public class CustomPageTest
{
    protected IBrowser Browser;
    protected IBrowserContext Context;
    protected IPage Page;

    [SetUp]
    public async Task SetUp()
    {
        var playwright = await Playwright.CreateAsync();
        Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 100
        });
        Console.WriteLine("Navegador WebKit lanzado correctamente");

        Context = await Browser.NewContextAsync();
        Page = await Context.NewPageAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Browser.CloseAsync();
    }
}