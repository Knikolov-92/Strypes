using Microsoft.Playwright;
using Strypes.Core.Extensions;

namespace Strypes.Core.Controls;
public class BaseControl
{
    public BaseControl(ILocator parent)
    {
        this.Parent = parent;
    }

    protected ILocator Parent { get; private set; }

    protected ILocator Find(string selector) => this.Parent.Locator(selector);
    protected ILocator Find(string selector, string text) =>
        this.Parent.Locator(selector).Filter(new LocatorFilterOptions { HasText = text });
    public Task<bool> IsVisible() => this.Parent.IsVisibleAsync();
    public async Task WaitUntilVisible() => await this.Parent.WaitToBeVisible();
}
