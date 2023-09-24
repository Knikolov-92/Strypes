using Microsoft.Playwright;
using Strypes.Core.Extensions;
using Strypes.Core.Pages.Blogs.Controls;

namespace Strypes.Core.Pages.Blogs;
public class BlogsPage : BasePage
{
    public BlogsPage(IPage parent) : base(parent) { }

    private ILocator TabsContainer => this.Find("ul[class*='post__header']:visible");
    private ILocator TabLocator(string name) => this.TabsContainer.Locator("li", name);
    private ILocator BlogsContainer => this.Find("div[class*='post__body']");
    private ILocator BlogLocator => this.BlogsContainer.Locator("[class*='post-wrapper']");
    private ILocator BlogLoader => this.Find("div[class*='post-loader']");
    private Task<IEnumerable<BlogTile>> AllBlogs => this.BlogLocator.SelectAll(locator => new BlogTile(locator));

    public async Task SelectTab(string tab)
    {
        await this.TabLocator(tab).ClickAsync();
        await this.BlogLoader.WaitToBeHidden();
        await this.BlogLoader.WaitToBeDetached();
    }
    public async Task<List<BlogTile>> GetAllBlogs()
    {
        await this.BlogLocator.WaitToBeVisible();
        return (await this.AllBlogs).ToList();
    }
}
