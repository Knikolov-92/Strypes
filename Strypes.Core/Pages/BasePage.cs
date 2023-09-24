using Microsoft.Playwright;

namespace Strypes.Core.Pages
{
    public class BasePage
    {
        protected BasePage(IPage parent)
        {
            this.Parent = parent;
        }

        protected IPage Parent { get; private set; }
        public string Url => this.Parent.Url;

        protected ILocator Find(string selector) => this.Parent.Locator(selector);
        protected ILocator Find(string selector, string text) => this.Parent.Locator(selector).Filter(new LocatorFilterOptions { HasText = text });
    }
}
