namespace Strypes.Core.Extensions;
public static class TaskExtensions
{
    public static async Task<T> FirstAsync<T>(this Task<IEnumerable<T>> items, Func<T, Task<bool>> predicate) => (await items.QueryAsync(predicate)).First(t => t.result).item;

    private static async Task<(bool result, T item)[]> QueryAsync<T>(this Task<IEnumerable<T>> items, Func<T, Task<bool>> predicate) =>
        await Task.WhenAll((await items).Select(async item => (result: await predicate(item), item)));
}
