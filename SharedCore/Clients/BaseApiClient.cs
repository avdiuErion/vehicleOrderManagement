using RestSharp;
using SharedCore.Extensions;

namespace SharedCore.Clients;

public abstract class BaseApiClient(string baseUrl)
{
    protected async Task<T?> SendRequest<T>(string endpoint, string body, Method method, ICollection<KeyValuePair<string, string>>? headers = null)
    {
        var client = new RestClient(baseUrl);
        var request = new RestRequest(endpoint, method);

        if (headers != null)
            request.AddHeaders(headers);
        
        request.AddJsonBody(body);

        RestResponse responseMessage = await client.ExecuteAsync(request);

        return await HandleResponse<T>(responseMessage);
    }

    private static Task<T?> HandleResponse<T>(RestResponse response)
    {
        string stringResponse = response.Content!;

        return Task.FromResult(stringResponse.ParseJson<T>());
    }
}