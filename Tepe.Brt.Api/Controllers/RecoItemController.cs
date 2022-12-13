using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tepe.Brt.Api.ViewModels;
using Tepe.Brt.Business.Services;
using Tepe.Brt.Data.Entities;

namespace Tepe.Brt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecoItemController : ControllerBase
    {

        private readonly IGenericService _genericService;
        private readonly IMapper _mapper;
        private readonly ILogger<RecoItemController> _logger;

        public RecoItemController(ILogger<RecoItemController> logger, IMapper mapper, IGenericService genericService)
        {
            _logger = logger;
            _mapper = mapper;
            _genericService = genericService;
        }

        #region Product

        // Method to get the list of the products
        [HttpGet(Name = "GetRecoItem")]
        public async Task<IResult> GetRecoItemList()
        {
            var result = await _genericService.GetRecoItemList();
            IEnumerable<RecoItemVM> patients = _mapper.Map<IEnumerable<RecoItemVM>>(result);
            if (patients == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(patients);
        }

        // Method to get the product detail by product ID
        [HttpGet]
        [Route("GetRecoItemDetailById")]
        public async Task<IResult> GetRecoItemDetailById(Guid id)
        {
            var result = await _genericService.GetRecoItemDetailById(id);
            RecoItemVM patient = _mapper.Map<RecoItemVM>(result);
            if (patient == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(patient);
        }

        // Method to save the product detail
        [HttpPost(Name = "SaveRecoItemDetail")]
        public async Task<IResult> SaveRecoItemDetail(RecoItemVM model)
        {
            RecoItemEntity patients = _mapper.Map<RecoItemEntity>(model);
            var result = await _genericService.SaveRecoItemDetail(patients);
            if (result == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(patients);
        }

        // Method to update the product detail
        [HttpPut(Name = "UpdateRecoItemDetail")]
        public async Task<IResult> UpdateRecoItemDetail(RecoItemVM model)
        {
            RecoItemEntity patients = _mapper.Map<RecoItemEntity>(model);
            var result = await _genericService.UpdateRecoItemDetail(patients);
            if (result == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(patients);
        }

        // Method to delete the product detail
        [HttpDelete(Name = "DeleteRecoItem")]
        public async Task<IResult> DeleteRecoItem(Guid id)
        {
            await _genericService.DeleteRecoItem(id);
            return Results.Ok();
        }
        #endregion
    }
}
