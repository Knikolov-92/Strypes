using Microsoft.Playwright;

namespace Strypes.Core.Controls.Basic;
public class Dropdown : InputControl<string?>
{
    private ILocator SelectLocator => this.Find("select");

    public Dropdown(ILocator parent) : base(parent) { }

    protected override async Task<string?> OnGetValue() => throw new NotImplementedException();
    protected override Task OnClearValue() => throw new NotImplementedException();
    protected override async Task OnSetValue(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return;

        await this.SelectLocator.SelectOptionAsync(value);
    }
}
