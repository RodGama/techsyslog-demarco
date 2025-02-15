using API.TechsysLog.Domain;

namespace API.TechsysLog.ViewModel
{
    public class UserRequestViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
