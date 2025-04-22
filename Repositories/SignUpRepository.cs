using System;
using AutostoreProject.DBEntities;
using AutostoreProject.Model;
using AutostoreProject.Service;
using Microsoft.EntityFrameworkCore;

namespace AutostoreProject.Repositories;

public class SignUpRepository 
{    // This class is responsible for handling user sign-up operations
    private readonly AScaDbContext _DBcontext;
    private readonly ICommonFunction _IcommonFunction;

    public SignUpRepository(AScaDbContext DBContext, ICommonFunction IcommonFunction)
    {
        this._DBcontext = DBContext;
        this._IcommonFunction = IcommonFunction;
    }

    public AUser CheckUserEmail(string email)
    {
        return _DBcontext.AUser.Where(x=>x.Email== email).FirstOrDefault();
    }

    public AUser UserForSignUp(string email,string password)
    {
        AUser aUser = new AUser();
        aUser.Email = email;
        aUser.Password = _IcommonFunction.Encryption(password);
        //0 means no user created by this user
        aUser.CreatedBy = 0;
        aUser.CreatedDate = DateTime.Now;
        aUser.IsActive = true;
        _DBcontext.AUsers.Add(aUser);
        _DBcontext.SaveChanges();
        return aUser;
    }   
}
