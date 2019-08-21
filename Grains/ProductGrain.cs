using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using GrainInterfaces;
using Orleans;

namespace Grains
{
    public class ProductGrain : Grain<Product>, IProductGrain
    {
        public ProductGrain()
        {
        }

        public async Task<List<string>> GetRecomendations()
        {
            return this.State.Recomendations;
        }

        public async Task UpdateToLatestVersion(int version)
        {
            this.State.LatestVersion = version;
        }
    }
}
