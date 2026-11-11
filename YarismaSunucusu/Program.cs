using Microsoft.EntityFrameworkCore;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.Model;
using YarismaSunucusu.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<YarismaSunucusuDBContext>(option => {
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<SunucuSaatiRepository>();
builder.Services.AddScoped<QRKoordinatlariRepository>();
builder.Services.AddScoped<HavaSavunmaSahasiRepository>();
builder.Services.AddScoped<HssKoordinatlariRepository>();
builder.Services.AddScoped<KamikazeBilgisiRepository>();
builder.Services.AddScoped<KilitlenmeBilgisiRepository>();

builder.Services.AddScoped<GirisRepository>();
builder.Services.AddScoped<KonumBilgisiRepository>();
builder.Services.AddScoped<SaatRepository>();
builder.Services.AddScoped<TelemetriCevabiRepository>();
builder.Services.AddScoped<TelemetriPaketiRepository>();

var app = builder.Build();

//**********************************Updating time every one second.**********************************
var scope = app.Services.CreateScope();
var repository = scope.ServiceProvider.GetRequiredService<SunucuSaatiRepository>();
var cancellationToken = new CancellationTokenSource();
_ = Task.Run(async () =>
{
    try
    {
        await repository.PeriodicUpdateTimeAsync(cancellationToken.Token, TimeSpan.FromSeconds(1));

    }
    catch (Exception ex)
    {
         Console.WriteLine("Time Update exception: " + ex.Message);
    }
},cancellationToken.Token);
//***************************************************************************************************


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
