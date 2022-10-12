using ClientApi.Services.DataModels;

namespace ClientApi.Services
{
    public interface ICategoryService
    {
        Task CreateCategory(Categories category);
        Task<List<Categories>> GetAll();
    }
}