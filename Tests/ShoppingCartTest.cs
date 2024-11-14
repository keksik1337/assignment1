using Microsoft.Playwright.NUnit;
using TestProject.PageObjectModel;
using TestProject.PageObjectModel.Sections;

namespace Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ShoppingCartTest : PageTest
{

    private BasePage _basePage;
    private NavigationBar _navigationBar;
    private LoginPage _loginPage;
    private HomePage _homePage;
    private ItemPage _itemPage;
    private CartPage _cartPage;
    private CheckoutInfoPage _checkoutPage;
    private CheckoutOverviewPage _overviewPage;
    private CheckoutCompletePage _completePage;

    [SetUp]
    public void SetUp()
    {
        _basePage = new BasePage(Page);
        _navigationBar = new NavigationBar(Page);
        _loginPage = new LoginPage(Page);
        _homePage = new HomePage(Page);
        _itemPage = new ItemPage(Page);
        _cartPage = new CartPage(Page);
        _checkoutPage = new CheckoutInfoPage(Page);
        _overviewPage = new CheckoutOverviewPage(Page);
        _completePage = new CheckoutCompletePage(Page);
    }

    [Test]
    public async Task ShoppingTest()
    {
        Console.WriteLine("Open home page");
        await _basePage.GoTo();

        Console.WriteLine("Log in");
        await _loginPage.Login();

        await Expect(_homePage.Title).ToHaveTextAsync("Products");

        Console.WriteLine("Select Tshirt");
        await _homePage.Tshirt.ClickAsync();
        await Expect(_homePage.BackToProducts).ToBeVisibleAsync();

        Console.WriteLine("Add Tshirt to shopping cart");
        await _itemPage.AddToCart.ClickAsync();
        await Expect(_navigationBar.ShoppingCartBadge).ToBeVisibleAsync();
        await Expect(_navigationBar.ShoppingCartBadge).Not.ToBeEmptyAsync();

        var ItemName = await _itemPage.Name.InnerTextAsync();
        var ItemPrice = await _itemPage.Price.InnerTextAsync();
        var ItemDescription = await _itemPage.Description.InnerTextAsync();

        Console.WriteLine("Open shopping cart");
        await _navigationBar.ShoppingCart.ClickAsync();
        await Expect(_cartPage.Title).ToHaveTextAsync("Your Cart");
        await Expect(_cartPage.ItemQuantity).ToHaveTextAsync("1");
        await Expect(_cartPage.ItemName).ToHaveTextAsync(ItemName);
        await Expect(_cartPage.ItemDescription).ToHaveTextAsync(ItemDescription);
        await Expect(_cartPage.ItemPrice).ToHaveTextAsync(ItemPrice);

        Console.WriteLine("Click on Checkout button");
        await _cartPage.CheckoutBtn.ClickAsync();
        await Expect(_checkoutPage.Title).ToHaveTextAsync("Checkout: Your Information");

        Console.WriteLine("Fill customer info and continue");
        await _checkoutPage.FillCustomerInfo();
        await _checkoutPage.ContinueBtn.ClickAsync();

        await Expect(_overviewPage.Title).ToHaveTextAsync("Checkout: Overview");
        await Expect(_overviewPage.ItemName).ToHaveTextAsync(ItemName);
        await Expect(_overviewPage.ItemDescription).ToHaveTextAsync(ItemDescription);
        await Expect(_overviewPage.ItemPrice).ToHaveTextAsync(ItemPrice);
        await Expect(_overviewPage.ItemQuantity).ToHaveTextAsync("1");
        await Expect(_overviewPage.TotalPrice).ToContainTextAsync("$17.27");

        Console.WriteLine("Click on Finish button");
        await _overviewPage.FinishBtn.ClickAsync();
        await Expect(_completePage.Title).ToHaveTextAsync("Checkout: Complete!");
        await Expect(_completePage.CompleteHeader).ToHaveTextAsync("Thank you for your order!");

        Console.WriteLine("Log out");
        await _navigationBar.Logout();
        await _loginPage.Username.IsVisibleAsync();
        await _loginPage.Password.IsVisibleAsync();
        await _loginPage.LoginButton.IsVisibleAsync();
    }
}