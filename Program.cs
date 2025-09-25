using ClgManagementServer.DataBase;
using ClgManagementServer.Services;
using ClgManagementServer.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
builder.Services.AddSingleton<DbContext>();
builder.Services.AddSingleton<ICollegeServices, CollegeServices>();
builder.Services.AddSingleton<IBranchServices, BranchServices>();
builder.Services.AddSingleton<IDegreeServices, DegreeServices>();
builder.Services.AddSingleton<IStudentServices, StudentServices>();
builder.Services.AddSingleton<IFacultyServices, FacultyServices>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
