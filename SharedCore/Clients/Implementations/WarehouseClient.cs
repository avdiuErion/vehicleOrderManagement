using RestSharp;
using SharedCore.Clients.Interfaces;
using SharedCore.Dtos;

namespace SharedCore.Clients.Implementations;

public class WarehouseClient(string baseUrl) : BaseApiClient(baseUrl), IWarehouseClient
{
    public async Task<InventoryResponseDto?> CheckForInventory(object inventory)
    {
        var endpoint = "CheckForInventory";
        var body = inventory.ToString();

        return await SendRequest<InventoryResponseDto>(endpoint, body!, Method.Post);
    }
}