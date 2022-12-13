using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tepe.Brt.Api.ViewModels;
using Tepe.Brt.Business.Services;
using Tepe.Brt.Data.Entities;

namespace Tepe.Brt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Recommendation : ControllerBase
    {

        private readonly IGenericService _genericService;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientController> _logger;
        private readonly IWebHostEnvironment _env;
        private string localDirectoryPath = "files/RecommendationImages/";

        public Recommendation(ILogger<PatientController> logger, IMapper mapper, IGenericService genericService, IWebHostEnvironment env)
        {
            _logger = logger;
            _mapper = mapper;
            _genericService = genericService;
            _env = env;
        }

        #region Recommendation

        // Method to get the list of the recommendations
        [HttpGet(Name = "GetRecommendations")]
        public async Task<IResult> GetRecommendationsList()
        {
            var result = await _genericService.GetRecommendationList();
            IEnumerable<RecommendationVM> patients = _mapper.Map<IEnumerable<RecommendationVM>>(result);
            if (patients == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(patients);
        }

        // Method to get the recommendation detail by Recommendation ID
        [HttpGet]
        [Route("GetRecommendationDetailById")]
        public async Task<IResult> GetRecommendationDetailById(Guid id)
        {
            var result = await _genericService.GetRecommendationDetailById(id);
            RecommendationVM patient = _mapper.Map<RecommendationVM>(result);
            if (patient == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(patient);
        }

        // Method to save the recommendation detail
        [HttpPost(Name = "SaveRecommendationDetail")]
        public async Task<IResult> SaveRecommendationDetail(RecommendationVM model)
        {
            //if (model.ImageFile != null)
            //{
            //    var directoryPath = Path.Combine(_env.WebRootPath, localDirectoryPath);
            //    var uniqueFileName = GetUniqueFileName(model.ImageFile.FileName);
            //    var filePath = Path.Combine(directoryPath, uniqueFileName);
            //    model.ImageFile.CopyTo(new FileStream(filePath, FileMode.Create));
            //    model.Image = localDirectoryPath + uniqueFileName;
            //}
            //RecommendationEntity patients = _mapper.Map<RecommendationEntity>(model);
            //var result = await _genericService.SaveRecommendationDetail(patients);
            //if (result == null)
            //{
            //    return Results.NotFound();
            //}
            //return Results.Ok(patients);
            return Results.Ok();
        }

        // Method to update the recommendation detail
        [HttpPut(Name = "UpdateRecommendationDetail")]
        public async Task<IResult> UpdateRecommendationDetail(RecommendationVM model)
        {
            //if (model.ImageFile != null)
            //{
            //    var directoryPath = Path.Combine(_env.WebRootPath, localDirectoryPath);
            //    var uniqueFileName = GetUniqueFileName(model.ImageFile.FileName);
            //    var filePath = Path.Combine(directoryPath, uniqueFileName);
            //    model.ImageFile.CopyTo(new FileStream(filePath, FileMode.Create));
            //    model.Image = localDirectoryPath + uniqueFileName;
            //}
            //RecommendationEntity patients = _mapper.Map<RecommendationEntity>(model);
            //var result = await _genericService.UpdateRecommendationDetail(patients);
            //if (result == null)
            //{
            //    return Results.NotFound();
            //}
            //return Results.Ok(patients);
            return Results.Ok();
        }

        // Method to delete the recommendation detail
        [HttpDelete(Name = "DeleteRecommendation")]
        public async Task<IResult> DeleteRecommendation(Guid id)
        {
            await _genericService.DeleteRecommendation(id);
            return Results.Ok();
        }
        #endregion

        // Method to generate a unique path of the image file
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
