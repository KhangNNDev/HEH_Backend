using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Options;
using ScheduleManagementSession01.Extensions;
using Services.Hubs;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.ConfigIdentityService();

builder.Services.AddBussinessService();
builder.Services.ConfigureSwagger();
builder.Services.AddJWTAuthentication(builder.Configuration["Jwt:Key"], builder.Configuration["Jwt:Issuer"]);

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithOrigins("http://localhost:3000",
        "https://localhost:3000",
        "https://taskuat.hisoft.vn",
        "https://task.hisoft.vn",
        "https://taskuatapi.hisoft.vn",
        "https://physical-therapy-pi.vercel.app",
        "https://github.com/codespaces/auth/tonynguyen2512-stunning-space-xylophone-55jrxpgq57qhvvp4?visibility=private&port=3000&cid=4fe1cf62a5124d11dbe1ba6a6af76d64",
        "https://sandbox.vnpayment.vn/"
        );
}));

builder.Services.AddSignalR();

// Setting token life
// defaul: 2 hours
builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
                                opt.TokenLifespan = TimeSpan.FromHours(2));

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

builder.Services.Configure<RequestLocalizationOptions>(option =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("vi-VN")
    };

    option.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(culture: "vi-VN", uiCulture: "vi-VN");
    option.SupportedCultures = supportedCultures;
    option.SupportedUICultures = supportedCultures;
});


//builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
//{
//    builder.AllowAnyOrigin()
//                   .AllowAnyMethod()
//                   .AllowAnyHeader();
//}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app cors
app.UseCors("CorsPolicy");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapHub<NotificationHub>("/notificationHub");
});

app.MapControllers();

app.Services.ApplyPendingMigrations();

app.UseForwardedHeaders();

var localizeOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizeOptions.Value);

app.Run();
