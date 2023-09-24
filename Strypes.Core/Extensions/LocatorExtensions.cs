using Microsoft.Playwright;

namespace Strypes.Core.Extensions;
public static class LocatorExtensions
{
    public static async Task WaitToBeVisible(this ILocator locator) => await locator.WaitToBeState(WaitForSelectorState.Visible);
    public static async Task WaitToBeHidden(this ILocator locator) => await locator.WaitToBeState(WaitForSelectorState.Hidden);
    public static async Task WaitToBeDetached(this ILocator locator) => await locator.WaitToBeState(WaitForSelectorState.Detached);
    public static async Task<IEnumerable<T>> SelectAll<T>(this ILocator element, Func<ILocator, T> factory) => (await element.AllAsync()).Select(factory);
    public static async Task<IEnumerable<string>> AllTextsTrim(this ILocator element) => (await element.AllTextContentsAsync()).Select(t => t.Trim());
    public static ILocator Locator(this ILocator locator, string selector, string text) => locator.Locator(selector).Filter(new LocatorFilterOptions { HasText = text });

    private static async Task WaitToBeState(this ILocator locator, WaitForSelectorState state)
    {
        var selector = locator.ToString()!.Replace("Locator@", "");
        await locator.Page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions { State = state });
    }
}
