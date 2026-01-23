using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDataContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")) );
builder.Services.AddScoped<ApplicationDataContext>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

