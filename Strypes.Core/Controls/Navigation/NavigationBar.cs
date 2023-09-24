using Microsoft.Playwright;

namespace Strypes.Core.Controls.Navigation;

public class NavigationBar : BaseControl
{
    public NavigationBar(ILocator parent) : base(parent) { }

    private ILocator ResourcesLink => this.Find("li[class*='menu-item']", "Resources");
    private ILocator BlogsLink => this.Find("a[class*='sub-item']", "Blog");

    public async Task Blogs()
    {
        await this.ResourcesLink.ClickAsync();
        await this.BlogsLink.ClickAsync();
    }
}
