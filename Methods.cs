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

        public static async Task SelectRadioButton(IPage page, string selector, bool isXPath = false) //Si usamos el xPath, tenemos que marcar true en la llamada del metodo por paramétro
        {
            try {
                string script = isXPath //si es un XPath,  .evaluate busca el elemento, cogemos el primer resultado, 
                //pasamos el evento a true (el del circulo que queremos selccionar) y lanzamos el evento.
                ? @$"() => {{
                    const el = document.evaluate(""{selector}"", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
                    if (el) {{
                        el.checked = true;
                        el.dispatchEvent(new Event('change', {{ bubbles: true }}));
                    }}
                }}"
                //si es un selector CSS,  .querySelector busca el elemento,
                //pasamos el evento a true (el del circulo que queremos selccionar) y lanzamos el evento.
                : @$"() => {{
                    const el = document.querySelector(""{selector}"");
                    if (el) {{
                        el.checked = true;
                        el.dispatchEvent(new Event('change', {{ bubbles: true }}));
                    }}
                }}";

                await page.EvaluateAsync(script);
            } catch (Exception ex)
                {
                Console.WriteLine($"Error selecting radio button: {ex.Message}");
                }
        }

        public static async Task PressEnter(IPage page)
        {
            try {
                await page.Keyboard.PressAsync("Enter");
            } catch (Exception ex) {
                Console.WriteLine($"Error pressing Enter: {ex.Message}");
            }
        }
    }
}