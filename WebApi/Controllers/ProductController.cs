using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrainInterfaces;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly string ProductId;
        private readonly Lazy<IClusterClient> Client;
        private readonly IProductGrain ProductGrain;

        public ProductController(Lazy<IClusterClient> client, string productId)
        {
            Client = client;
            ProductId = productId;
            ProductGrain = this.Client.Value.GetGrain<IProductGrain>(ProductId);
        }

        [HttpGet("")]
        public async Task<List<string>> GetRecomendations()
        {
            var product = ProductGrain.Get();
            return await ProductGrain.GetRecomendations();
        }

        [HttpPut("{version}")]
        public async Task UpdateToLatestVersion(int version)
        {
            await ProductGrain.UpdateToLatestVersion(version);
        }
    }
}
