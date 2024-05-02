using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC.Data;
using System;
using System.Linq;

namespace MVC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService
                <DbContextOptions<DataContext>>()))
            {
                if (context.Person.Any())
                    return;

                context.Person.AddRange(

                    new Person
                    {
                        Name = "Damjan",
                        LastName = "Dimitrov",
                        Address = "Titov Trg 1",
                        PhoneNumber = "069 983 065"
                    },

                    new Person
                    {
                        Name = "Janez",
                        LastName = "Novak",
                        Address = "Kraljeva Ulica 20",
                        PhoneNumber = "232 466 012"
                    },

                    new Person
                    {
                        Name = "Nikita",
                        LastName = "Khatskevich",
                        Address = "Avstrovska Ulica 3",
                        PhoneNumber = "072 983 202"
                    },

                    new Person
                    {
                        Name = "Angela",
                        LastName = "Ignovska",
                        Address = "Titov Trg 1",
                        PhoneNumber = "069 212 991"
                    },

                    new Person
                    {
                        Name = "Marko",
                        LastName = "Vidmar",
                        Address = "Ljubljanska 14",
                        PhoneNumber = "051 243 318"
                    },

                    new Person
                    {
                        Name = "Martin",
                        LastName = "Gajdov",
                        Address = "Wundergarten 152",
                        PhoneNumber = "910 123 654"
                    },

                    new Person
                    {
                        Name = "John",
                        LastName = "Smith",
                        Address = "North Street 115",
                        PhoneNumber = "091 712 842"
                    },

                    new Person
                    {
                        Name = "Anita",
                        LastName = "Kavsek",
                        Address = "Trubarjeva Ulica 19",
                        PhoneNumber = "091 712 842"
                    },

                    new Person
                    {
                        Name = "Gorjan",
                        LastName = "Dimitrov",
                        Address = "Blagoj Nechev 46",
                        PhoneNumber = "070 342 007"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}