namespace ClientApi.Services
{
    public interface IHashing
    {
        string HashPassword(string password);
        bool ValidatePassword(string password, string correctHash);
    }
}