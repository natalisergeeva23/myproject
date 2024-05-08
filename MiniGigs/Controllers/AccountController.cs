using Microsoft.AspNetCore.Mvc;
using MiniGigs.Models;
using System.Text.Json;
using System.Text;

namespace MiniGigs.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Здесь добавьте логику для определения idRole на основе пользовательского ввода
                var user = new
                {
                    email = model.EmailOrPhone,
                    phoneNumber = model.EmailOrPhone,
                    name = model.Nickname,
                    nickname = model.Nickname,
                    password = model.Password,
                    fcmToken = "string", // Это значение нужно будет заменить на актуальный FCM токен
                    idRole = model.IdRole,
                    salt = "string" // И для salt, необходимо сгенерировать значение
                };

                var json = JsonSerializer.Serialize(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync("http://172.20.10.2:5089/api/Users/register", data);
                    if (response.IsSuccessStatusCode)
                    {
                        // Регистрация прошла успешно
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Обработка ошибки
                        ModelState.AddModelError(string.Empty, "Ошибка регистрации. Попробуйте ещё раз.");
                    }
                }
            }
            return View(model);
        }
    }

}
