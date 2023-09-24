using Microsoft.Playwright;
using Strypes.Core.Controls.Search;

namespace Strypes.Core.Pages.Home;
public class HomePage : BasePage
{
    public HomePage(IPage parent) : base(parent) { }

    public SearchTool SearchTool => new(this.Find("[data-widget_type='search-form.default']:visible"));
}
