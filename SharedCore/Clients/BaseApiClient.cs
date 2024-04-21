using Microsoft.Extensions.Logging;
using RestSharp;
using SharedCore.Extensions;

namespace SharedCore.Clients;

public abstract class BaseApiClient(ILogger<BaseApiClient> logger, string baseUrl)
{
    protected async Task<T?> SendRequest<T>(string endpoint,  Method method, string? body = null, ICollection<KeyValuePair<string, string>>? headers = null)
    {
        var client = new RestClient(baseUrl);
        var request = new RestRequest(endpoint, method);

        if (headers != null)
            request.AddHeaders(headers);
        if (body != null)
            request.AddJsonBody(body);
        
        logger.LogInformation("Sending request to endpoint: {endpoint}", endpoint);

        RestResponse responseMessage = await client.ExecuteAsync(request);
        
        logger.LogInformation("Parsing http response: {responseMessage}", responseMessage);

        return await HandleResponse<T>(responseMessage);
    }

    private static Task<T?> HandleResponse<T>(RestResponse response)
    {
        string stringResponse = response.Content!;

        return Task.FromResult(stringResponse.ParseJson<T>());
    }
}