using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tepe.Brt.Api.ViewModels;
using Tepe.Brt.Business.Services;
using Tepe.Brt.Data.Entities;
using Newtonsoft.Json;

namespace Tepe.Brt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {

        private readonly IGenericService _genericService;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientController> _logger;
        private readonly IWebHostEnvironment _env;
        private string localDirectoryPath = "files/RecommendationImages/";

        public PatientController(ILogger<PatientController> logger, IMapper mapper, IGenericService genericService, IWebHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _mapper = mapper;
            _genericService = genericService;
        }

        #region Patient

        // Method to get the list of the patients
        [HttpGet(Name = "GetPatients")]
        public async Task<IResult> GetPatientsList()
        {
            var result = await _genericService.GetPatientList();
            IEnumerable<PatientVM> patients = _mapper.Map<IEnumerable<PatientVM>>(result);
            if (patients == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(patients);
        }

        // Method to get the patient detail by patient ID
        [HttpGet]
        [Route("GetPatientDetailById")]
        public async Task<IResult> GetPatientDetailById(Guid id)
        {
            var result = await _genericService.GetPatientDetailById(id);
            PatientVM patient = _mapper.Map<PatientVM>(result);
            if (patient == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(patient);
        }

        // Method to save the patient detail
        [HttpPost(Name = "SavePatientDetail")]
        public async Task<IResult> SavePatientDetail([FromForm]DataVM model)
        {

                PatientVM patientModel = new PatientVM();
                patientModel.Email = model.email;
                patientModel.PhoneNumber = model.phone_number;

                PatientEntity patients = _mapper.Map<PatientEntity>(patientModel);
                var result = await _genericService.SavePatientDetail(patients);

                RecommendationVM recommend = new RecommendationVM();
                recommend.MissingArray = model.missing;
                recommend.BridgeArray = model.bridge;
                recommend.Bridge = String.Join(",", model.bridge.Select(p => p.ToString()).ToArray());
                recommend.Missing = String.Join(",", model.missing.Select(p => p.ToString()).ToArray());
                recommend.Comment = model.comment;
                recommend.PatientID = patients.Id;

                //if (model.teeth_image != null)
                //{
                //    //var directoryPath = Path.Combine(_env.WebRootPath, localDirectoryPath);
                //    //var uniqueFileName = GetUniqueFileName(model.teeth_image.FileName);
                //    //var filePath = Path.Combine(directoryPath, uniqueFileName);
                //    //model.teeth_image.CopyTo(new FileStream(filePath, FileMode.Create));
                //    //model.Image = localDirectoryPath + uniqueFileName;
                //}
                //recommend.Image = model.Image;

                recommend.TeethImage = model.teeth_image;

                RecommendationEntity recommendEntity = _mapper.Map<RecommendationEntity>(recommend);
                var result_recommend = await _genericService.SaveRecommendationDetail(recommendEntity);

                if (result_recommend == null)
                {
                    return Results.NotFound();
                }

                var data = JsonConvert.DeserializeObject<List<RecommendItem>>(model.recommendations);

                foreach (var item in data)
                {
                    RecoItemVM recoItem = new RecoItemVM();
                    recoItem.Area = item.area;
                    recoItem.Title = item.title;
                    recoItem.Description = item.description;
                    recoItem.RecommendationID = recommendEntity.Id;

                    RecoItemEntity recoItems = _mapper.Map<RecoItemEntity>(recoItem);
                    var result_recoItems = await _genericService.SaveRecoItemDetail(recoItems);

                    if (result_recoItems == null)
                    {
                        return Results.NotFound();
                    }
                }

                if (result == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(patients);
        }

        // Method to update the patient detail
        [HttpPut(Name = "UpdatePatientDetail")]
        public async Task<IResult> UpdatePatientDetail(PatientVM model)
        {
            PatientEntity patients = _mapper.Map<PatientEntity>(model);
            var result = await _genericService.UpdatePatientDetail(patients);
            if (result == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(patients);
        }

        // Method to delete the patient detail
        [HttpDelete(Name = "DeletePatient")]
        public async Task<IResult> DeletePatient(Guid id)
        {
            await _genericService.DeletePatient(id);
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
                      + Path.GetExtension(fileName) + ".png";
        }
    }

    public class RecommendItem
    {
        public string title { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public string area { get; set; } = string.Empty;
    }
}
