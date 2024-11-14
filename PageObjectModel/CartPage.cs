using Microsoft.Playwright;

namespace TestProject.PageObjectModel
{
    public class CartPage : BasePage
    {
        public readonly IPage _page;

        public CartPage(IPage page) : base(page)
        {
            _page = page;
        }

        public ILocator Title => _page.Locator("[data-test='title']");
        public ILocator ItemName => _page.Locator("[data-test='inventory-item-name']");
        public ILocator ItemDescription => _page.Locator("[data-test='inventory-item-desc']");
        public ILocator ItemPrice => _page.Locator("[data-test='inventory-item-price']");
        public ILocator ItemQuantity => _page.Locator("[data-test='item-quantity']");
        public ILocator CheckoutBtn => _page.Locator("[data-test='checkout']");
    }
}
