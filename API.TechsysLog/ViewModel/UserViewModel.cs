using API.TechsysLog.Domain;

namespace API.TechsysLog.ViewModel
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public Role Role { get; set; }
    }
}
