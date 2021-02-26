namespace Checkout.Api.Treasury
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Domain.ShoppingBasket.Aggregates.BasketAggregate;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingBasket;

    [Route("api/v{version:apiVersion}/checkout/basket")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Consumes("application/json")]
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Envelope))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Envelope))]
        public async Task<IActionResult> Register(
            [FromBody] AddBasketItemDto args)
        {
            var basket = new Basket(
                ipAddress: GetIpAddress(),
                sku: args.Sku);

            await _repository
                .AddAsync(basket);

            return Ok();
        }

        private string GetIpAddress(HttpRequestMessage request = null)
        {
            return "192.168.1.7";

            //return _accessor
            //    .HttpContext
            //    .Connection
            //    .RemoteIpAddress
            //    .ToString();
        }
    }
}