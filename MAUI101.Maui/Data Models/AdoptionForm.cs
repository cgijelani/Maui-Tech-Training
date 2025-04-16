using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.Data_Models
{
	[Table("AdoptionForms")]
	public class AdoptionForm
	{
		[PrimaryKey]
		[AutoIncrement]
		[Column("Id")]
		public int Id { get; set; }

		[Column("ImageId")]
		public string ImageId { get; set; }

		[Column("UserName")]
		public string UserName { get; set; }

		[Column("FirstName")]
		public string FirstName { get; set; }

		[Column("MiddleName")]
		public string MiddleName { get; set; }

		[Column("LastName")]
		public string LastName { get; set; }

		[Column("DateOfBirth")]
		public DateTime DateOfBirth { get; set; }

		[Column("Street")]
		public string Street { get; set; }

		[Column("City")]
		public string City { get; set; }

		[Column("State")]
		public string State { get; set; }

		[Column("PhoneNumber")]
		public string PhoneNumber { get; set; }

		[Column("Email")]
		public string Email { get; set; }

		[Column("PetName")]
		public string PetName { get; set; }
	}
}
