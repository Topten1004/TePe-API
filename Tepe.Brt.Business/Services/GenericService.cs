using Tepe.Brt.Data;
using Tepe.Brt.Data.Entities;
using Tepe.Brt.Data.Repositories;

namespace Tepe.Brt.Business.Services
{
    public interface IGenericService
    {
        #region Market
        Task<IEnumerable<MarketEntity>> GetMarketList();
        Task<MarketEntity> GetMarketDetailById(Guid patientId);
        Task<MarketEntity> SaveMarketDetail(MarketEntity model);
        Task<MarketEntity> UpdateMarketDetail(MarketEntity model);
        Task DeleteMarket(Guid id);
        #endregion

        #region Patient
        Task<IEnumerable<PatientEntity>> GetPatientList();
        Task<PatientEntity> GetPatientDetailById(Guid patientId);
        Task<PatientEntity> SavePatientDetail(PatientEntity model);
        Task<PatientEntity> UpdatePatientDetail(PatientEntity model);
        Task DeletePatient(Guid id);
        #endregion

        #region Recommendation
        Task<IEnumerable<RecommendationEntity>> GetRecommendationList();
        Task<RecommendationEntity> GetRecommendationDetailById(Guid patientId);
        Task<RecommendationEntity> SaveRecommendationDetail(RecommendationEntity model);
        Task<RecommendationEntity> UpdateRecommendationDetail(RecommendationEntity model);
        Task DeleteRecommendation(Guid id);
        #endregion

        #region RecoItems
        Task<IEnumerable<RecoItemEntity>> GetRecoItemList();
        Task<RecoItemEntity> GetRecoItemDetailById(Guid patientId);
        Task<RecoItemEntity> SaveRecoItemDetail(RecoItemEntity model);
        Task<RecoItemEntity> UpdateRecoItemDetail(RecoItemEntity model);
        Task<List<RecoItemEntity>> GetRecoItemByRecommendationId(Guid recommendationId);
        Task DeleteRecoItem(Guid id);
        #endregion

        #region Category
        Task<IEnumerable<CategoryEntity>> GetCategoryList();
        Task<CategoryEntity> GetCategoryDetailById(Guid patientId);
        Task<CategoryEntity> SaveCategoryDetail(CategoryEntity model);
        Task<CategoryEntity> UpdateCategoryDetail(CategoryEntity model);
        Task DeleteCategory(Guid id);
        #endregion

        #region Product
        Task<IEnumerable<ProductEntity>> GetProductList();
        Task<ProductEntity> GetProductDetailById(Guid patientId);
        Task<ProductEntity> SaveProductDetail(ProductEntity model);
        Task<ProductEntity> UpdateProductDetail(ProductEntity model);
        Task DeleteProduct(Guid id);
        #endregion
    }
    public class GenericService : IGenericService
    {
        private readonly IGenericRepository _userRepository;
        public GenericService(IGenericRepository userRepository)
        {
            _userRepository = userRepository;
        }


        #region Market
        public async Task<IEnumerable<MarketEntity>> GetMarketList()
        {
            return await _userRepository.GetMarketList();
        }

        public async Task<MarketEntity> GetMarketDetailById(Guid marketId)
        {
            return await _userRepository.GetMarketDetailById(marketId);
        }

        public async Task<MarketEntity> SaveMarketDetail(MarketEntity model)
        {
            return await _userRepository.SaveMarketDetail(model);
        }
        public async Task<MarketEntity> UpdateMarketDetail(MarketEntity model)
        {
            return await _userRepository.UpdateMarketDetail(model);
        }
        public async Task DeleteMarket(Guid id)
        {
            await _userRepository.DeleteMarket(id);
        }
        #endregion

