using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrainInterfaces;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Orleans;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly string ProductId;
        private readonly Lazy<IClusterClient> Client;
        private readonly IRecommendationGrain RecommendationGrain;

        public RecommendationController(Lazy<IClusterClient> client, string productId)
        {
            Client = client;
            ProductId = productId;
            RecommendationGrain = this.Client.Value.GetGrain<IRecommendationGrain>(ProductId);
        }


        [HttpGet("")]
        public async Task<List<string>> GetRecommendations()
        {
            var recommendations = await RecommendationGrain.GetRecommendations(ProductId);
            return recommendations;
        }

        [HttpPost("latestRecVersion")]
        public async Task UpdateRecVersion(int latestRecVersion)
        {

        }
    }
}
