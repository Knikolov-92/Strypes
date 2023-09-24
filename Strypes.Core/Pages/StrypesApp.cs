using Microsoft.Playwright;
using Strypes.Core.Pages.Careers;
using Strypes.Core.Pages.Contact;
using Strypes.Core.Pages.Home;

namespace Strypes.Core.Pages;
public class StrypesApp
{
    private readonly IPage page;

    public StrypesApp(IPage page)
    {
        this.page = page;
    }

    public Task<HomePage> Home() => this.NavigateTo("strypes.eu", p => new HomePage(p));
    public Task<ContactPage> Contact() => this.NavigateTo("contact", p => new ContactPage(p));
    public Task<CareersPage> Careers() => this.NavigateTo("careers", p => new CareersPage(p));

    private async Task<TPage> NavigateTo<TPage>(string urlPath, Func<IPage, TPage> create) where TPage : BasePage
    {
        if (!this.page.Url.EndsWith($"{urlPath}/"))
        {
            await this.page.GotoAsync(urlPath);
        }

        await this.page.WaitForURLAsync($"**/{urlPath}/");
        return create(this.page);
    }
}
