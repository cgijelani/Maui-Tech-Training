using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.Exceptions
{
	public class LoginFailedException : Exception
	{
        public LoginFailedException() : base("Username or password was incorrect. Please try again.") { }
    }
}
