using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
   public class Person
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required(ErrorMessage = "firstname is required please")]
        [Display(Name = "FirstName", Prompt = "Enter First Name ")]
        [StringLength(20, ErrorMessage = "firstname  must not be longer than 20 characters")]
        public string FirstName { get; set; }

        
        [Display(Name = "OtherName", Prompt = "Enter Other Name ")]
        [StringLength(20, ErrorMessage = "othername  must not be longer than 20 characters")]
        public string MidleName { get; set; }

        [Required(ErrorMessage = "lastname is required please")]
        [Display(Name = "LastName", Prompt = "Enter last Name ")]
        [StringLength(20, ErrorMessage = "last  must not be longer than 20 characters")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "gender is required please")]
        [Display(Name = "Gender", Prompt = "Enter Gender")]
        [StringLength(6, ErrorMessage = "gender  must not be longer than 20 characters")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "username is required please")]
        [Display(Name = "UserName", Prompt = "Enter User Name ")]
        [StringLength(500, ErrorMessage = "username  must not be longer than 25 characters")]
        public string ContactAddress { get; set; }


        [NotMapped]
        [Display(Name = "Name")]
        public string Name => LastName + " " + FirstName;
    }
}
