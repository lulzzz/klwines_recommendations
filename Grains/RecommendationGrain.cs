using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.DTO;
using GrainInterfaces;
using Orleans;

namespace Grains
{

    // this.State should store a list of all recommended products for the given product

    public class RecommendationGrain : Grain<Recommendation>, IRecommendationGrain
    {
        // a list of products with only the necessary properties to display them in the recommendations que
        public List<ProductDTO> Recommendations;


        public async Task UpdateRecommendations()
        {
            var recommendations = new List<ProductDTO>();

            this.State.RecommendedProducts.ForEach(product => recommendations.Add(
                new ProductDTO()
                {
                    SKU = product.Record.Sku,
                    Vintage = product.Record.Vintage,
                    ItemName = product.Record.ItemName,
                    ListPrice = product.Record.ListPrice,
                    ImageSmallURL = product.Record.ImageSmallURL,
                    SpecificAppellation = product.Record.SpecificAppellation,
                    Varietal = product.Record.Varietal,
                    OutOfStockYN = product.Record.OutOfStockYN
                })
            );

            Recommendations = recommendations;

            await CheckAvailability();

            if (Recommendations.Count < 5)
            {
                await AddMoreRecommendations();
            }
        }


        public async Task CheckAvailability()
        {
            Recommendations.ForEach(recommendation =>
            {
                if (recommendation.OutOfStockYN == 1)
                {
                    Recommendations.Remove(recommendation);
                }
            });
        }

        public async Task AddMoreRecommendations()
        {
            // Adds recommendations using a different algorythm..?
        }


        public async Task<List<ProductDTO>> GetRecommendations()
        {
            return Recommendations;
        }
    }
}
