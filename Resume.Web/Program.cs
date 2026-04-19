using System.Text.Encodings.Web;
using System.Text.Unicode;
using DNTCaptcha.Core;
using Microsoft.EntityFrameworkCore;
using Resume.Infra.Data.Context;
using Resume.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region DataBase Pool Connection For Db

// Configure Database connection service
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ResumeDataBase"), sqlServerOptionsAction:
        sqlOption =>
        {
            sqlOption.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }));

#endregion

#region IOC Configuration's

//static void RegisterService(IServiceCollection service)
//{
//    DependencyContainers.RegisterService(service);
//}

//#region Config's Services

//RegisterService(builder.Services);

//#endregion

//Optimization Code's
DependencyContainers.RegisterService(builder.Services);

#endregion

#region Configure DntCaptcha

// builder.Services.AddDNTCaptcha(options =>
// {
//     options.UseCookieStorageProvider(SameSiteMode.Strict) // یا UseSessionStorageProvider
//         .ShowThousandsSeparators(false)
//         .WithEncryptionKey("MySuperSecureKey123");
// });

builder.Services.AddDNTCaptcha(options =>
{
    options.UseCookieStorageProvider()
        .ShowThousandsSeparators(false)
        .WithEncryptionKey("MySuperSecureKey123");
});

#endregion

#region Encoder

builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

#endregion

// AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
