using System.ComponentModel.DataAnnotations;

namespace ColdBananaUmbraco.Models
{
	public class Contact
    {
		[Required]
		[Display(Name = "First Name:")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name:")]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = "Email Address:")]
		public string EmailAddress { get; set; }

		[Required]
		[Display(Name = "Phone Number:")]
		public string PhoneNumber { get; set; }

		[Required]
		[Display(Name = "Message:")]
		public string Message { get; set; }
	}
}
