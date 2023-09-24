using Microsoft.Playwright;

namespace Strypes.Core.Extensions;
public static class LocatorExtensions
{
    public static async Task WaitToBeVisible(this ILocator locator) => await locator.WaitToBeState(WaitForSelectorState.Visible);
    private static async Task WaitToBeState(this ILocator locator, WaitForSelectorState state)
    {
        var selector = locator.ToString()!.Replace("Locator@", "");
        await locator.Page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions { State = state });
    }
    public static async Task<IEnumerable<T>> SelectAll<T>(this ILocator element, Func<ILocator, T> factory) => (await element.AllAsync()).Select(factory);

    public static async Task<IEnumerable<string>> AllTextsTrim(this ILocator element) => (await element.AllTextContentsAsync()).Select(t => t.Trim());
}
