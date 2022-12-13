using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tepe.Brt.Api.ViewModels;
using Tepe.Brt.Business.Services;
using Tepe.Brt.Data;

namespace Tepe.Brt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericService _genericService;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;
        private readonly IWebHostEnvironment _env; 
        private string localDirectoryPath = "files/CategoryImages/";

        public CategoryController(ILogger<CategoryController> logger, IMapper mapper, IGenericService genericService, IWebHostEnvironment env)
        {
            _logger = logger;
            _mapper = mapper;
            _genericService = genericService;
            _env = env;
        }

        #region Category

        // Method to get the list of the categories
        [HttpGet(Name = "GetCategories")]
        public async Task<IResult> GetCategoriesList()
        {
            var result = await _genericService.GetCategoryList();
            IEnumerable<CategoryVM> categories = _mapper.Map<IEnumerable<CategoryVM>>(result);
            if (categories == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(categories);
        }

        // Method to get the category detail by category ID
        [HttpGet]
        [Route("GetCategoryDetailById")]
        public async Task<IResult> GetCategoryDetailById(Guid id)
        {
            var result = await _genericService.GetCategoryDetailById(id);
            CategoryVM category = _mapper.Map<CategoryVM>(result);
            if (category == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(category);
        }

        // Method to save the category detail
        [HttpPost(Name = "SaveCategoryDetail")]
        public async Task<IResult> SaveCategoryDetail([FromForm]CategoryVM model)
        {
            if (model.ImageFile != null)
            {
                var directoryPath = Path.Combine(_env.WebRootPath, localDirectoryPath);
                var uniqueFileName = GetUniqueFileName(model.ImageFile.FileName);
                var filePath = Path.Combine(directoryPath, uniqueFileName);
                model.ImageFile.CopyTo(new FileStream(filePath, FileMode.Create));
                model.catImage = localDirectoryPath + uniqueFileName;
            }

            CategoryEntity categories = _mapper.Map<CategoryEntity>(model);
            var result = await _genericService.SaveCategoryDetail(categories);
            if (result == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(categories);
        }

        // Method to update the category detail
        [HttpPut(Name = "UpdateCategoryDetail")]
        public async Task<IResult> UpdateCategoryDetail(CategoryVM model)
        {
            if (model.ImageFile != null)
            {
                var directoryPath = Path.Combine(_env.WebRootPath, localDirectoryPath);
                var uniqueFileName = GetUniqueFileName(model.ImageFile.FileName);
                var filePath = Path.Combine(directoryPath, uniqueFileName);
                model.ImageFile.CopyTo(new FileStream(filePath, FileMode.Create));
                model.catImage = localDirectoryPath + uniqueFileName;
            }

            CategoryEntity categories = _mapper.Map<CategoryEntity>(model);
            var result = await _genericService.UpdateCategoryDetail(categories);
            if (result == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(categories);
        }

        // Method to delete the category detail
        [HttpDelete(Name = "DeleteCategory")]
        public async Task<IResult> DeleteCategory(Guid id)
        {
            await _genericService.DeleteCategory(id);
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
