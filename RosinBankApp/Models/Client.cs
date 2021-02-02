using System;
using System.ComponentModel.DataAnnotations;

namespace RosinBankApp.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия и имя")]
        public string Name { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Номер телефона")]
        public string Adress { get; set; }

        [Display(Name = "ИНН")]
        public string SocialNumber { get; set; }
    }
}