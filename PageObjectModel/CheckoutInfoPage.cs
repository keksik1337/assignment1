using Microsoft.Playwright;
using TestProject.Utils;

namespace TestProject.PageObjectModel
{
    public class CheckoutInfoPage : BasePage
    {
        public readonly IPage _page;
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _zipCode;

        public CheckoutInfoPage(IPage page) : base(page)
        {
            _page = page;
            _firstName = Config.FirstName;
            _lastName = Config.LastName;
            _zipCode = Config.ZipCode;
        }

        public ILocator Title => _page.Locator("[data-test='title']");
        public ILocator FirstName => _page.Locator("[data-test='firstName']");
        public ILocator LastName => _page.Locator("[data-test='lastName']");
        public ILocator ZipCode => _page.Locator("[data-test='postalCode']"); 
        public ILocator ContinueBtn => _page.Locator("[data-test='continue']");

        public async Task FillCustomerInfo()
        {
            await FirstName.FillAsync(_firstName);
            await LastName.FillAsync(_lastName);
            await ZipCode.FillAsync(_zipCode);
        }
    }
}