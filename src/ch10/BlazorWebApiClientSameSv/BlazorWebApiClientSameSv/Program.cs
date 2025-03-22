using BlazorWebApiClientSameSv.Client.Pages;
using BlazorWebApiClientSameSv.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

// web api �̐ݒ�
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<
    BlazorWebApiClientSameSv.Models.BlazordbContext>(
    options => options.UseSqlServer(
        builder.Configuration
        .GetConnectionString("DBConnection")));
// inject HttpClient
builder.Services.AddScoped(sp =>
{
    var nav = sp.GetRequiredService<NavigationManager>();
    return new HttpClient { BaseAddress = new Uri(nav.BaseUri) };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWebApiClientSameSv.Client._Imports).Assembly);
// web api �̐ݒ�
app.MapControllers();

app.Run();
