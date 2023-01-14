using System.ComponentModel.DataAnnotations;

namespace AspNetNewsAgregatorMvcApp.Models
{
    public class ArticleModel
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        //[StringLength(50, MinimumLength = 15)]
        public string? Title { get; set; }

        //[Required(ErrorMessage = "Title Confirmation must be the same with Title")]
        //[Compare("Title")]
        //public string? TitleConfirmation { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public string? ShortSummary { get; set; }

        [Required]
        public string? Text { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
