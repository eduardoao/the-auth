using System;

namespace Authenticator.Api.Dto
{
    [Serializable]
	public class UserAuthenticatorDto
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
