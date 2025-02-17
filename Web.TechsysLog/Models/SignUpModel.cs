using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.TechsysLog.Models
{
    public class SignUpModel
    {
        public SignUpModel(string name, string email, string password, string passwordConfirm, int role)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            PasswordConfirm = passwordConfirm ?? throw new ArgumentNullException(nameof(passwordConfirm));
            Role = role;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public int Role { get; set; }
    }
}