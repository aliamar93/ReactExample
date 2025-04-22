using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutostoreProject.DBEntities;
using AutostoreProject.Service;
using Microsoft.EntityFrameworkCore;

namespace AutostoreProject.Repositories;

public class UserRepository : BaseRepository<AUser>
{
    // This class is responsible for handling user-related database operations
    // such as retrieving user information, adding new users, etc.
    private readonly IRepository<AUser> _userrepository;
    public UserRepository(AScaDbContext DBContext)
    :base(DBContext)
    { 
    }
    //  public async Task<AUser> GetUserByIdAsync(int id)=> await _dbSet.Where(x=>x.Id==id).FirstOrDefaultAsync();
    // public async Task<AUser> GetUserByEmailAsync(string email) => await _dbSet.Where(x => x.Email == email).FirstOrDefaultAsync();
    // public async Task<AUser> GetUserByUsernameAsync(string username) => await _dbSet.Where(x => x.UserName == username).FirstOrDefaultAsync();

    // public async Task<IEnumerable<AUser>> GetAllUsersAsync() => await _dbSet.Where(x=>x.IsActive==true).ToListAsync();
    // public async Task<AUser> AddAsync(AUser user)
    // {
    //     await _dbSet.AddAsync(user);
    //     await _DBContext.SaveChangesAsync();
    //     return user;
    // }
    // public async Task<AUser> UpdateAsync(AUser user)
    // {
    //     _dbSet.Update(user);
    //     await _DBContext.SaveChangesAsync();
    //     return user;
    // }
    // public async Task<bool> DeleteAsync(int id)
    // {
    //     var user = await GetUserByIdAsync(id);
    //     if (user == null) return false;
    //     user.IsActive = false; // Soft delete
    //     _dbSet.Remove(user);
    //     await _DBContext.SaveChangesAsync();
    //     return true;
    // }
     
}
