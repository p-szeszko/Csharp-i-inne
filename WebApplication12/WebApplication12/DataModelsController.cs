using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication12
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataModelsController : ControllerBase
    {
        private readonly AppContext _context;

        public DataModelsController(AppContext context)
        {
            _context = context;
        }

       

        // GET: api/DataModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDataModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dataModel = await _context.Data.FindAsync(id);

            if (dataModel == null)
            {
                return NotFound();
            }

            return Ok(dataModel);
        }

      
        // POST: api/DataModels
        [HttpPost]
        public async Task<IActionResult> PostDataModel([FromBody] DataModel dataModel)
        {
            if (!ModelState.IsValid)
            {
                Console.Write("Błąd");
                return BadRequest(ModelState);
            }
            else
            {
                MailAddress to = new MailAddress(dataModel.Mail);
                MailAddress from = new MailAddress("pwrdotnetlab@gmail.com");
                MailMessage message = new MailMessage(from, to);
                message.Subject = dataModel.Title;
                message.Body = dataModel.Description;
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "pwrdotnetlab@gmail.com",
                        Password = "-Password1"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }
            }

            _context.Data.Add(dataModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataModel", new { id = dataModel.ID }, dataModel);
        }


        private bool DataModelExists(int id)
        {
            return _context.Data.Any(e => e.ID == id);
        }
    }
}