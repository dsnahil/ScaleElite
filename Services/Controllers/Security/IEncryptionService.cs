namespace Services
{
    public interface IEncryptionService
    {
        string EncryptData(string Str);
        string DecryptData(string Str);      
        bool IsSaltMatch(string username, string password, string Salt);
        string createSalt(string username, string password);
    }
}
