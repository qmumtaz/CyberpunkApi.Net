using ClientApi.Services.DataModels;
using ClientApi.SettingsModels;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ClientApi.Services;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Categories> _categories;

    public CategoryService(IOptions<DatabaseSettings> settings)
    {
        MongoClient client = new MongoClient(settings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(settings.Value.DatabaseName);
        _categories = database.GetCollection<Categories>(settings.Value.CategoryCollection);
    }

    public async Task CreateCategory(Categories category)
    {
        var createcategory = new Categories()
        {
            Id = category.Id,
            Name = category.Name,
            UpdatedAt = DateTime.Now,
            CreatedAt = DateTime.Now,
        };

        await _categories.InsertOneAsync(createcategory);
    }

    public async Task<List<Categories>> GetAll()
    {
        var findall = await _categories.Find<Categories>(new BsonDocument()).ToListAsync();

        return findall;
    }
}
