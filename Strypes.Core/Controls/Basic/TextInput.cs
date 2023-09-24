using Microsoft.Playwright;

namespace Strypes.Core.Controls.Basic;
public class TextInput : InputControl<string>
{
    public TextInput(ILocator parent) : base(parent) { }

    protected override async Task OnClearValue() => await this.Parent.FillAsync("");

    protected override Task<string> OnGetValue() => this.Parent.InputValueAsync();

    protected override async Task OnSetValue(string value)
    {
        await this.Parent.FillAsync("");
        await this.Parent.FillAsync(value);
        await this.Parent.PressAsync("Enter");
    }
}
