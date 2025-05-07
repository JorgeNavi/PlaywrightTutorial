using Microsoft.Playwright;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace PlaywrightEnsayo
{
    public static class Methods
    {

        public static async Task SendKeys (IPage page, string xpath, string text)
        {
            //Use the XPath locator to fill the input field
            await page.Locator($"xpath={xpath}").FillAsync(text);
        }

         public static async Task Click (IPage page, string xpath, string key)
        {
            await page.PressAsync(xpath, key);
        }

        public static async Task ClickAsync(IPage page, string selector)
        {
            await page.ClickAsync(selector);
        }

        public static async Task<string> GetInnerTextAsync(IPage page, string selector)
        {
            return await page.InnerTextAsync(selector);
        }

        public static async Task<bool> ElementExistsAsync(IPage page, string selector)
        {
            var element = await page.QuerySelectorAsync(selector);
            return element != null;
        }

        public static async Task WaitForSelectorAsync(IPage page, string selector, int timeout = 5000)
        {
            await page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions
            {
                Timeout = timeout
            });
        }
    }
}