using AspNetNewsAgregator.Core;

namespace AspNetNewsAgregatorMvcApp.Models
{
    public class CreateSourceModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public SourceType SourceType { get; set; }
    }
}