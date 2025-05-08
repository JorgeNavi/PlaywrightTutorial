


using Microsoft.Playwright;
using NUnit.Framework.Constraints;

namespace PlaywrightEnsayo;

public class TestsMethods {

    private readonly IPage _page;

    public TestsMethods(IPage page)
    {
        _page = page ?? throw new ArgumentNullException(nameof(page));
    }

    public async Task GoToDemoQA()
    {
        await _page.GotoAsync("https://demoqa.com");
    }

    public async Task OpenAndFillFormInDemoQA()
    {
        await GoToDemoQA();
        await Methods.Click(_page, "//div[contains(@class, 'card-body')]/h5[text()='Forms']");
        await Methods.Click(_page, "//span[text()='Practice Form']");
        await Methods.SendKeys(_page, "//input[@id='firstName']", "Jorge");
        await Methods.SendKeys(_page, "//input[@id='lastName']", "Moratalla");
        await Methods.SendKeys(_page, "//input[@id='userEmail']", "example@example.com");
        await Methods.Click(_page, "//input[@value='Male']");
        await Methods.SendKeys(_page, "//input[@id='userNumber']", "623457889");
        await Methods.SendKeys(_page, "//input[@id='dateOfBirthInput']", "11/11/2011");
        await Methods.Click(_page, "//input[@id='hobbies-checkbox-2']");
        await Methods.Click(_page, "//input[@id='submit']");
    }
}


