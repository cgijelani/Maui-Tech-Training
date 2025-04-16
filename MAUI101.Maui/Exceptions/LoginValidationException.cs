using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.Exceptions
{
	public class LoginValidationException : Exception
	{
        public LoginValidationException() : base("Username and password is required.") { }
    }
}
