using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.WebAPI.Models.Requests;
using AspNetNewsAgregator.WebAPI.Models.Responces;
using AutoMapper;
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
        private readonly IArticleService _articleService;
        private readonly ISourceService _sourceService;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleService articleService, 
            ISourceService sourceService,
            IMapper mapper)
        {
            _articleService = articleService;
            _sourceService = sourceService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get article from storage with specified id 
        /// </summary>
        /// <param name="id">Id of article</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArticleById(Guid id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        /// <summary>
        /// Get articles by article name substring and source Id
        /// </summary>
        /// <param name="model">Contains article name substring and source id</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ArticleDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetArticles([FromQuery]GetArticlesRequestModel? model)
        {
            IEnumerable<ArticleDto> articles = await _articleService
                .GetArticlesByNameAndSourcesAsync(model?.Name, model?.SourceId);

           

            return Ok(articles.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddArticles([FromBody]AddOrUpdateArticleRequestModel? model)
        {
            try
            {
                var sources = await _sourceService.GetSourcesAsync();

                foreach (var source in sources)
                {
                    await _articleService.GetAllArticleDataFromRssAsync(source.Id, source.RssUrl);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel { Message = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateArticles(Guid id, [FromBody] AddOrUpdateArticleRequestModel? model)
        {
            if (model != null)
            {
                //var oldValue = _articleService..FirstOrDefault(dto => dto.Id.Equals(id));

                //if (oldValue == null)
                //{
                //    return NotFound();
                //}

                //var newValue = new ArticleDto()
                //{
                //    Id = oldValue.Id,
                //    Text = model.Text,
                //    Category = model.Category,
                //    ShortSummary = model.ShortSummary,
                //    Title = model.Title,
                //    PublicationDate = DateTime.Now
                //};

                //Articles.Remove(oldValue);
                //Articles.Add(newValue);

                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateArticles(Guid id, [FromBody] PatchRequestModel? model)
        {
            //if (model != null)
            //{
            //    //var oldValue = Articles.FirstOrDefault(dto => dto.Id.Equals(id));

            //    //if (oldValue == null)
            //    //{
            //    //    return NotFound();
            //    //}

            //    ////todo add patch implementation (change only fields from request

            //    return Ok();
            //}

            return BadRequest();
        }

        /// <summary>
        /// Delete  Article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteArticles(Guid id)
        {
            try
            {
                await _articleService.DeleteArticleAsync(id);

                return Ok();
            }
            catch (ArgumentException ex)
            { 
                return BadRequest(new ErrorModel { Message = ex.Message });
            }
        }
    }
}