        #region Patient
        public async Task<PatientEntity> GetPatientDetailById(Guid patientId)
        {
            return await _userRepository.GetPatientDetailById(patientId);
        }
        public async Task<IEnumerable<PatientEntity>> GetPatientList()
        {
            return await _userRepository.GetPatientList();
        }
        public async Task<PatientEntity> SavePatientDetail(PatientEntity model)
        {
            return await _userRepository.SavePatientDetail(model);
        }
        public async Task<PatientEntity> UpdatePatientDetail(PatientEntity model)
        {
            return await _userRepository.UpdatePatientDetail(model);
        }
        public async Task DeletePatient(Guid id)
        {
            await _userRepository.DeletePatient(id);
        }
        #endregion

        #region Recommendation
        public async Task<RecommendationEntity> GetRecommendationDetailById(Guid patientId)
        {
            return await _userRepository.GetRecommendationDetailById(patientId);
        }
        public async Task<IEnumerable<RecommendationEntity>> GetRecommendationList()
        {
            return await _userRepository.GetRecommendationList();
        }
        public async Task<RecommendationEntity> SaveRecommendationDetail(RecommendationEntity model)
        {
            return await _userRepository.SaveRecommendationDetail(model);
        }
        public async Task<RecommendationEntity> UpdateRecommendationDetail(RecommendationEntity model)
        {
            return await _userRepository.UpdateRecommendationDetail(model);
        }
        public async Task DeleteRecommendation(Guid id)
        {
            await _userRepository.DeleteRecommendation(id);
        }
        #endregion

        #region RecoItem
        public async Task<RecoItemEntity> GetRecoItemDetailById(Guid patientId)
        {
            return await _userRepository.GetRecoItemDetailById(patientId);
        }
        public async Task<IEnumerable<RecoItemEntity>> GetRecoItemList()
        {
            return await _userRepository.GetRecoItemList();
        }
        public async Task<RecoItemEntity> SaveRecoItemDetail(RecoItemEntity model)
        {
            return await _userRepository.SaveRecoItemDetail(model);
        }
        public async Task<RecoItemEntity> UpdateRecoItemDetail(RecoItemEntity model)
        {
            return await _userRepository.UpdateRecoItemDetail(model);
        }

        public async Task<List<RecoItemEntity>> GetRecoItemByRecommendationId(Guid recommendationId)
        {
            return await _userRepository.GetRecoItemByRecommendationId(recommendationId);
        }

        public async Task DeleteRecoItem(Guid id)
        {
            await _userRepository.DeleteRecoItem(id);
        }
        #endregion

        #region Category
        public async Task<IEnumerable<CategoryEntity>> GetCategoryList()
        {
            return await _userRepository.GetCategoryList();
        }

        public async Task<CategoryEntity> GetCategoryDetailById(Guid categoryId)
        {
            return await _userRepository.GetCategoryDetailById(categoryId);
        }

        public async Task<CategoryEntity> SaveCategoryDetail(CategoryEntity model)
        {
            return await _userRepository.SaveCategoryDetail(model);
        }
        public async Task<CategoryEntity> UpdateCategoryDetail(CategoryEntity model)
        {
            return await _userRepository.UpdateCategoryDetail(model);
        }
        public async Task DeleteCategory(Guid id)
        {
            await _userRepository.DeleteCategory(id);
        }
        #endregion

        #region Product
        public async Task<IEnumerable<ProductEntity>> GetProductList()
        {
            return await _userRepository.GetProductList();
        }
        public async Task<ProductEntity> GetProductDetailById(Guid productId)
        {
            return await _userRepository.GetProductDetailById(productId);
        }
        public async Task<ProductEntity> SaveProductDetail(ProductEntity model)
        {
            return await _userRepository.SaveProductDetail(model);
        }
        public async Task<ProductEntity> UpdateProductDetail(ProductEntity model)
        {
            return await _userRepository.UpdateProductDetail(model);
        }
        public async Task DeleteProduct(Guid id)
        {
            await _userRepository.DeleteProduct(id);
        }
        #endregion

    }
}
