using System;
using System.Threading.Tasks;
using Strypes.Core.Pages.Home;
using TechTalk.SpecFlow;

namespace Strypes.Tests.StepDefinitions.Navigation;

[Binding]
public sealed class NavigationBarSteps : BasePageSteps<HomePage>
{
    public NavigationBarSteps(ScenarioContext scenarioContext) : base(scenarioContext, p => new HomePage(p)) { }

    [Given(@"the '(.*)' page has been opened by navigating from navigation bar")]
    public async Task GivenThePageHasBeenOpenedByNavigatingFromNavigationBar(string page)
    {
        switch (page)
        {
            case "Blogs":
                await this.Page.NavBar.Blogs();
                break;
            default:
                throw new Exception($"Navigation to page {page} is not implemented");
        }
    }
}
