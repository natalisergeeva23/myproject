using Microsoft.AspNetCore.Mvc;
using MiniGigs.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace MiniGigs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Authorization()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }


        public IActionResult CustomerOffice()
        {
            return View();
        }

        public IActionResult ExecutorOffice()
        {
            return View();
        }

        public IActionResult AboutProjectCustomer()
        {
            return View();
        }
        public IActionResult AboutProjectExecutor()
        {
            return View();
        }
        

        public IActionResult AddCustom()
        {
            return View();
        }

        public IActionResult TaskSearch()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            return View();
        }

        public IActionResult MyOrders()
        {
            return View();
        }

        public IActionResult FinanceCustomer()
        {
            return View();
        }

        public IActionResult FinanceExecutor()
        {
            return View();
        }

        public IActionResult LevelExecuter()
        {
            return View();
        }

        public IActionResult LevelCustomer()
        {
            return View();
        }


        public IActionResult BalanceReplenishCustomer()
        {
            return View();
        }


        public IActionResult WithdrawMoneyCustomer()
        {
            return View();
        }

        public IActionResult WithdrawMoneyExecuter()
        {
            return View();
        }
        public IActionResult SettingsCustomer()
        {
            return View();
        }

        public IActionResult SettingsExecuter()
        {
            return View();
        }
        public IActionResult SupportServiceCustomer()
        {
            return View();
        }

        public IActionResult SupportServiceExecuter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(Send send, string userRole)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("minigigs2024@mail.ru", "MiniGigs");
       
            // кому отправляем
            MailAddress to = new MailAddress(send.Email);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Обращение от пользователя";
            // текст письма
            m.Body = "Сообщение отправлено. Спасибо вам, мы скоро свяжемся с вами";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru");
            // логин и пароль
            smtp.Credentials = new NetworkCredential("minigigs2024@mail.ru", "zxcxRjK8APskJAVv2L3c");
            smtp.EnableSsl = true;
            smtp.Send(m);

            MailAddress too = new MailAddress("minigigs2024@mail.ru", "MiniGigs");
            MailMessage mo = new MailMessage(too, too);
            mo.Subject = "Обращение от пользователя " + send.Email;
            // текст письма
            mo.Body = send.Message;
            // письмо представляет код html
            mo.IsBodyHtml = true;


            smtp.Credentials = new NetworkCredential("minigigs2024@mail.ru", "zxcxRjK8APskJAVv2L3c");
            smtp.EnableSsl = true;
            smtp.Send(mo);
            if (userRole == "1")
            {
                return View("SupportServiceCustomer");
            }
            else if (userRole == "2")
            {
                return View("SupportServiceExecuter");
            }
            else
            {
                // Если роль не определена, показываете сообщение или делаете что-то ещё
                return View("SupportService"); // или что-то другое
            }
        }

    }
}