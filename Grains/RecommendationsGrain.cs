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
    public class RecommendationsGrain : Grain<Recommendations>, IRecommendationsGrain
    {
        public bool UpdateRequired;
        public List<Recommendation> Recommendations;


        public async Task NewRecommendationsAvailable()
        {
            UpdateRequired = true;
        }

        public async Task<Recommendation> GetProductRecommendation(string productId)
        {
            if (UpdateRequired == true || Recommendations == null)
            {
                Recommendations = this.State.LatestRecommendations;
                UpdateRequired = false;
            }

            var recommendation = Recommendations.FirstOrDefault(r => r.ProductId == productId);
            if (recommendation == null)
            {
                //return 404
            }
            return recommendation;
        }
    }
}
