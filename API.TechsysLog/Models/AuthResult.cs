﻿using API.TechsysLog.Domain;

namespace API.TechsysLog.Models
{
    public class AuthResult
    {
        public User? User { get; set; }
        public bool IsValid { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
        public IList<string> Errors { get; set; }
    }
}
