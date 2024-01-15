using System.ComponentModel.DataAnnotations;

namespace UserM.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter Name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
