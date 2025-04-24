using System.Net;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared.Dto.Product;

namespace Presentation.Controllers;

public class ProductController(IServiceManager serviceManager) : ApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProducts(
        [FromQuery] ProductSpecificationParams specsParams)
    {
        var products = await serviceManager.ProductService
            .GetAllProductsAsync(specsParams);

        return Ok(products);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ProductResultDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductResultDto>> GetProduct(int id)
    {
        var product = await serviceManager.ProductService
            .GetProductByIdAsync(id);

        return Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrands()
    {
        var brands = await serviceManager.ProductService
            .GetAllBrandsAsync();

        return Ok(brands);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypes()
    {
        var types = await serviceManager.ProductService
            .GetAllTypesAsync();

        return Ok(types);
    }
}
