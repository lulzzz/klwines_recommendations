using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.DTO;
using Orleans;

namespace GrainInterfaces
{
    public interface IRecommendationGrain : IGrainWithStringKey
    {
        Task UpdateRecommendations();

        Task<List<ProductDTO>> GetRecommendations();
    }
}
