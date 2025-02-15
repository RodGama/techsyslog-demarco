namespace API.TechsysLog.DTOs
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public Role Role{ get; set; }

    }

    public enum Role
    {
        Employee,
        Seller,
        Buyer
    }
}
