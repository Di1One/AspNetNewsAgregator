using System.ComponentModel.DataAnnotations;
using AspNetNewsAgregator.Core;
using Microsoft.AspNetCore.Mvc;

namespace AspNetNewsAgregatorMvcApp.Models
{
    public class CreateSourceModel
    {
        //[Remote("url")] -> create request on server and will be wait answer
        public string Name { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }
        public SourceType SourceType { get; set; }
    }
}