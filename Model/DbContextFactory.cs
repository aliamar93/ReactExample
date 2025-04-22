// namespace AutostoreProject.Model
// {
//     public class DbContextFactory : IDbContextFactory<AScadbContext>
//     {
//         private readonly IConfiguration _configuration;

//         public DbContextFactory(IConfiguration configuration)
//         {
//             _configuration = configuration;
//         }

//         public AScadbContext CreateDbContext()
//         {
//             var optionsBuilder = new DbContextOptionsBuilder<AScadbContext>();
//             optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

//             return new AScadbContext(optionsBuilder.Options);
//         }
//     }

// }