using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using RosinBankApp.Data;
using RosinBankApp.Models;

namespace RosinBankApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            using (var workbook=new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Дата");
                var currentRow = 4;
                worksheet.Cell(currentRow, 4).Value = "Дата";
                worksheet.Cell(currentRow, 5).Value = "ID";
                worksheet.Cell(currentRow, 6).Value = "Фамилия имя";
                worksheet.Cell(currentRow, 7).Value = "Дата рождения";
                worksheet.Cell(currentRow, 8).Value = "Номер телефона";
                worksheet.Cell(currentRow, 9).Value = "Адрес клиента";
                worksheet.Cell(currentRow, 10).Value = "ИНН клиента";



                foreach (var client in _context.Clients.Where(x=>x.SocialNumber== "12345671234567"))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 4).Value = DateTime.Now;
                    worksheet.Cell(currentRow, 5).Value = client.Id;
                    worksheet.Cell(currentRow, 6).Value = client.Name;
                    worksheet.Cell(currentRow, 7).Value = client.BirthDate;
                    worksheet.Cell(currentRow, 8).Value = client.PhoneNumber;
                    worksheet.Cell(currentRow, 9).Value = client.Adress;
                    worksheet.Cell(currentRow, 10).Value = client.SocialNumber;

     
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ClientData.xlsx"
                    ); 
                }
      
            }
        }




        
    }
}
