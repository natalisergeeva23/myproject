namespace MiniGigs.Models
{
    public class RegisterViewModel
    {
        public string EmailOrPhone { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; } // 0 для заказчика, 1 для исполнителя
    }

}
