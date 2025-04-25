using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared.Dto.Basket;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BasketController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BasketDto>> Get(string id)
    {
        var basket = await serviceManager.BasketService.GetBasketAsync(id);

        return Ok(basket);
    }

    [HttpPost]
    public async Task<ActionResult<BasketDto>> Update(BasketDto basketDto)
    {
        var updatedBasketDto =
            await serviceManager.BasketService.UpdateBasketAsync(basketDto);

        return Ok(updatedBasketDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        _ = await serviceManager.BasketService.DeleteBasketAsync(id);
        return NoContent();
    }
}
