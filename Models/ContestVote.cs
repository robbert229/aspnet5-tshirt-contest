using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Metadata.Internal;

namespace TShirtVoter.Models
{
    public class ContestVote
    {
        [Key]
        public int VoteId { get; set; }

        [Required(ErrorMessage = "Please Enter A Valid EWU StudentID")]
        [RegularExpressionAttribute("[0-9]{8}", ErrorMessage = "Please Enter A Valid Student Id")]
        [Display(Name = "Eastern Student Id")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "Only Letters Are Allowed")]
        [RegularExpressionAttribute("[a-zA-Z ]*", ErrorMessage = "Only Letters Are Allowed")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public int EntryId { get; set; }
    }
}
