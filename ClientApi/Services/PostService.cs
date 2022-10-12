using ClientApi.Services.DataModels;
using ClientApi.SettingsModels;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ClientApi.Services;

public class PostService : IPostService
{
    private readonly IMongoCollection<Post> _posts;

    public PostService(IOptions<DatabaseSettings> settings)
    {
        MongoClient client = new MongoClient(settings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(settings.Value.DatabaseName);
        _posts = database.GetCollection<Post>(settings.Value.PostCollection);
    }

    public async Task CreatePost(Post post)
    {
        var createnewpost = new Post()
        {
            Id = post.Id,
            Title = post.Title,
            Description = post.Description,
            Photo = post.Photo,
            Username = post.Username,
            Categories = post.Categories,
            UpdatedAt = DateTime.Now,
            CreatedAt = DateTime.Now,
            Version = post.Version,
        };

        await _posts.InsertOneAsync(createnewpost);
    }

    public void Delete(string id)
    {
        var findpost = _posts.Find(x => x.Id == id).FirstOrDefault();
        _posts.DeleteOneAsync(x => x.Id == findpost.Id);
    }

    public Post GetPostById(string id)
        => _posts.Find(x => x.Id == id).FirstOrDefault();

    public async Task<List<Post>> GetPosts()
    {
        var users = await _posts.Find<Post>(new BsonDocument()).ToListAsync();

        return users;
    }

    public async Task Update(Post post)
        => await _posts.ReplaceOneAsync(x => x.Id == post.Id, post);
}
