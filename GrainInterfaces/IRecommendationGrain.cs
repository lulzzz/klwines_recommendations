using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Domain;

namespace GrainInterfaces
{
    public interface IRecommendationGrain : IGrainWithIntegerKey
    {
        Task<string[]> GetRecommendations(int productId);
        Task RequiresUpdate();
        Task UpdateRecommendations();
    }
}