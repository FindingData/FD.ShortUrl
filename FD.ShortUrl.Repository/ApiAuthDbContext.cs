using Duende.IdentityServer.EntityFramework.Options;
using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FD.ShortUrl.Auth.Data
{
    public class ApiAuthDbContext : IdentityDbContext<ApiApplicationUser, ApiApplicationRole,Guid, ApiApplicationUserClaim,
        ApiApplicationUserRole, ApiApplicationUserLogin, ApiApplicationRoleClaim, ApiApplicationUserToken>
    {
        public ApiAuthDbContext(DbContextOptions<ApiAuthDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            

            builder.Entity<ApiApplicationUser>(b => {
                b.ToTable("t_user");

                b.Property(e => e.Email).HasColumnName("UserMail");
                b.Property(u => u.UserName).HasMaxLength(128);

                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<ApiApplicationRole>(b =>
            {
                b.ToTable("t_role");
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            builder.Entity<ApiApplicationUserRole>(b => b.ToTable("t_user_role"));
            builder.Entity<ApiApplicationUserClaim>(b => b.ToTable("t_user_claim"));
            builder.Entity<ApiApplicationUserLogin>(b => b.ToTable("t_user_login"));
            builder.Entity<ApiApplicationUserToken>(b => b.ToTable("t_user_token"));
            builder.Entity<ApiApplicationRoleClaim>(b => b.ToTable("t_role_claim"));


        }

        public DbSet<ApiApplicationUser> Users { get; set; }

        public DbSet<ApiApplicationRole> Roles { get; set; }
    }
}