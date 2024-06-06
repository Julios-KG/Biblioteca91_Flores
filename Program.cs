using Microsoft.EntityFrameworkCore;
using WebAPI_APPINT.Context;
using WebAPI_APPINT.Services;
using WebAPI_APPINT.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Inyecciones de Dependencias
builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();
builder.Services.AddTransient<IRegistroServices, RegistroServices>();
builder.Services.AddTransient<IAutorServices, AutorServices>();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

//AGREGANDO EL CORS
//builder.Services.AddCors(policyBuilder =>
//    policyBuilder.AddDefaultPolicy(policy =>
//        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
//);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
