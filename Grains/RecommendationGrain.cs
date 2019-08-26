using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrainInterfaces;
using Orleans;
using Domain;
using System.Linq;
using Domain.Core.Exceptions;
using Newtonsoft.Json;

namespace Grains
{
    public class RecommendationGrain : Grain<Recommendation>, IRecommendationGrain
    {
        public bool UpdateRequired;
        public List<string> Recommendations;


        // checks if the latest recommendations are in memory
        // then returns the correct SKUs once found
        public async Task<string[]> GetRecommendations(int productId)
        {
            if (UpdateRequired = true || Recommendations == null)
            {
                await UpdateRecommendations();
            }
            var recommendation = Recommendations.First(recList => recList.Contains($"Id: {productId}"));
            if (recommendation == null)
            {
                throw new ProductDoesNotExistException();
            }
            // removes only the SKUs from the recommendation and returns them as a string[]
            var SKUs = recommendation.Split(new char[] { '[', ']' })[1];
            return SKUs.Split(',');
        }


        // method is triggered when database is updated ensuring that the UpdateRecommendations
        // method will be invoked durring the next GetRecommendations call
        public async Task RequiresUpdate()
        {
            UpdateRequired = true;
        }


        // gets the latest version of the recomendations as seperate
        // json strings and adds them to the empty Recommendations list
        public async Task UpdateRecommendations()
        {
            Recommendations = null;
            var recommendations = this.State.Recommendations;
            foreach (var product in recommendations)
            {
                var recommendation = JsonConvert.SerializeObject(product);
                Recommendations.Add(recommendation);
            }
            UpdateRequired = false;
        }
    }
}
