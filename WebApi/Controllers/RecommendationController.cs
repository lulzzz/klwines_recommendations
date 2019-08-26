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
        private readonly int Recommendation;
        private readonly Lazy<IClusterClient> Client;
        private readonly IRecommendationGrain RecommendationGrain;

        public RecommendationController(Lazy<IClusterClient> client)
        {
            Client = client;
            RecommendationGrain = this.Client.Value.GetGrain<IRecommendationGrain>(Recommendation);
        }


        [HttpGet("productId")] //returns the recommendations given a product id
        public async Task<string[]> GetRecommendations(int productId)
        {
            var recommendations = await RecommendationGrain.GetRecommendations(productId);
            return recommendations;
        }

        [HttpPut("")] //method called by machine learning application after it is ran
        public async Task UpdateRecVersion()
        {
            await RecommendationGrain.RequiresUpdate();
        }
    }
}
