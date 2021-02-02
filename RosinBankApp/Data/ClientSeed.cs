using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RosinBankApp.Models;

namespace RosinBankApp.Data
{
    internal static class ClientSeed
    {
        private static DateTime _initialDate = new DateTime(1970, 1, 1);

        internal static ModelBuilder AddClientSeedData(this ModelBuilder builder)
        {
            var coateRecords = new Client[]
            {
                new Client{Id =1, Name ="Тестовый клиент1", BirthDate = new DateTime(1991-03-08),PhoneNumber= "123",Adress = "г. Баткен", SocialNumber = "12345678901234"},
                new Client{Id =2, Name ="Тестовый клиент2", BirthDate = new DateTime(1996-04-20),PhoneNumber= "456",Adress = "г. Бишкек", SocialNumber = "98765432101234"},
                new Client{Id =3, Name ="Тестовый клиент3", BirthDate = new DateTime(1995-08-04),PhoneNumber= "789",Adress = "г. Нарын", SocialNumber = "12345543211234"},
                new Client{Id =4, Name ="Тестовый клиент4", BirthDate = new DateTime(1989-02-25),PhoneNumber= "789",Adress = "с. Комсомольское", SocialNumber = "12345671234567"},
            };
            builder.Entity<Client>().HasData(coateRecords);

            return builder;
        }
    }
}
