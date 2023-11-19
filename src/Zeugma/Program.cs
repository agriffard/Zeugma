using Zeugma.Client.Pages;
using Zeugma.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOrchardCms();
    //.ConfigureServices(svc => {
    //    svc.AddServerSideBlazor();
    //})
    //.Configure((a, b, c) => {
    //    b.MapBlazorHub();
    //    a.UseStaticFiles();
    //});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

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

app.UseStaticFiles();
app.UseAntiforgery();

app.UseOrchardCore();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
