using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using SearchProject.Application.Interfaces.Search;
using SearchProject.Application.Models.Search;

namespace SearchProduct.Infrastructure.Search
{
    public class SearchService : IElasticSearchService
    {
        private readonly IElasticClient _elasticClient;
        private const string IndexName = "Products";

        public SearchService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task IndexAllProducts(List<ProductSearchDto> products)
        {
            if (!products.Any())
                throw new ArgumentException("no data sent");

            var response = _elasticClient.BulkAsync(b => b.Index(IndexName).IndexMany(products));

            if (response.Result.Errors)
                throw new Exception("Elastic search error");
        }


    }
}
