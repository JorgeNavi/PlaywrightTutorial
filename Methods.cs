using Microsoft.Playwright;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace PlaywrightEnsayo
{
    public class Methods
    {

        public static async Task SendKeys (IPage page, string xpath, string text)
        {
            try {
            IElementHandle element = await page.Locator($"xpath={xpath}").ElementHandleAsync();
                try {
                    if (element != null)
                    {
                        await element.FillAsync(text);
                    }
                    else
                    {
                        Console.WriteLine($"Element not found for XPath: {xpath}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while filling the element: {ex.Message}");
                }
            } 
            catch (Exception ex) {
                Console.WriteLine($"An error occurred sendign keys: {ex.Message}");
            }
        }

         public static async Task Click (IPage page, string xpath)
        {
            try {
                await page.ClickAsync(xpath);
            }
            catch (Exception ex) {
                Console.WriteLine($"An error occurred during click: {ex.Message}");
            }
        }

        public static async Task ClickElementCovered (IPage page, string xpath)
        {
            try {
                await page.Locator($"xpath={xpath}").ClickAsync(new LocatorClickOptions
                {
                    Force = true
                });
                } catch (Exception ex) {
                Console.WriteLine($"An error occurred during ClickCovered: {ex.Message}");
            }
        }

        public static async Task ScrollToElement (IPage page, string xpath)
        {
            try {
                await page.Locator($"xpath={xpath}").ScrollIntoViewIfNeededAsync();
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred during ScrollToElement: {ex.Message}");
            }
        }

        public static async Task SelectDropdown (IPage page, string xpath, string value)
        {
            try {
                var dropdown = page.Locator($"xpath={xpath}");
                if (await dropdown.CountAsync() == 0)
                {
                    throw new Exception($"Dropdown not found with XPath: {xpath}");
                }
                await dropdown.SelectOptionAsync(new SelectOptionValue { Value = value });
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred during SelectDropdown: {ex.Message}");
            }
        }
    }
}