using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Strypes.Tests.StepDefinitions.Navigation
{
    [Binding]
    public sealed class NavigationSteps : BasePageSteps
    {
        public NavigationSteps(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"the '(.*)' page has been opened")]
        public async Task GivenThePageHasBeenOpened(string page)
        {
            switch (page)
            {
                case "Careers":
                    await this.App.Careers();
                    break;
                case "Contact":
                    await this.App.Contact();
                    break;
                case "Home":
                    await this.App.Home();
                    break;
                default:
                    throw new Exception($"Navigation to page {page} is not implemented");
            }
        }
    }
}
