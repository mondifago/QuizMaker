using QuizMakerApp.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuizMakerApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QuizMakerAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuizMakerAppContext") ?? throw new InvalidOperationException("Connection string 'QuizMakerAppContext' not found.")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
