using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Orleans;

namespace GrainInterfaces
{
    public interface IRecommendationGrain : IGrainWithStringKey
    {
        Task<List<SKU>> GetRecommendedSKUs(string productId);
    }
}
