using System.Collections;
using System.Text.Json;

namespace SharedCore.Extensions;

public static class StringExtensions
{
    public static T? ParseJson<T>(this string? input)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip
        };
        
        if (input is null || input.Trim() == "[]")
            return default;

        T? deserialized = JsonSerializer.Deserialize<T>(input!, options);

        return deserialized;
    }
}