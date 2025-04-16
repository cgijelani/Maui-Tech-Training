using MAUI101.Maui.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.Services
{
    public class UserService
    {
        public string CurrentUser { get; set; }

        private readonly LocalDbService _localDbService;

        public UserService(LocalDbService localDbService)
        {
            _localDbService = localDbService;
        }

        /// <summary>
        /// Handles logging in a user.
        /// </summary>
        public async Task Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new LoginValidationException();
            }

            var user = await _localDbService.GetUser(username);

            if (user == null || user.Password != password)
            {
                throw new LoginFailedException();
            }

            CurrentUser = username;

			await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }

        /// <summary>
        /// Handles registering a new user.
        /// </summary>
        public async Task Register(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new LoginValidationException();
            }

            var user = await _localDbService.GetUser(username);

            // User already exists.
            if (user != null)
            {
                throw new UsernameTakenException();
            }

            // Create new user and login.
            var id = await _localDbService.AddUser(username, password);

            //Error adding user
            if (id == -1)
            {
                throw new Exception("Error adding new user. Please contact admin if issue persists.");
            }

			await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
		}
    }
}