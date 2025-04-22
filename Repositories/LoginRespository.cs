using System;
using AutostoreProject.DBEntities;
using AutostoreProject.Model;
using AutostoreProject.Service;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using static AutostoreProject.Model.CommonFunction;

namespace AutostoreProject.Repositories;

public class LoginRespository
{
    // This class is responsible for handling user login operations
    private readonly ICommonFunction _commonFunction;
    private readonly AScaDbContext _DBcontext;
    public LoginRespository(AScaDbContext DBcontext,ICommonFunction commonFunction)
    {
        _DBcontext = DBcontext;
        _commonFunction = commonFunction;
    }
    public AUser GetUserByEmailAndPassword(string email, string password)
    {
        // Retrieve the user by email and password asynchronously
        return  _DBcontext.AUsers.Where(x => x.Email == email && x.Password == _commonFunction.Encryption(password)).FirstOrDefault();
    }
    public AUser CheckFindByEmail(string email)
    {
        return  _DBcontext.AUsers.Where(x => x.Email == email).FirstOrDefault();
    }
}
