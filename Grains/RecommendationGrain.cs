using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrainInterfaces;
using Orleans;
using Domain;
using System.Linq;
using Domain.Core.Exceptions;

namespace Grains
{
    public class RecommendationGrain : Grain<Recommendation>, IRecommendationGrain
    {
        public bool UpdateRequired;
        public List<List<string>> Recommendations;


        public async Task<List<string>> GetRecommendations(string productId)
        {
            if (UpdateRequired = true)
            {
                await UpdateRecommendations();
            }

            var recommendations = Recommendations.First(recList => recList.Contains($"Id: {productId}"));
            if (recommendations == null)
            {
                throw new ProductDoesNotExistException();
            }

            return recommendations;
        }

        public async Task RequiresUpdate()
        {
            UpdateRequired = true;
        }

        public async Task UpdateRecommendations()
        {
            Recommendations = this.State.Recommendations;
            UpdateRequired = false;
        }
    }
}
