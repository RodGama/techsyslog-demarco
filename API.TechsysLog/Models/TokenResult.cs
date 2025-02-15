using API.TechsysLog.Domain;

namespace API.TechsysLog.Models
{
    public class TokenResult
    {
        public int UserId { get; set; }
        public bool IsValid { get; set; }
    }
}
