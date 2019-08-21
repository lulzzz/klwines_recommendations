using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using WebApi.Controllers;

namespace GrainInterfaces
{
    public interface IProductGrain : IGrainWithStringKey
    {
        Task<Product> Get();

        Task<List<string>> GetRecomendations();

        Task UpdateToLatestVersion(int version);
    }
}
