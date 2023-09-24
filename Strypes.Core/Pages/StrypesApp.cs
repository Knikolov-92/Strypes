using Microsoft.Playwright;

namespace Strypes.Core.Pages;
public class StrypesApp
{
    private readonly IPage page;

    public StrypesApp(IPage page)
    {
        this.page = page;
    }
}
