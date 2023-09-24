using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Strypes.Core.Pages.Jobs;
using TechTalk.SpecFlow;

namespace Strypes.Tests.StepDefinitions.Jobs;

[Binding]
public sealed class JobsSteps : BasePageSteps<JobsPage>
{
    public JobsSteps(ScenarioContext scenarioContext) : base(scenarioContext, p => new JobsPage(p)) { }


    [Then(@"the job description for the position ""(.*)"" is displayed")]
    public async Task ThenTheJobDescriptionForThePositionIsDisplayed(string positionName)
    {
        using (new AssertionScope())
        {
            (await this.Page.IsDisplayed()).Should().BeTrue("all required sections should be displayed");
            (await this.Page.Title).Should().Be(positionName, "the details should be displayed for the correct position");
        }
    }
}
