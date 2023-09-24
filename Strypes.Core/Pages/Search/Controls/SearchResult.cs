using Microsoft.Playwright;
using Strypes.Core.Controls;
using Strypes.Core.Pages.Search.DTO;

namespace Strypes.Core.Pages.Search.Controls;
public class SearchResult : BaseControl
{
    public SearchResult(ILocator parent) : base(parent) { }

    private ILocator TitleLocator => this.Find("[class*='post__title']");
    private ILocator TextContentLocator => this.Find("[class*='post__excerpt']");

    public Task<string> Title => this.TitleLocator.InnerTextAsync();
    public Task<string> Content => this.TextContentLocator.InnerTextAsync();

    public async Task<SearchResultData> GetData() => new SearchResultData(await this.Title, await this.Content);
}
