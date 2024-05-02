using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string LastName { get; set; }
   
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Address { get; set; }
       
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9 *#+]+$")]
        public string PhoneNumber { get; set; }
    }
}
