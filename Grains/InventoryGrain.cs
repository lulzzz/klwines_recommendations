using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Core.Exceptions;
using GrainInterfaces;
using Orleans;

namespace Grains
{

    // this.State should store a list of all the products on the KLWines website

    public class InventoryGrain : Grain<ProductInventory>, IInventoryGrain
    {

        public async Task UpdateAllProductRecommendations()
        {
            // Creates a new list of each SKU for every product in Inventory
            var inventory = new List<string>();

            // Loops through this.State.Inventory and adds each product SKU to the above list
            this.State.Inventory.ForEach(product => inventory.Add(product.Record.Sku));

            // Loops through the inventory list and calls the UpdateRecommendations method assosiated with each product SKU
            inventory.ForEach(product => this.GrainFactory.GetGrain<IRecommendationGrain>(product).UpdateRecommendations());
        }
    }
}
