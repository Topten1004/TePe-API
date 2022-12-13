using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tepe.Brt.Api.ViewModels;
using Tepe.Brt.Business.Services;
using Tepe.Brt.Data;

namespace Tepe.Brt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarketController
    {
        private readonly IGenericService _genericService;
        private readonly IMapper _mapper;
        private readonly ILogger<MarketController> _logger;

        public MarketController(ILogger<MarketController> logger, IMapper mapper, IGenericService genericService)
        {
            _logger = logger;
            _mapper = mapper;
            _genericService = genericService;
        }

        #region Market

        // Method to get the list of the markets
        [HttpGet(Name = "GetMarkets")]
        public async Task<IResult> GetMarketsList()
        {
            var result = await _genericService.GetMarketList();
            IEnumerable<MarketVM> markets = _mapper.Map<IEnumerable<MarketVM>>(result);
            if (markets == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(markets);
        }

        // Method to get the market detail by market ID
        [HttpGet]
        [Route("GetMarketDetailById")]
        public async Task<IResult> GetMarketDetailById(Guid id)
        {
            var result = await _genericService.GetMarketDetailById(id);
            MarketVM market = _mapper.Map<MarketVM>(result);
            if (market == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(market);
        }

        // Method to save the market detail
        [HttpPost(Name = "SaveMarketDetail")]
        public async Task<IResult> SaveMarketDetail([FromForm]MarketVM model)
        {
            MarketEntity markets = _mapper.Map<MarketEntity>(model);
            var result = await _genericService.SaveMarketDetail(markets);
            if (result == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(markets);
        }

        // Method to update the market detail
        [HttpPut(Name = "UpdateMarketDetail")]
        public async Task<IResult> UpdateMarketDetail(CategoryVM model)
        {
            MarketEntity markets = _mapper.Map<MarketEntity>(model);
            var result = await _genericService.UpdateMarketDetail(markets);
            if (result == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(markets);
        }

        // Method to delete the market detail
        [HttpDelete(Name = "DeleteMarket")]
        public async Task<IResult> DeleteMarket(Guid id)
        {
            await _genericService.DeleteMarket(id);
            return Results.Ok();
        }
        #endregion
    }
}
