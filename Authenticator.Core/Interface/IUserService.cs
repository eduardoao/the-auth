using Authenticator.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authenticator.Core.Interface
{
	public interface IUserService
	{
		User Authenticate(string username, string password);
		User CreateUser(string username, string password, string email);
	}
}
