using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualBasic;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace PlaywrightEnsayo;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ExampleTest : CustomPageTest
{
    private TestsMethods testMethods;

    [SetUp]
    public void Init()
    {
        testMethods = new TestsMethods(Page);
    }

    [Test]
    public async Task SearchPlaywrightInDuckDuclGO()
    {
        await Page.GotoAsync("https://duckduckgo.com");
        Console.WriteLine("Página abierta: " + Page.Url);
        await Methods.SendKeys(Page, "//input[@id='searchbox_input']", "Playwright");
        await Methods.Click(Page, "//button[@class='iconButton_button__A_Uiu searchbox_searchButton__LxebD']");
    }

    [Test]
    public async Task TestDemoQA_1()
    {
        await testMethods.GoToDemoQA();
    }

    [Test]
    public async Task TestDemoQA_2()
    {
        await testMethods.OpenAndFillFormInDemoQA();
    }

}