using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.ComponentModel.DataAnnotations;
using Entities.Concrete;
using Business.Contants;
using Business.Abstract;
using DataAccess.Abstract;
using System.Security.Cryptography.X509Certificates;
using Entities.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContollers : ControllerBase
    {
        IUserService _userService;
        IUserDal _userDal;


        public UserContollers(IUserService userService,IUserDal userDal)
        {
            _userService= userService;
            _userDal= userDal;  
        }

        [HttpPost("Kayıt Ol")]
        public IActionResult Add ([FromQuery] UserDto user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {

                //var mail = new Mailing();
                //mail.SendMail(from, to, subject, message);
                return Ok(result);  
            }
            return BadRequest(result);
        }


        public class Mailing
        {
            
           

            public void SendMail(string from, string to, string subject, string message)
            {
                var xx = new User();
                var client = new SmtpClient("smtp.gmail.com", 587)
                {

                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("sdestur05@gmail.com", "eotnrjfnfakobvjk"),
                    EnableSsl = true,
                    Timeout = 10000,

                };
                var mailMessage = new MailMessage(from = "sdestur05@gmail.com", to = xx.Email, subject = "Hoşgeldin", message = "Alışveriş Sitesine Hoşgeldiniz");

                client.Send(mailMessage);

            }
        }


        [HttpPost("Güncelleme")]
        public IActionResult Update([FromQuery] User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);  
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromQuery] User user)
        {
            var result = _userService.Delete(user); 
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

    }
}
