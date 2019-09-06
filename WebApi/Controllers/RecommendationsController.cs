using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO;
using GrainInterfaces;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly int InventoryGrainId;
        private readonly Lazy<IClusterClient> Client;
        private readonly IInventoryGrain InventoryGrain;

        public RecommendationController(Lazy<IClusterClient> client)
        {
            Client = client;
            InventoryGrain = this.Client.Value.GetGrain<IInventoryGrain>(InventoryGrainId);
        }


        [HttpPut("updaterecommendations")] //method called by machine learning application after running
        public async Task NewRecommendationsAvailable()
        {
            await InventoryGrain.UpdateAllProductRecommendations();
        }

        [HttpGet("{productId}/recommendations")] //returns the recommendations for a given a product
        public async Task<List<ProductDTO>> GetProductRecommendations(string productId)
        {
            var recommendationGrain = this.Client.Value.GetGrain<IRecommendationGrain>(productId);
            var recommendations = await recommendationGrain.GetRecommendations();
            return recommendations;
        }
    }
}
