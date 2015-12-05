using System.ComponentModel.DataAnnotations;

namespace TShirtVoter.Models
{

    public class ContestEntry {
		[Required(ErrorMessage = "Please enter your email address")] 
 		[DataType(DataType.EmailAddress)]
 		[Display(Name = "Email Address")]
 		[MaxLength(50)]
 		[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
		public string Email { get; set; }
		 
		[Required]
		[RegularExpressionAttribute("[a-zA-Z.0-9 ]*")]
		public string Photo { get; set; }

		[Required(ErrorMessage = "Please Enter A Valid EWU StudentID")]
		[RegularExpressionAttribute("[0-9]{8}", ErrorMessage = "Please Enter A Valid Student Id")]
		[Display(Name = "Eastern Student Id")]
		public string StudentId { get; set; }
		
		[Required(ErrorMessage = "Only Letters Are Allowed")]
		[RegularExpressionAttribute("[a-zA-Z ]*", ErrorMessage = "Only Letters Are Allowed")]
		[Display(Name = "Name")]
		public string Name { get; set; }
		
		[Display(Name = "Design Description")]
		[RegularExpressionAttribute("[a-zA-Z.0-9? ]*", ErrorMessage = "Please Enter A Description Containing . ? And Alphanumeric Characters")]
		public string Description { get; set; }
		
		
	}
}