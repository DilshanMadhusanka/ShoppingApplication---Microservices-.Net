using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingApplication.Services.CouponAPI;
using ShoppingApplication.Services.CouponAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//------------------------------------------------------------------------

// conect the database 

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"
        )));

//--------------------------------------------------------------------

// Auto Mappping 
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//----------------------------------------------------------------------

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//--------------------------------------------------------------------------------
ApplyMigration();//  pahal functions eka call kre
//--------------------------------------------------------------------------------
app.MapControllers();

app.Run();


//-------------------------------------------------------------------------------

// Apply Migrations atuomatically

void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}


