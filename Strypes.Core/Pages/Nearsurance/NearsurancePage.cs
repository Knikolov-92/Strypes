using Microsoft.Playwright;
using Strypes.Core.Extensions;
using Strypes.Core.Pages.Nearsurance.Controls;

namespace Strypes.Core.Pages.Nearsurance;
public class NearsurancePage : BasePage
{
    public NearsurancePage(IPage parent) : base(parent) { }

    private ILocator ParagraphContainer => this.Find("section[class*='services-grid']");
    private ILocator ParagraphLocator => this.ParagraphContainer.Locator("div[data-widget_type*='infobox.default']")
        .Filter(new LocatorFilterOptions { Has = this.Find("h5") });
    private Task<IEnumerable<NearsuranceParagraph>> AllParagraphs => this.ParagraphLocator.SelectAll(locator => new NearsuranceParagraph(locator));

    public async Task<List<NearsuranceParagraph>> GetAllParagraphs() => (await this.AllParagraphs).ToList();
}
