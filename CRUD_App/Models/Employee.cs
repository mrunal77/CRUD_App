using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_CRUD_App.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Designation.")]
        public string Designation { get; set; }

        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address.")]
        [Required(ErrorMessage = "Please Enter Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide Mobile Number.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter valid Mobile Number.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Pin Code")]
        [Display(Name = "Pin Code")]
        [RegularExpression(@"^(\d{6})$", ErrorMessage = "Please enter valid Pin Code.")]
        public string PinCode { get; set; }
    }
}