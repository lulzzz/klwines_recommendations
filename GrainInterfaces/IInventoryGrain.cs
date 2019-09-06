using System;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;

namespace GrainInterfaces
{
    public interface IInventoryGrain : IGrainWithIntegerKey
    {
        Task UpdateAllProductRecommendations();
    }
}