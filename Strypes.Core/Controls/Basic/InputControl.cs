using Microsoft.Playwright;

namespace Strypes.Core.Controls.Basic;
public abstract class InputControl<T> : BaseControl
{
    protected InputControl(ILocator parent) : base(parent) { }

    public Task<T> Value => this.OnGetValue();

    public async Task SetValue(T value) => await this.OnSetValue(value);

    public async Task Clear() => await this.OnClearValue();

    protected abstract Task<T> OnGetValue();
    protected abstract Task OnSetValue(T value);
    protected abstract Task OnClearValue();
}
