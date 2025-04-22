using AutostoreProject.Model;
using AutostoreProject.Repositories;
using AutostoreProject.DBEntities;

namespace AutostoreProject.Service;

public class LoginService : Ilogin
{
    private readonly LoginRespository _loginRepository;

    public LoginService(LoginRespository loginRepository)
    {
        // This class is responsible for handling user login operations
        this._loginRepository = loginRepository;
    }

    public AUser FindByEmail(string email)
    {
        // Retrieve the user by email asynchronously
        return  _loginRepository.CheckFindByEmail(email);
    }

    public AUser Login(string email, string password)
    {
        var user = FindByEmail(email);
        if (user == null)
            return null;

        user= _loginRepository.GetUserByEmailAndPassword(email,password);
        if (user == null)
            return null;
        return user;
    }
}

public class SignUpService:ISignUp
{
    // This class is responsible for handling user sign-up operations
    private readonly SignUpRepository _signUpRepository;
    private readonly ICommonFunction _commonFunction;

    public SignUpService(SignUpRepository _signIpRepository,ICommonFunction commonFunction)
    {
        this._signUpRepository=_signIpRepository;
        this._commonFunction=commonFunction;
    }

    public AUser UserForSignUp(UserLogin userLogin)
    {
        try
        {
            AUser aUser = new ();
            // Check if the user already exists in the database
            aUser= _signUpRepository.CheckUserEmail(userLogin.UserNameOrEmail);
            if(aUser is null)
            {
                aUser= _signUpRepository.UserForSignUp(userLogin.UserNameOrEmail,userLogin.Password);
                return aUser;
            }
            // User already exists, return null or handle as needed
            return  null;
        }
        catch (Exception ex)
        {
            // Log the exception or rethrow it
            throw new ApplicationException("An error occurred while signing up the user.", ex);
        }
    }

    public AUser CheckUserEmail(UserLogin userLogin)
    {
        try{
            AUser aUser = new AUser();
            aUser= _signUpRepository.CheckUserEmail(userLogin.UserNameOrEmail);
            return aUser!=null ? aUser : null;
         }
        catch (Exception ex)
        {
            // Log the exception or rethrow it
            throw new ApplicationException("An error occurred while signing up the user.", ex);
        }
    }
}
