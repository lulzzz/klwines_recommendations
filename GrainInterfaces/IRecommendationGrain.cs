using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Domain;

namespace GrainInterfaces
{
    public interface IRecommendationGrain : IGrainWithIntegerKey
    {
        Task<List<string>> GetRecommendations(string productId);
        Task RequiresUpdate();
        Task UpdateRecommendations();
    }
}