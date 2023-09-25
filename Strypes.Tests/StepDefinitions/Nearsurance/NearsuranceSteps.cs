using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Strypes.Core.Pages.Nearsurance;
using TechTalk.SpecFlow;

namespace Strypes.Tests.StepDefinitions.Nearsurance;

[Binding]
public sealed class NearsuranceSteps : BasePageSteps<NearsurancePage>
{
    public NearsuranceSteps(ScenarioContext scenarioContext) : base(scenarioContext, p => new NearsurancePage(p)) { }

    [Then(@"the following paragraph headings are displayed in the content")]
    public async Task ThenTheParagraphHeadingsAreDisplayedInTheContent(List<string> paragraphs)
    {
        var uiData = (await Task.WhenAll((await this.Page.GetAllParagraphs()).Select(async p => await p.Heading).ToList()));
        uiData.Should().BeEquivalentTo(paragraphs);
    }
}
