using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetNewsAgregator.Core.DataTransferObjects
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string ShortSummary { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
