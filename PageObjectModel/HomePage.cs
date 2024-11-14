using Microsoft.Playwright;

namespace TestProject.PageObjectModel
{
    public class HomePage : BasePage
    {
        public readonly IPage _page;

        public HomePage(IPage page) : base(page)
        {
            _page = page;
        }

        public ILocator Title => _page.Locator("[data-test='title']");
        public ILocator Tshirt => _page.Locator("[data-test='inventory-item-name']").GetByText("Sauce Labs Bolt T-Shirt");
        public ILocator BackToProducts => _page.Locator("[data-test='back-to-products']");
    }
}