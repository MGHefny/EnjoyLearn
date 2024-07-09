using System.ComponentModel.DataAnnotations;
//model value for instractours
namespace learnApp.Models
{
    public class TrainerModel
    {
        public int id { get; set; }
        [Required]
        public string instractor_name { get; set; }
        [StringLength(250, MinimumLength =10)]
        public string description { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="write Email like example@gmail.com")]
        public string email { get; set; }
        [Url(ErrorMessage = "please, enter correct url!")]
        public string website { get; set; }
        public System.DateTime creation_date { get; set; }
    }
}