using clockECommerce.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace clockECommerce.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of Clock ECommerce" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of Clock ECommerce" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of Clock ECommerce" }
               );

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "lequocanh.qa@gmail.com",
                NormalizedEmail = "lequocanh.qa@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                PhoneNumber = "0774642207",
                Address = "123 Lien Ap 2-6 X.Vinh Loc A H. Binh Chanh",
                Name = "Quoc Anh",
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            #region Seed Category
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Daniel Wellington"
                },

                new Category()
                {
                    Id = 2,
                    Name = "Casio"
                },

                new Category()
                {
                    Id = 3,
                    Name = "Citizen"
                }
              );
            #endregion

            #region Seed Product
            modelBuilder.Entity<Product>().HasData(
                 new Product()
                 {
                     Id = 1,
                     Name = "DANIEL WELLINGTON DW00100414",
                     CategoryId = 1,
                     originPrice = 6000000,
                     Price = 6600000,
                     Stock = 5,
                     DateCreated = new DateTime(2021, 11, 18),
                     Description = "",
                     Details = ""
                 },

                new Product()
                {
                    Id = 2,
                    Name = "CASIO EFB-302JD-1ADR",
                    CategoryId = 2,
                    originPrice = 10000000,
                    Price = 10882000,
                    Stock = 5,
                    DateCreated = new DateTime(2021, 11, 18),
                    Description = "",
                    Details = ""
                },

                new Product()
                {
                    Id = 3,
                    Name = "CITIZEN NB1021-57E",
                    CategoryId = 3,
                    originPrice = 14000000,
                    Price = 14700000,
                    Stock = 5,
                    DateCreated = new DateTime(2021,11,18),
                    Description = "",
                    Details = ""
                }
             );
            #endregion
        }
    }
}
