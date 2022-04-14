using EmpApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();

// if (builder.Environment.IsProduction())
// {
Console.WriteLine("-->Adding  EmloyeeDbContext  Service");
builder.Services.AddDbContext<EmployeeDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("EmpDb")));

// }
// else if (builder.Environment.IsDevelopment())
// {
//     Console.WriteLine("-->Adding Service EmloyeeDbContext on PROD");
//     builder.Services.AddDbContext<EmployeeDbContext>(opt =>
//     opt.UseInMemoryDatabase("InMem"));
// }
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(p =>
    {
        p.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API");
        p.RoutePrefix = string.Empty;
    });

}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

EmpDb.Seed(app, builder.Environment.IsProduction());

app.Run();


