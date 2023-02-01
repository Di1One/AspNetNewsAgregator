using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.WebAPI.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetNewsAgregator.WebAPI.Controllers
{
    /// <summary>
    /// Controller for work with articles
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private static List<ArticleDto> Articles = new List<ArticleDto>()
        {
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Text = "Some text 1",
                Title = "Article #1",
                Category = "Some category 1"
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Text = "Some text 2",
                Title = "Article #2",
                Category = "Some category 2"
            },
        };

        /// <summary>
        /// Get article from storage with specified id 
        /// </summary>
        /// <param name="id">Id of article</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public IActionResult GetArticleById(Guid id)
        {
            var article = Articles.FirstOrDefault(dto => dto.Id.Equals(id));

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpGet]
        public IActionResult GetArticles([FromQuery]GetArticlesRequestModel? model)
        {
            IEnumerable<ArticleDto> articles = Articles;

            if (!string.IsNullOrEmpty(model?.Name))
            {
                articles = articles.Where(dto => dto.Title.Equals(model.Name));
            }

            if (!string.IsNullOrEmpty(model?.Category))
            {
                articles = articles.Where(dto => dto.Title.Equals(model.Category));
            }

            return Ok(articles.ToList());
        }

        [HttpPost]
        public IActionResult AddArticles([FromBody]AddOrUpdateArticleRequestModel? model)
        {
            if (model != null)
            {
                var dto = new ArticleDto()
                {
                    Id = Guid.NewGuid(),
                    Text = "Some text add manually",
                    Category = "Some category add manually",
                    ShortSummary = "Some short summary add manually",
                    Title = "New Article",
                    PublicationDate = DateTime.Now
                };

                Articles.Add(dto);

                return CreatedAtAction(nameof(GetArticleById), new {id = dto.Id}, dto);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateArticles(Guid id, [FromBody] AddOrUpdateArticleRequestModel? model)
        {
            if (model != null)
            {
                var oldValue = Articles.FirstOrDefault(dto => dto.Id.Equals(id));

                if (oldValue == null)
                {
                    return NotFound();
                }

                var newValue = new ArticleDto()
                {
                    Id = oldValue.Id,
                    Text = model.Text,
                    Category = model.Category,
                    ShortSummary = model.ShortSummary,
                    Title = model.Title,
                    PublicationDate = DateTime.Now
                };

                Articles.Remove(oldValue);
                Articles.Add(newValue);

                return Ok();
            }

            return BadRequest();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateArticles(Guid id, [FromBody] PatchRequestModel? model)
        {
            if (model != null)
            {
                var oldValue = Articles.FirstOrDefault(dto => dto.Id.Equals(id));

                if (oldValue == null)
                {
                    return NotFound();
                }

                //todo add patch implementation (change only fields from request

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult UpdateArticles(Guid id)
        {
            var oldValue = Articles.FirstOrDefault(dto => dto.Id.Equals(id));

            if (oldValue == null)
            {
                return NotFound();
            }

            Articles.Remove(oldValue);

            return Ok();
        }
    }
}
