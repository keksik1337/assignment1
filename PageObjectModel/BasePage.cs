using Microsoft.Playwright;
using TestProject.Utils;

namespace TestProject.PageObjectModel
{
    public class BasePage
    {
        private readonly IPage _page;
        private readonly string _baseUrl;

        public BasePage(IPage page)
        {
            _page = page;
            _baseUrl = Config.BaseUrl;
        }

        public async Task GoTo()
        {
            await _page.GotoAsync(_baseUrl);
        }
    }
}
