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

    //[Test]
    public async Task SearchPlaywrightInDuckDuclGO()
    {
        await Page.GotoAsync("https://duckduckgo.com");
        await Methods.SendKeys(Page, "//input[@id='searchbox_input']", "Playwright");
        await Methods.Click(Page, "//button[@class='iconButton_button__A_Uiu searchbox_searchButton__LxebD']");
    }

    //[Test]
    public async Task TestDemoQA_1()
    {
        await testMethods.GoToDemoQA();
    }

    [Test]
    public async Task TestDemoQA_2()
    {
        await testMethods.OpenAndFillFormInDemoQA();

        ///ASERCIONES:

        //Asegurarnos de que el valor del campo nombre corresponde con lo esperado
        var nameValue = await Page.Locator("xpath=//input[@id='firstName']").InputValueAsync();
        Assert.That(nameValue, Is.EqualTo("Jorge"));

        //Asegurarnos de que el valor del campo apellido corresponde con lo esperado
        var lastNameValue = await Page.Locator("xpath=//input[@id='lastName']").InputValueAsync();
        Assert.That(lastNameValue, Is.EqualTo("Moratalla"));

        //Asegurarnos de que el valor del campo email no es nulo
        var emailValue = await Page.Locator("xpath=//input[@id='userEmail']").InputValueAsync();
        Assert.That(emailValue, Is.Not.Null);

        //Asegurarnos de que el círculo de "Male" está correctamente marcado
        var genderChecked = await Page.Locator("xpath=//input[@id='gender-radio-1']").IsCheckedAsync();
        Assert.That(genderChecked, Is.True, "Aquí pude ir un mensaje opcional");
    }
}