using Microsoft.Playwright;

namespace TestProject.PageObjectModel
{
    public class ItemPage : BasePage
    {
        public readonly IPage _page;

        public ItemPage(IPage page) : base(page)
        {
            _page = page;
        }

        public ILocator BackToProducts => _page.Locator("[data-test='back-to-products']");
        public ILocator AddToCart => _page.Locator("[data-test='add-to-cart']");
        public ILocator Name => _page.Locator("[data-test='inventory-item-name']");
        public ILocator Description => _page.Locator("[data-test='inventory-item-desc']");
        public ILocator Price => _page.Locator("[data-test='inventory-item-price']");
    }
}
