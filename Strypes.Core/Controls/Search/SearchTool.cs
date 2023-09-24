using Microsoft.Playwright;
using Strypes.Core.Controls.Basic;

namespace Strypes.Core.Controls.Search;
public class SearchTool : BaseControl
{
    public SearchTool(ILocator parent) : base(parent) { }

    private ILocator FormLocator => this.Find("form:visible");
    private TextInput SearchField => new(this.FormLocator.Locator("input:visible"));

    public async Task Open()
    {
        await this.WaitUntilVisible();
        await this.Parent.ClickAsync();
    }

    public async Task Search(string text)
    {
        await this.Open();
        await this.SearchField.SetValue(text);
    }
}
