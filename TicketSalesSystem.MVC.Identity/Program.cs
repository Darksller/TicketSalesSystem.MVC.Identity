using TicketSalesSystem.BLL.Configurations;
using TicketSalesSystem.DAL.Configurations;
using TicketSalesSystem.MVC.Identity.Interfaces;
using TicketSalesSystem.MVC.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityConfigurations(builder.Configuration);
builder.Services.AddRazorPages();
builder.Services.AddBusinessLogicServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
