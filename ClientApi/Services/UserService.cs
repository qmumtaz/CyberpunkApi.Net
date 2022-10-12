using ClientApi.Services.DataModels;
using ClientApi.SettingsModels;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ClientApi.Services;

public class UserService : IUserService
{
    private readonly IMongoCollection<User> _users;

    public UserService(IOptions<DatabaseSettings> settings)
    {
        MongoClient client = new MongoClient(settings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(settings.Value.DatabaseName);
        _users = database.GetCollection<User>(settings.Value.CollectionName);
    }

    public async Task CreateUser(User users)
    {
        var createnewuser = new User()
        {
            Id = users.Id,
            Username = users.Username,
            Email = users.Email,
            Password = users.Password,
            Profilepic = users.Profilepic,
            UpdatedAt = DateTime.Now,
            CreatedAt = DateTime.Now,
        };

        await _users.InsertOneAsync(createnewuser);
    }

    public async Task Delete(string id)
    {
        var finduser = _users.Find(x => x.Id == id).FirstOrDefault();

        await _users.DeleteOneAsync(x => x.Id == finduser.Id);
    }

    public User GetUserById(string id)
        => _users.Find(x => x.Id == id).FirstOrDefault();

    public async Task<List<User>> GetUsers()
    {
        var users = await _users.Find<User>(new BsonDocument()).ToListAsync();

        return users;
    }

    public async Task Update(User user)
        => await _users.ReplaceOneAsync(x => x.Id == user.Id, user);

    public async Task<User?> GetUserByUsername(string username)
    {
        var user = await _users.Find<User>(x => x.Username == username).FirstOrDefaultAsync();

        return user;
    }
}
