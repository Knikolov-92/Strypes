using Microsoft.Playwright;

namespace Strypes.Core.Extensions;
public static class LocatorExtensions
{
    public static async Task WaitToBeVisible(this ILocator locator) => await locator.WaitToBeState(WaitForSelectorState.Visible);
    public static async Task<IEnumerable<T>> SelectAll<T>(this ILocator element, Func<ILocator, T> factory) => (await element.AllAsync()).Select(factory);
    public static async Task<IEnumerable<string>> AllTextsTrim(this ILocator element) => (await element.AllTextContentsAsync()).Select(t => t.Trim());
    public static Task<bool> HasElement(this ILocator locator, string selector) => locator.Locator(selector).CountAsync().ContinueWith(t => t.Result > 0);

    private static async Task WaitToBeState(this ILocator locator, WaitForSelectorState state)
    {
        var selector = locator.ToString()!.Replace("Locator@", "");
        await locator.Page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions { State = state });
    }
}
