using System;

namespace Authenticator.Api.Dto
{
    [Serializable]
	public class UserCreateDto
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

	}
}
