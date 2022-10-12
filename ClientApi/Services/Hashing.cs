using BC = BCrypt.Net.BCrypt;

namespace ClientApi.Services;

public class Hashing : IHashing
{

    public string HashPassword(string password)
        => BC.HashPassword(password, GetRandomSalt());

    public bool ValidatePassword(string password, string correctHash) 
        => BC.Verify(password, correctHash);

    private string GetRandomSalt() 
        => BC.GenerateSalt(10);
}