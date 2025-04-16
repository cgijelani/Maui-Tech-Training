using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.Exceptions
{
	public class UsernameTakenException : Exception
	{
        public UsernameTakenException() : base("Username is taken. Please try a different username.") { }
    }
}
