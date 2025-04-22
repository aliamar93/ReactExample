using AutostoreProject.DBEntities;
using AutostoreProject.Model;
namespace AutostoreProject.Service;

public interface Ilogin
{
    AUser FindByEmail(string email);
    AUser Login(string email, string password);
}

public interface ISignUp
{
    AUser UserForSignUp(UserLogin userLogin);
}

public interface ICommonFunction
{
    string Encryption(string value);
    string Decryption(string value);
    string GenerateJwtToken(string userNameOrEmail);
    string GenerateJwtTokenForAdmin(string userNameOrEmail);
    string GenerateJwtTokenForUser(string userNameOrEmail);
    Task SendSecurityEmailAsync(string email, string userName, string action, string actionUrl);
}
public interface IParameters
{
    string GetConnectionString(string name);
    string GetAppSetting(string key);
    string GetAppSetting(string key, string defaultValue);
    string GetAppSetting(string key, int defaultValue);
    string GetAppSetting(string key, bool defaultValue);
    string GetAppSetting(string key, double defaultValue);
    string GetAppSetting(string key, long defaultValue);
    string GetAppSetting(string key, DateTime defaultValue);
}

public interface IUserService
{

    Task AddUser(AUser user);
    Task<IEnumerable<AUser>> GetAllUsers();
    AUser GetUserById(int id);
    AUser GetUserByEmail(string email);

}
