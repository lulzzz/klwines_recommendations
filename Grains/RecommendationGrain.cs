using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Core.Exceptions;
using GrainInterfaces;
using Orleans;

namespace Grains
{
    public class RecommendationGrain : Grain<Recommendation>, IRecommendationGrain
    {
        public int RecommendationsGrainId;

        public async Task<List<SKU>> GetRecommendedSKUs(string productId)
        {
            var recommendationsGrain = this.GrainFactory.GetGrain<IRecommendationsGrain>(RecommendationsGrainId);
            var recommendation = await recommendationsGrain.GetProductRecommendation(productId);
            return recommendation.RecommendedSKUs;
        }
    }
}
