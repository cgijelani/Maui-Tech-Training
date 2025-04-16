using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.Data_Models
{
    [Table("UserCredentials")]
	public class User
	{
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
		[Column("Username")]
		public string Username { get; set; }
		[Column("Password")]
		public string Password { get; set; } //In real app I would store as plain text.
    }
}
