using main.interfacerepo;
using main.interfaceservice;
using main.repoS;
using main.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<loginInterface, loginservice>();
builder.Services.AddScoped<loginrepoInterface, loginRepos>();
builder.Services.AddScoped<studentmanagementrepoInterface, studentManagementRepo>();
builder.Services.AddScoped<studentmanagementserviceInterface, studentManagementService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.AllowAnyOrigin()  // Allow ALL ports during development
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");        // ✅ CORS first
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();