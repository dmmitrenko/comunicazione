using ApplicationCore.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Users.Any())
                {
                    context.Users.Add(new User()
                    {
                        Username = "alexandrr",
                        Name = "Alexander",
                        Surname = "Pushkin",
                        Email = "alexandr@mail.com",
                        Password = "dwTr78o",
                        Country = "Russian Empire",
                        Gender = Gender.male,
                        Birthday = new DateTime(1799, 5, 26),
                        Bio = "Russian poet, playwright, and novelist of the Romantic era"
                    }) ;
                }
                context.SaveChanges();

            }
        }
    }
}
