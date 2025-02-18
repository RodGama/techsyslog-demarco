using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.TechsysLog.Models
{
    public class UpdateUserModel
    {
        public UpdateUserModel(int userId, string oldPassword, string password, string passwordConfirm)
        {
            UserId = userId;
            OldPassword = oldPassword ?? throw new ArgumentNullException(nameof(oldPassword));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            PasswordConfirm = passwordConfirm ?? throw new ArgumentNullException(nameof(passwordConfirm));
        }

        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}