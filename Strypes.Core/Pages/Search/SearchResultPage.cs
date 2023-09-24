using Microsoft.Playwright;
using Strypes.Core.Extensions;
using Strypes.Core.Pages.Search.Controls;
using Strypes.Core.Pages.Search.DTO;

namespace Strypes.Core.Pages.Search;
public class SearchResultPage : BasePage
{
    public SearchResultPage(IPage parent) : base(parent) { }

    private ILocator ResultTitleLocator => this.Find("div[class='results-for'] h2").First;
    private ILocator ResultsContainer => this.Find("div[class*='elementor-posts-container']");
    private ILocator ResultLocator => this.ResultsContainer.Locator("article");
    private Task<IEnumerable<SearchResult>> AllSearchResults =>
        this.ResultLocator.SelectAll(locator => new SearchResult(locator));

    public Task<string> Title => this.ResultTitleLocator.InnerTextAsync();
    public async Task<List<SearchResultData>> GetAllSearchResultsData()
    {
        await this.ResultLocator.WaitToBeVisible();
        var list = new List<SearchResultData>();
        foreach (var item in await this.AllSearchResults)
        {
            list.Add(await item.GetData());
        }

        return list;
    }
}
