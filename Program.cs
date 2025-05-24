using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using EPPlusSamples;
using LYRA.Controllers.ComtrollerMedecin;
using LYRA.Controllers.ControllerFichiste;
using LYRA.Controllers.ControllerParametre;
using LYRA.Controllers.ControllerRole;
using LYRA.Controllers.ControllerSecretaire;
using LYRA.Controllers.ControllerUtilisateur;
using LYRA.Controllers.PatiantController;
using LYRA.Controllers.PharmacieController;
using LYRA.Data;
using LYRA.Models;
using LYRA.Models.Rendez_vous;
using LYRA.Models.Pharmacie;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Radzen;
using LYRA.Controllers.SoinsController;
using LYRA.Models.Administration;
using LYRA.Models.Complementaire;
using LYRA.Controllers.ControllerOrdonnance;
using Blazored.SessionStorage;
using LYRA.Models.Examens;
using LYRA.Controllers.ControllerDentiste;
using LYRA.Controllers.ControllerExamens;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using LYRA.Models.Maternites;
using LYRA.Controllers.ControllerMaternite;
using MudBlazor.Services;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<UtilisateurContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("osiet_connection"));
});
builder.Services.AddDbContext<AVROLEContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("osiet_connection"));
});
builder.Services.AddDbContext<ADHESIONContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("osiet_connection"));
});
builder.Services.AddDbContext<FICHISTEContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("osiet_connection"));
});
builder.Services.AddDbContext<PARAMETREContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("osiet_connection"));
});
builder.Services.AddDbContext<COMPLEMENTAIREContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("osiet_connection"));
});
builder.Services.AddDbContext<CONSULTATIONContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("osiet_connection"));
});
builder.Services.AddDbContext<RDVContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("osiet_connection"));
});
builder.Services.AddDbContext<PHARMACIEContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("osiet_connection"));
});
builder.Services.AddDbContext<EXAMENSContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("osiet_connection"));
});
builder.Services.AddDbContext<MATERNITEContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("osiet_connection"));
});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
builder.Services.AddScoped<IAvoirRoleService, AvRolesService>();
builder.Services.AddScoped<IURoleService, URoleService>();
builder.Services.AddScoped<IAdhesionService, AdhesionService>();
builder.Services.AddScoped<IAffiliationService, AffiliationService>();
builder.Services.AddScoped<IFichisteService, FichisteService>();
builder.Services.AddScoped<ILoginControl, LoginControl>();
builder.Services.AddScoped<IParametreService, ParametreService>();
builder.Services.AddScoped<IPatiantService, PatiantService>();
builder.Services.AddScoped<IMedecinService, MedecinService>();
builder.Services.AddScoped<IPharmacieService, PharmacieService>();
builder.Services.AddScoped<IOrdonnanceService, OrdonnanceService>();
builder.Services.AddScoped<ISoinsService, SoinsService>();
builder.Services.AddScoped<IDentisteService, DentisteService>();
builder.Services.AddScoped<IExamenService, ExamenService>();
builder.Services.AddScoped<IMaterniteService, MaterniteService>();
builder.Services.AddScoped<FileUtil>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextAccessor>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddBlazoredModal();
builder.Services.AddScoped<Radzen.DialogService>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddMudServices();
builder.Services
  .AddBlazorise()
  .AddBootstrap5Providers()
  .AddFontAwesomeIcons();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\lib")),
    RequestPath = new PathString("/lib")
});
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\historiques")),
    RequestPath = new PathString("/historiques")
});
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\historiques")),
    RequestPath = new PathString("/archives")
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
