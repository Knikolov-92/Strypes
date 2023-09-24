using Microsoft.Playwright;
using Strypes.Core.Controls.Basic;
using Strypes.Core.Extensions;
using Strypes.Core.Pages.Careers.Controls;
using Strypes.Core.Pages.Careers.Enums;

namespace Strypes.Core.Pages.Careers;
public class CareersPage : BasePage
{
    public CareersPage(IPage parent) : base(parent) { }

    public Dropdown DepartmentsDropdown => new(this.Find("[data-type='dropdown']"));

    private ILocator ResultsContainer => this.Find("[class*='posts-container']");
    private ILocator OpenPositionLocator => this.ResultsContainer.Locator("article");
    private Task<IEnumerable<OpenPosition>> AllOpenPositions =>
        this.OpenPositionLocator.SelectAll(locator => new OpenPosition(locator));

    public async Task SelectDepartment(Departments department) => await this.DepartmentsDropdown.SetValue(department.GetValue());

    public async Task<OpenPosition> GetOpenPosition(string positionName)
    {
        await this.OpenPositionLocator.WaitToBeVisible();
        return await this.AllOpenPositions.FirstAsync(async p => (await p.Title).Trim().Equals(positionName));
    }
}
