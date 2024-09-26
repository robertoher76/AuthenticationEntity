using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Models;

var builder = WebApplication.CreateBuilder(args);

//Configurar Entity Framework Core
builder.Services.AddDbContext<PeliculaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Manager", policy => policy.RequireRole("Manager"));
    options.AddPolicy("Member", policy => policy.RequireRole("Member"));
});

//builder.Services.AddAuthentication()
//        .AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<PeliculaDbContext>()
    .AddDefaultTokenProviders()
    .AddApiEndpoints();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Manager", "Member" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Asegúrate de que el rol Admin existe
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // Verifica si el usuario administrador ya existe
    var adminUser = await userManager.FindByEmailAsync("robertoher77@gmail.com");

    if (adminUser == null)
    {
        // Crear el usuario administrador
        var newAdminUser = new Usuario
        {
            UserName = "robertoher77@gmail.com",
            Email = "robertoher77@gmail.com",
            EmailConfirmed = true
        };

        // Establecer una contraseña para el usuario administrador
        var result = await userManager.CreateAsync(newAdminUser, "Password123$");

        // Si el usuario se creó exitosamente, asignar el rol de Admin
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(newAdminUser, "Admin");
        }
        else
        {
            // Manejar errores
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Error creando usuario administrador: {error.Description}");
            }
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<Usuario>();

app.Run();
