namespace API.TechsysLog.ViewModel
{
    public class UserUpdateViewModel
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
