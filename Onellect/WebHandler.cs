using Flurl.Http;

namespace OnellectTest;
public static class WebHandler
{
    public async static void Post(string url, IEnumerable<int> numbers) =>
        await url.PostUrlEncodedAsync(numbers);
}
