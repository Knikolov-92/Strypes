namespace Strypes.Core.Extensions;
public static class StringExtensions
{
    public static bool ContainsIgnoreCase(this string text, string target) => text.Contains(target, StringComparison.InvariantCultureIgnoreCase);
}
