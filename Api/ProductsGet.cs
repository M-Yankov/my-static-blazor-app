using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Data;
using System.Collections.Generic;

namespace Api
{
    public class ProductsGet
    {
        private readonly IProductData productsData;

        public ProductsGet(IProductData productsData)
        {
            this.productsData = productsData;
        }

        [FunctionName("ProductsGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req,
            ILogger log)
        {
            IEnumerable<Product> products = await this.productsData.GetProducts();
            return new OkObjectResult(products);
        }
    }
}
