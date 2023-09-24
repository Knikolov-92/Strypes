using System.Threading.Tasks;
using Strypes.Core.Pages.Careers;
using Strypes.Core.Pages.Careers.Enums;
using TechTalk.SpecFlow;

namespace Strypes.Tests.StepDefinitions.Careers;

[Binding]
public sealed class CareersSteps : BasePageSteps<CareersPage>
{
    public CareersSteps(ScenarioContext scenarioContext) : base(scenarioContext, p => new CareersPage(p)) { }

    [When(@"a search for open positions in ""(.*)"" department is made")]
    public async Task WhenASearchForOpenPostionsInDepartmentIsMade(Departments department) => await this.Page.SelectDepartment(department);

    [When(@"the open position ""(.*)"" is viewed")]
    public async Task WhenTheOpenPositionIsViewed(string positionName) => await (await this.Page.GetOpenPosition(positionName)).View();
}
