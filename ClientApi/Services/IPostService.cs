using Post = ClientApi.Services.DataModels.Post;

namespace ClientApi.Services
{
    public interface IPostService
    {
        Task CreatePost(Post post);
        void Delete(string id);
        Post GetPostById(string id);
        Task<List<Post>> GetPosts();
        Task Update(Post post);
    }
}