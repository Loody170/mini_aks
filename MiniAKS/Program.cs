using Microsoft.EntityFrameworkCore;
using MiniAKS_Database.Database;
using MiniAKS_Database.Helpers;
using MiniAKS_Database.Repositories;
using MiniAKS_Database.Repositories.Interfaces;
using MiniAKS_Services.Interfaces;
using MiniAKS_Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MiniAKSDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//insert repo services
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IStationRepository, StationRepository>();
builder.Services.AddScoped<ISalesChannelRepository, SalesChannelRepository>();
builder.Services.AddScoped<ICustomizationRepository, CustomizationRepository>();

//insert services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStationService, StationService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ISalesChannelService, SalesChannelService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomizationService, CustomizationService>();



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

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

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MiniAKSDbContext>();
    Seed.SeedData(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
