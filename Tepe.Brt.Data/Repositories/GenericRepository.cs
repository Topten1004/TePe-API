using Microsoft.EntityFrameworkCore;
using Tepe.Brt.Data.Entities;

namespace Tepe.Brt.Data.Repositories
{
    public interface IGenericRepository
    {
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

        #region RecoItem
        Task<IEnumerable<RecoItemEntity>> GetRecoItemList();
        Task<RecoItemEntity> GetRecoItemDetailById(Guid patientId);
        Task<RecoItemEntity> SaveRecoItemDetail(RecoItemEntity model);
        Task<RecoItemEntity> UpdateRecoItemDetail(RecoItemEntity model);
        Task<List<RecoItemEntity>> GetRecoItemByRecommendationId(Guid id);
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

        #region Market
        Task<IEnumerable<MarketEntity>> GetMarketList();
        Task<MarketEntity> GetMarketDetailById(Guid patientId);
        Task<MarketEntity> SaveMarketDetail(MarketEntity model);
        Task<MarketEntity> UpdateMarketDetail(MarketEntity model);
        Task DeleteMarket(Guid id);
        #endregion
    }

    public class GenericRepository : IGenericRepository
    {
        private readonly ApplicationDbContext _model;
        public GenericRepository(ApplicationDbContext model)
        {
            _model = model;
        }

        #region Market
        public async Task<IEnumerable<MarketEntity>> GetMarketList()
        {
            var model = await _model.Markets.ToListAsync();
            return model;
        }
        public async Task<MarketEntity> GetMarketDetailById(Guid id)
        {
            return await _model.Markets.FindAsync(id);
        }
        public async Task<MarketEntity> SaveMarketDetail(MarketEntity model)
        {
            await _model.Markets.AddAsync(model);
            await _model.SaveChangesAsync();
            return model;
        }
        public async Task<MarketEntity> UpdateMarketDetail(MarketEntity model)
        {
            _model.Update(model);
            await _model.SaveChangesAsync();
            return model;
        }
        public async Task DeleteMarket(Guid id)
        {
            MarketEntity market = await _model.Markets.FindAsync(id);
            if (market != null)
            {
                _model.Remove(market);
                await _model.SaveChangesAsync();
            }
        }
        #endregion

        #region Patient
        public async Task<IEnumerable<PatientEntity>> GetPatientList()
        {
            var model = await _model.Patients.Include(x => x.Recommendations).ToListAsync();
            return model;
        }
        public async Task<PatientEntity> GetPatientDetailById(Guid patientId)
        {
            return await _model.Patients.FindAsync(patientId);
        }
        public async Task<PatientEntity> SavePatientDetail(PatientEntity model)
        {
            await _model.Patients.AddAsync(model);
            await _model.SaveChangesAsync();
            return model;
        }
        public async Task<PatientEntity> UpdatePatientDetail(PatientEntity model)
        {
            //_model.Entry(model).State = EntityState.Modified;
            _model.Update(model);
            await _model.SaveChangesAsync();
            return model;
        }
        public async Task DeletePatient(Guid patientId)
        {
            PatientEntity patient = await _model.Patients.FindAsync(patientId);
            if (patient != null)
            {
                _model.Remove(patient);
                await _model.SaveChangesAsync();
            }
        }
        #endregion

        #region Recommendation
        public async Task<IEnumerable<RecommendationEntity>> GetRecommendationList()
        {
            var model = await _model.Recommendations.ToListAsync();
            return model;
        }
        public async Task<RecommendationEntity> GetRecommendationDetailById(Guid recommendationId)
        {
            return await _model.Recommendations.Include(x => x.RecoItems).FirstOrDefaultAsync(x => x.Id == recommendationId);
        }
        public async Task<RecommendationEntity> SaveRecommendationDetail(RecommendationEntity model)
        {
            await _model.Recommendations.AddAsync(model);
            await _model.SaveChangesAsync();
            return model;
        }
        public async Task<RecommendationEntity> UpdateRecommendationDetail(RecommendationEntity model)
        {
            //_model.Entry(model).State = EntityState.Modified;
            _model.Update(model);
            await _model.SaveChangesAsync();
            return model;
        }
        public async Task DeleteRecommendation(Guid patientId)
        {
            RecommendationEntity patient = await _model.Recommendations.FindAsync(patientId);
            if (patient != null)
            {
                _model.Remove(patient);
                await _model.SaveChangesAsync();
            }
        }
        #endregion

        #region RecoItem
        public async Task<IEnumerable<RecoItemEntity>> GetRecoItemList()
        {
            var model = await _model.RecoItems.ToListAsync();
            return model;
        }
        public async Task<RecoItemEntity> GetRecoItemDetailById(Guid patientId)
        {
            return await _model.RecoItems.FindAsync(patientId);
        }
        public async Task<RecoItemEntity> SaveRecoItemDetail(RecoItemEntity model)
        {
            await _model.RecoItems.AddAsync(model);
            await _model.SaveChangesAsync();
            return model;
        }
        public async Task<RecoItemEntity> UpdateRecoItemDetail(RecoItemEntity model)
        {
            _model.Update(model);
            await _model.SaveChangesAsync();
            return model;
        }
        
        public async Task<List<RecoItemEntity>> GetRecoItemByRecommendationId(Guid id)
        {
            List<RecoItemEntity> items = new List<RecoItemEntity>();
            items = (List<RecoItemEntity>)_model.RecoItems.Where(p => p.RecommendationID == id);

            return items;
        }

        public async Task DeleteRecoItem(Guid patientId)
        {
            RecoItemEntity patient = await _model.RecoItems.FindAsync(patientId);
            if (patient != null)
            {
                _model.Remove(patient);
                await _model.SaveChangesAsync();
            }
        }
        #endregion

        #region Category
        public async Task<IEnumerable<CategoryEntity>> GetCategoryList()
        {
            var model = await _model.Categories.ToListAsync();
            return model;
        }

        public async Task<CategoryEntity> GetCategoryDetailById(Guid patientId)
        {
            return await _model.Categories.FindAsync(patientId);
        }
        public async Task<CategoryEntity> SaveCategoryDetail(CategoryEntity model)
        {
            await _model.Categories.AddAsync(model);
            await _model.SaveChangesAsync();
            return model;
        }
        public async Task<CategoryEntity> UpdateCategoryDetail(CategoryEntity model)
        {
            _model.Update(model);
            await _model.SaveChangesAsync();
            return model;
        }
        public async Task DeleteCategory(Guid id)
        {
            CategoryEntity category = await _model.Categories.FindAsync(id);
            if (category != null)
            {
                _model.Remove(category);
                await _model.SaveChangesAsync();
            }
        }
        #endregion

        #region Product
        public async Task<IEnumerable<ProductEntity>> GetProductList()
        {
            var model = await _model.Products.ToListAsync();
            return model;
        }
        public async Task<ProductEntity> GetProductDetailById(Guid id)
        {
            return await _model.Products.FindAsync(id);
        }
        public async Task<ProductEntity> SaveProductDetail(ProductEntity model)
        {
            await _model.Products.AddAsync(model);
            await _model.SaveChangesAsync();
            return model;
        }
        public async Task<ProductEntity> UpdateProductDetail(ProductEntity model)
        {
            _model.Update(model);
            await _model.SaveChangesAsync();
            return model;

        }
        public async Task DeleteProduct(Guid id)
        {
            ProductEntity product = await _model.Products.FindAsync(id);
            if (product != null)
            {
                _model.Remove(product);
                await _model.SaveChangesAsync();
            }
        }
        #endregion
    }
}
