using Microsoft.Playwright;
using Strypes.Core.Controls.Navigation;
using Strypes.Core.Pages.Search.Controls;

namespace Strypes.Core.Pages.Home;
public class HomePage : BasePage
{
    public HomePage(IPage parent) : base(parent) { }

    public SearchTool SearchTool => new(this.Find("[data-widget_type='search-form.default']:visible"));
    public NavigationBar NavBar => new(this.Find("section[class*='main-menu-header'] nav[class*='nav-menu--main']:visible"));
}
