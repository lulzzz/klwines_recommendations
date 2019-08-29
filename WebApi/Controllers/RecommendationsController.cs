using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using GrainInterfaces;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly int RecommendationsGrainId;
        private readonly Lazy<IClusterClient> Client;
        private readonly IRecommendationsGrain RecommendationsGrain;

        public RecommendationController(Lazy<IClusterClient> client)
        {
            Client = client;
            RecommendationsGrain = this.Client.Value.GetGrain<IRecommendationsGrain>(RecommendationsGrainId);
        }


        [HttpPut("")] //method called by machine learning application after running
        public async Task NewRecommendationsAvailable()
        {
            await RecommendationsGrain.NewRecommendationsAvailable();
        }

        [HttpGet("{productId}/recommendations")] //returns the recommendations for a given a product
        public async Task<List<SKU>> GetProductRecommendations(string productId)
        {
            var recommendationGrain = this.Client.Value.GetGrain<IRecommendationGrain>(productId);
            var recommendedSKUs = await recommendationGrain.GetRecommendedSKUs(productId);
            return recommendedSKUs;
        }
    }
}