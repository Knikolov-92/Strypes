using Microsoft.Playwright;

namespace Strypes.Core.Controls.Basic;
public class Checkbox : InputControl<bool>
{
    public Checkbox(ILocator parent) : base(parent) { }
    private ILocator CheckboxInput => this.Parent.GetByRole(AriaRole.Checkbox, new LocatorGetByRoleOptions { IncludeHidden = true });

    public Task<bool> IsChecked => this.CheckboxInput.IsCheckedAsync();

    public Task Check() => this.SetValue(true);

    public Task Uncheck() => this.SetValue(false);

    protected override Task OnClearValue() => throw new NotImplementedException();

    protected override Task<bool> OnGetValue() => this.IsChecked;

    protected override async Task OnSetValue(bool value)
    {
        if (await this.IsChecked != value)
        {
            await this.Parent.ClickAsync();
        }
    }
}
