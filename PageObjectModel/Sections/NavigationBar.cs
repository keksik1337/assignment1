using Microsoft.Playwright;

namespace TestProject.PageObjectModel.Sections
{
    public class NavigationBar : BasePage
    {
        public readonly IPage _page;

        public NavigationBar(IPage page) : base(page)
        {
            _page = page;
        }

        public ILocator ShoppingCart => _page.Locator("[data-test='shopping-cart-link']"); 
        public ILocator ShoppingCartBadge => _page.Locator("[data-test='shopping-cart-badge']");
        public ILocator BurgerMenu => _page.Locator("[id='react-burger-menu-btn']");
        public ILocator LogoutBtn => _page.Locator("[data-test='logout-sidebar-link']");

        public async Task Logout()
        {
            await BurgerMenu.ClickAsync();
            await LogoutBtn.ClickAsync();
        }
    }
}
