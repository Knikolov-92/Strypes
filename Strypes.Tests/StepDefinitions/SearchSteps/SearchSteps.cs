using System.Threading.Tasks;
using Strypes.Core.Pages.Home;
using TechTalk.SpecFlow;

namespace Strypes.Tests.StepDefinitions.SearchSteps;

[Binding]
public sealed class SearchSteps : BasePageSteps<HomePage>
{
    public SearchSteps(ScenarioContext scenarioContext) : base(scenarioContext, p => new HomePage(p)) { }

    [When(@"a search by keyword ""(.*)"" is made")]
    public async Task WhenASearchByKeywordIsMade(string keyword) => await this.Page.SearchTool.Search(keyword);
}
