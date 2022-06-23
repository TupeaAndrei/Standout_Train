using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Standout_Train.DAL.AppRepository;
using Standout_Train.DAL.Context;
using Standout_Train.DAL.Interfaces;
using Standout_Train.Data;
using AutoMapper;
using Swashbuckle;
using Microsoft.OpenApi.Models;
using Standout_Train.BL.Interfaces;
using Standout_Train.BL.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => { options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<TrainContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    });

builder.Services.AddCors();


#region Repositories
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITrainRepository, TrainRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseCors(opt => {
        opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
    app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = String.Empty;
        });
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.MapRazorPages();

app.Run();
