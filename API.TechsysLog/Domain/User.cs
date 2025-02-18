using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.TechsysLog.Domain
{
    [Table("user")]
    public class User
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; set; }
        public Role Role { get; private set; }
        public User() { }
        public User(string name, string email, string password, Role role)
        {
            Name = name;
            Email = email ?? throw new ArgumentNullException(nameof(Email));
            Password = password;
            Role = role;
        }
        

    }
    public enum Role
    {
        Employee,
        Seller,
        Buyer
    }
}

