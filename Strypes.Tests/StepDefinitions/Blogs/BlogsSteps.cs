using System.Threading.Tasks;
using FluentAssertions;
using Strypes.Core.Pages.Blogs;
using TechTalk.SpecFlow;

namespace Strypes.Tests.StepDefinitions.Blogs;

[Binding]
public sealed class BlogsSteps : BasePageSteps<BlogsPage>
{
    public BlogsSteps(ScenarioContext scenarioContext) : base(scenarioContext, p => new BlogsPage(p)) { }

    [When(@"the blogs sub-tab '(.*)' is opened")]
    public async Task WhenTheBlogsSubTabIsOpened(string tab) => await this.Page.SelectTab(tab);

    [Then(@"the number of displayed blogs is greater than or equal to '(\d+)'")]
    public async Task ThenTheNumberOfDisplayedNewsIs(int number) => (await this.Page.GetAllBlogs()).Count.Should().BeGreaterThanOrEqualTo(number);
}
