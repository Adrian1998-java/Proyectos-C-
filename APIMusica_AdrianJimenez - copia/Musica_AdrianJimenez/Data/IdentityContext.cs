namespace Musica_AdrianJimenez.Data;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musica_AdrianJimenez.Models;

public class IdentityContext : IdentityDbContext
    {
    public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Creamos Usuarios
        var users = new List<AppUser>() {
                new AppUser
                {
                    UserName = "adrian@adrian.com",
                    NormalizedUserName = "ADRIAN@ADRIAN.COM",
                    Email = "adrian@adrian.com",
                    NormalizedEmail = "ADRIAN@ADRIAN.COM",
                    EmailConfirmed = true,
                    nombre = "Adrian",
                    apellidos = "Jimenez Mendoza",
                    codigoPostal = "28611",
                },
                new AppUser
                {
                    UserName = "lorena@lorena.com",
                    NormalizedUserName = "LORENA@LORENA.COM",
                    Email = "lorena@lorena.com",
                    NormalizedEmail = "LORENA@LORENA.COM",
                    EmailConfirmed = true,
                    nombre = "Lorena",
                    apellidos = "Jimenez Mendoza",
                    codigoPostal = "28611",
                }
            };

        modelBuilder.Entity<AppUser>().HasData(users);

        var passwordHasher = new PasswordHasher<AppUser>();
        users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Adrian1998");

        //Añadimos roles
        var roles = new List<IdentityRole>()
            {
                 new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "user",
                    NormalizedName = "USER"
                },
                new IdentityRole()
                {
                    Name = "manager",
                    NormalizedName = "MANAGER"
                }
            };

        modelBuilder.Entity<IdentityRole>().HasData(roles);

        //AHORA AÑADIMOS los datos de UsersRoles
        var userRoles = new List<IdentityUserRole<string>>() {
                new IdentityUserRole<string>
                {
                    UserId = users[0].Id,
                    RoleId = roles[0].Id,

                },
                new IdentityUserRole<string>
                {
                    UserId = users[1].Id,
                    RoleId = roles[1].Id,

                }
            };
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

        modelBuilder.Entity<AppUser>().Property(p => p.UserName).IsRequired();
        modelBuilder.Entity<AppUser>().Property(p => p.Email).IsRequired();

        modelBuilder.Entity<AppUser>().Ignore(a => a.roles);
        modelBuilder.Entity<AppUser>().Ignore(a => a.password);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<AppUser> User { get; set; }
}
