using Microsoft.Playwright;
using Strypes.Core.Pages.Search.Controls;

namespace Strypes.Core.Pages.Home;
public class HomePage : BasePage
{
    public HomePage(IPage parent) : base(parent) { }

    public SearchTool SearchTool => new(this.Find("[data-widget_type='search-form.default']:visible"));
}
