using SearchProject.Application.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProject.Application.Interfaces.Search
{
    public interface IElasticSearchService
    {
        Task IndexAllProducts(List<ProductSearchDto> products);
        
    }
}
