using Authenticator.Core.Auth;
using Authenticator.Core.Interface;
using Authenticator.Core.Models;
using Authenticator.Core.Repositories;
using Microsoft.Extensions.Options;

namespace Authenticator.Core.Services
{
    public class UserService : IUserService
	{
		private readonly AuthSettings _authSettings;
		private readonly IUserRepository _userRepository;
		private readonly IJwtFactory _jwtFactory;

		public UserService(IOptions<AuthSettings> authSettings, IUserRepository userRepository, IJwtFactory jwtFactory)
		{
			_userRepository = userRepository;
			_jwtFactory = jwtFactory;
			_authSettings = authSettings.Value;
		}

		public User Authenticate(string username, string password)
		{
			//var user = _userRepository.GetSingleAsync(usr => usr.Username == username && usr.Password == password).Result;
			//Só para teste
			var user = new User("eduardo", null, "eduardo oliveira", "teste@teste.com");

			if (user == null)
				return null;						

			var token = string.IsNullOrEmpty(_authSettings.SecretKey) ? null : _jwtFactory.EncodeToken(user.Username);
			user = new User(user.Username, user.Name, user.Email);
			user.SetToken(token);

			return user;
		}

		public User CreateUser(string username, string password, string email)
        {
			//Validações... todo 
			var user = new User(username, password, email);			
			return user;

        }

       
    }
}
