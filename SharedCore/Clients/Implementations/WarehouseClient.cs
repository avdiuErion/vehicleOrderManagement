using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using SharedCore.Clients.Interfaces;
using SharedCore.Dtos;

namespace SharedCore.Clients.Implementations;

public class WarehouseClient(IConfiguration configuration, ILogger<WarehouseClient> logger)
    : BaseApiClient(logger, configuration["WarehouseBaseUrl"]), IWarehouseClient
{
    public async Task<InventoryResponseDto?> GetStockItems()
    {
        string endpoint = "Warehouse/GetAll";
        
        return await SendRequest<InventoryResponseDto>(endpoint, Method.Get);
    }
}