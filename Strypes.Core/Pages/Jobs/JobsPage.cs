using Microsoft.Playwright;
using Strypes.Core.Extensions;

namespace Strypes.Core.Pages.Jobs;
public class JobsPage : BasePage
{
    public JobsPage(IPage parent) : base(parent) { }

    private ILocator TitleLocator => this.Find("h1");
    private ILocator JobDescriptionSection => this.Find("h2", "JOB DESCRIPTION");
    private ILocator ApplyButton => this.Find("a[class*='button-link']", "Apply now");

    public Task<string> Title => this.TitleLocator.InnerTextAsync();
    public async Task<bool> IsDisplayed()
    {
        await this.ApplyButton.WaitToBeVisible();
        return await this.TitleLocator.IsVisibleAsync() &&
          await this.JobDescriptionSection.IsVisibleAsync() &&
          await this.ApplyButton.IsVisibleAsync();
    }
}
