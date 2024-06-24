using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Ocsp;
using RugbyClubAachenWeb.Database;
using RugbyClubAachenWeb.Fetchers;
using RugbyClubAachenWeb.Pages;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//TODO: Add the file that feches the imagepathes to be injected in Layout.cshtml
builder.Services.AddTransient<PictureFetcher>();
builder.Services.AddTransient<DbConnections>();
builder.Services.AddTransient<UserFetcher>();
//
builder.Services.AddSingleton<IPasswordHasher<UserFetcher>, PasswordHasher<UserFetcher>>();

//Services for multi language support
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions> (options =>
{
    var supportedCultures = new []
    {
        new CultureInfo("en"),
        new CultureInfo("de"),
        new CultureInfo("nl"),
        // new CultureInfo("fr"),
        new CultureInfo("afr")
    };
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddRazorPages()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options => {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(LanguageViewLocationExpander));// was typeof(SharedResource);
    });


builder.Services.Configure<PasswordHasherOptions>(options =>
{
    options.IterationCount = 10000;
});

// Register your UserFetcher
builder.Services.AddTransient<UserFetcher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var localizationOptions = app.Services
    .GetService<IOptions<RequestLocalizationOptions>>()
    .Value;
app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseRequestLocalization();

app.MapRazorPages();

// Apply localization settings
var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

app.Run();
