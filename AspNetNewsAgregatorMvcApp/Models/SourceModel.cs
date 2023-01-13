using AspNetNewsAgregator.Core;

namespace AspNetNewsAgregatorMvcApp.Models
{
    public class SourceModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public SourceType SourceType { get; set; }
    }
}