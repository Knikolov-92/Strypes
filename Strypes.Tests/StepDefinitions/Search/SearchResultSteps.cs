using System.Threading.Tasks;
using FluentAssertions;
using Strypes.Core.Extensions;
using Strypes.Core.Pages.Search;
using TechTalk.SpecFlow;

namespace Strypes.Tests.StepDefinitions.Search;

[Binding]
public sealed class SearchResultSteps : BasePageSteps<SearchResultPage>
{
    public SearchResultSteps(ScenarioContext scenarioContext) : base(scenarioContext, p => new SearchResultPage(p)) { }

    [Then(@"the search results for ""(.*)"" are displayed")]
    public async Task ThenTheSearchResultsAreDisplayed(string keyword) => (await this.Page.Title)
        .Should().Be($"Results for: {keyword}", "the keyword should be contained in the page title");

    [Then(@"the search results contain the keyword ""(.*)""")]
    public async Task ThenTheSearchResultsContainTheKeyword(string keyword)
    {
        var results = await this.Page.GetAllSearchResultsData();
        results.Should().AllSatisfy(result =>
        {
            var containsKeyword = result.Title.ContainsIgnoreCase(keyword) ||
                                  result.Content.ContainsIgnoreCase(keyword);
            containsKeyword.Should().BeTrue();
        }, "all results should contain the keyword in the title or the content");
    }
}
