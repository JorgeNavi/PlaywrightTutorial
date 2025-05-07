using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace PlaywrightEnsayo;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ExampleTest : CustomPageTest
{

    [Test]
    public async Task SearchPlaywrightInDuckDuclGO()
    {
        await Page.GotoAsync("https://duckduckgo.com");
        Console.WriteLine("Página abierta: " + Page.Url);
        await Methods.SendKeys(Page, "//input[@id='searchbox_input']", "Playwright");
        await Methods.Click(Page, "//button[@class='iconButton_button__A_Uiu searchbox_searchButton__LxebD']");
    }

}