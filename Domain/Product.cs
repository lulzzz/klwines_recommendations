using System.Collections.Generic;

namespace WebApi.Controllers
{
    public class Product
    {
        public string Id { get; set; }
        public int RecomendationVersion { get; set; }
        public List<string> Recomendations { get; set; }
    }
}