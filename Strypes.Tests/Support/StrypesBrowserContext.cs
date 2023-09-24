using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Playwright;

namespace Strypes.Tests.Support;
public class StrypesBrowserContext
{
    private readonly IBrowser browser;
    private readonly IOptions<BrowserNewContextOptions> contextOptions;

    public StrypesBrowserContext(IBrowser browser, IOptions<BrowserNewContextOptions> contextOptions)
    {
        this.browser = browser;
        this.contextOptions = contextOptions;
    }
    public string BaseUrl => this.contextOptions.Value.BaseURL;

    public async Task<IBrowserContext> NewContext()
    {
        var context = await this.browser.NewContextAsync(this.contextOptions.Value);
        var page = await context.NewPageAsync();
        await page.GotoAsync("/");
        return context;
    }
}
