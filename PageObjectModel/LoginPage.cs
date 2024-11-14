﻿using Microsoft.Playwright;
using TestProject.Utils;

namespace TestProject.PageObjectModel
{
    public class LoginPage : BasePage
    {
        public readonly IPage _page;
        private readonly string _username;
        private readonly string _password;

        public LoginPage(IPage page) : base(page)
        {
            _page = page;
            _username = Config.Username;
            _password = Config.Password;
        }

        public ILocator Username => _page.Locator("[data-test='username']");
        public ILocator Password => _page.Locator("[data-test='password']");
        public ILocator LoginButton => _page.Locator("[data-test='login-button']");

        public async Task Login()
        {
            await Username.FillAsync(_username);
            await Password.FillAsync(_password);
            await LoginButton.ClickAsync();
        }
    }
}
