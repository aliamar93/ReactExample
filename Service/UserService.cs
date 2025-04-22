using System;
using System.Threading.Tasks;
using AutostoreProject.DBEntities;
using AutostoreProject.Repositories;

namespace AutostoreProject.Service;

public class UserService : IUserService
{
    private readonly IRepository<AUser> _userRepository;
    private readonly ICommonFunction _commonFunction;
    
    public UserService(IRepository<AUser> userRepository,ICommonFunction commonFunction)
    {
        this._userRepository = userRepository;
       this. _commonFunction = commonFunction;
    }
    public async Task AddUser(AUser user)
    {
    try
    {
         if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))  
        {
            throw new ArgumentException("User, email, or password cannot be null or empty", nameof(user));
            // throw new ArgumentNullException(nameof(user), "User cannot be null");
        }
        user.Password= _commonFunction.Encryption(user.Password);
        await _userRepository.AddAsync(user);
    }
    catch (Exception ex)
    {
        // Log the exception or rethrow it
        throw new ApplicationException("An error occurred while adding the user.", ex);
    }
}
    public async Task<IEnumerable<AUser>> GetAllUsers()
    {
        // await Task.Delay(1000); // Simulate some delay
        try
        {
            return await _userRepository.GetAllAsync();
        }
        catch (Exception ex)
        {
            // Log the exception or rethrow it
            throw new ApplicationException("An error occurred while retrieving users.", ex);
        }
    }

    public AUser GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public AUser GetUserById(int id)
    {
        throw new NotImplementedException();
    }
}
