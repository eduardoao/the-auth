using System;
using System.Collections.Generic;
using System.Text;

namespace Authenticator.Core.Models
{
	public class User
	{
        public User(string username,  string name, string email)
        {
            Username = username;    
            Name = name;
            Email = email;
        }

        public User(string username, string password, string name, string email)
        {
            Username = username;
            Password = password;
            Name = name;
            Email = email;
        }

        public User()
        {

        }

        public void SetToken(string token)
        {
            this.Token = token;
        }

        public string Username { get; private set; }
		
		public string Password { get; private set; }

		public string Token { get; private set; }

        public string Name { get; private set; }
		public string Email { get; private set; }
        public DateTime CreateDate { get; private set; }


        public override string ToString() => $"{Name} | {Username}";
	}
}
