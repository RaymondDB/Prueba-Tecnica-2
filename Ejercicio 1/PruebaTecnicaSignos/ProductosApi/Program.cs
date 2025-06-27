
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSignos.Application.Services;
using PruebaTecnicaSignos.Domain.Interfaces;
using PruebaTecnicaSignos.Infraestructure.Data;
using PruebaTecnicaSignos.Infraestructure.Repositories;
using PruebaTecnicaSignos.ProductosApi.GraphQL;


var builder = WebApplication.CreateBuilder(args);

// Inyección del DbContext y repositorios
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<CategoriaService>();

builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<ProveedorService>();

builder.Services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();
builder.Services.AddScoped<UnidadMedidaService>();

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ProductoService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<PruebaTecnicaSignos.ProductosApi.GraphQL.Query>()
    .AddMutationType<PruebaTecnicaSignos.ProductosApi.GraphQL.Mutation>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapGraphQL("/graphql");
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();