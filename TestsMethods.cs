


using System.ComponentModel.DataAnnotations;
using Microsoft.Playwright;
using NUnit.Framework.Constraints;
using NUnit.Framework;

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
        await Methods.SelectRadioButton(_page, "//input[@id='gender-radio-1']", true);
        await Methods.SendKeys(_page, "//input[@id='userNumber']", "6234578895");
        await Methods.SendKeys(_page, "//input[@id='dateOfBirthInput']", "11/11/2011");
        await Methods.PressEnter(_page);
        await Methods.SelectRadioButton(_page, "//input[@id='hobbies-checkbox-2']", true);
        await Methods.Click(_page, "//button[@id='submit']");
    }
}


