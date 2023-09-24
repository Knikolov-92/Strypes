using Strypes.Core.Controls.Basic;

namespace Strypes.Core.Extensions;
public static class ControlsExtensions
{
    public static async Task SafeSet<T>(this T control, string? value) where T : InputControl<string>
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            await control.SetValue(value);
        }
    }
}
