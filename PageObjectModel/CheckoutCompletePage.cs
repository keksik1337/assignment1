using Microsoft.Playwright;

namespace TestProject.PageObjectModel
{
    public class CheckoutCompletePage : BasePage
    {
        public readonly IPage _page;

        public CheckoutCompletePage(IPage page) : base(page)
        {
            _page = page;
        }

        public ILocator Title => _page.Locator("[data-test='title']");
        public ILocator CompleteHeader => _page.Locator("[data-test='complete-header']");
    }
}