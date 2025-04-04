using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Natinael_Sambi_ADP631_FA1.Data;
using Natinael_Sambi_ADP631_FA1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container
builder.Services.AddControllersWithViews(); // Enable MVC

// Configure DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services for Dependency Injection
builder.Services.AddScoped<ICitizenService, CitizenService>(); 
builder.Services.AddScoped<IServiceRequestService, ServiceRequestService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IReportService, ReportService>();

var app = builder.Build();

// Configure the HTTP pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Map controller routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
