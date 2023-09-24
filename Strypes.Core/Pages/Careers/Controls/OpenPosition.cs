using Microsoft.Playwright;
using Strypes.Core.Controls;

namespace Strypes.Core.Pages.Careers.Controls;
public class OpenPosition : BaseControl
{
    public OpenPosition(ILocator parent) : base(parent) { }

    private ILocator TitleLocator => this.Find("h2");
    private ILocator ViewButton => this.Find("a[class*='button-link']", "View");

    public Task<string> Title => this.TitleLocator.InnerTextAsync();
    public async Task View() => await this.ViewButton.ClickAsync();
}
