//using MailKit.Security;
//using Microsoft.AspNetCore.Mvc;
//using MimeKit.Text;
//using MimeKit;
//using System.Net.Mail;

//[Route("api/[controller]")]
//[ApiController]

//public class EmailController : ControllerBase
//{ 
//[HttpPost]
//public IActionResult SendEmail(string body)
//    { 
//var email = new MimeMessage();
//email.From.Add(MailboxAddress.Parse("elijah.quitzon5@ethereal.email"));
//email.To.Add(MailboxAddress.Parse("elijah.quitzon5@ethereal.email"));
//email.Subject = "Test Email Subject";
//email.Body = new TextPart(TextFormat.Html) { Text = body };

//using var smtp = new SmtpClient();
//smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
//smtp.Authenticate("elijah.quitzon5@ethereal.email", "kX6qhsnBgF1RWjzgQk");
//smtp.Send(email);
//smtp.Disconnect(true);

//        return Ok();
//    }
//}

