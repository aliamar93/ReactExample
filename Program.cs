using System.Reflection.Metadata;
using System.Text;
using AutostoreProject.DBEntities;
using AutostoreProject.Model;
using AutostoreProject.Repositories;
using AutostoreProject.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Configure Entity Framework Core with SQL Server
// Ensure you have the correct connection string in your appsettings.json
builder.Services.AddDbContext<AScaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<Ilogin,LoginService>();
builder.Services.AddScoped<ISignUp,SignUpService>();
builder.Services.AddScoped<ICommonFunction, CommonFunction>();
builder.Services.AddScoped<LoginRespository>();
builder.Services.AddScoped<SignUpRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IRepository<AUser>,UserRepository>();  // Should resolve successfully
// builder.Services.AddScoped(typeof(IRepository<>),typeof(BaseRepository<>));



// Add JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = builder.Environment.IsDevelopment() ? false : true; // For production, enforce HTTPS. // Set to true for production
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };
});
// Add authorization policies if needed
builder.Services.AddAuthorization(options =>
{
    // Define your authorization policies here if needed
    // For example:
    // options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
    // options.AddPolicy("User", policy => policy.RequireClaim("User"));
});
// Configure CORS policy
// This is a simple CORS policy allowing any origin, method, and header.
var MyAllowSpecificOrigins = "https://scaautostore.runasp.net/"; // Replace with your frontend URL

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:44491") // Frontend origin
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
// 👉 Add this:
app.UseCors(MyAllowSpecificOrigins);
// Use authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
