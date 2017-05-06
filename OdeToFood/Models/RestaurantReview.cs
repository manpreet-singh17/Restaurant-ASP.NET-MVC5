using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{
    public class RestaurantReview
    {
        public int ID { get; set; }

        [Required()]
        [StringLength(1024)]
        public string Body { get; set; }

        [Required]
        [Range(1,10)]
        public int Rating { get; set; }

        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText = "anonymous")]
        public string ReviewerName { get; set; }

        public int RestaurantID { get; set; }

    }
}