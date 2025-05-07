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
        await Methods.Click(Page, "//button[@class='iconButton_button__A_Uiu searchbox_searchButton__LxebD']", "Enter");
    }

    //[Test]
    public async Task HasTitle()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
    }

    //A ver si esta vez funciona
    //[Test]
    public async Task HasTitle2()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
    }
    //Otro test mas para ver que esto funciona ***************************TEST3***************++
    //[Test]
    public async Task Hola()
    {
        await Page.GotoAsync("https://playwright.dev");
        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
        // Expect an element to be visible on the page.
        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Get started" })).ToBeVisibleAsync();
        // Click the get started link.
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();
        // Expects page to have a heading with the name of Installation.
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    }
}