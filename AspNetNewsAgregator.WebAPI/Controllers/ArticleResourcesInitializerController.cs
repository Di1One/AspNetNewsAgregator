using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregator.WebAPI.Models.Requests;
using AspNetNewsAgregator.WebAPI.Models.Responces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetNewsAgregator.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleResourcesInitializerController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly ISourceService _sourceService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleService"></param>
        /// <param name="sourceService"></param>
        /// <param name="mapper"></param>
        public ArticleResourcesInitializerController(IArticleService articleService, 
            ISourceService sourceService, 
            IMapper mapper)
        {
            _articleService = articleService;
            _sourceService = sourceService;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddArticles([FromBody] AddOrUpdateArticleRequestModel? model)
        {
            // not good practice
            try
            {
                var sources = await _sourceService.GetSourcesAsync();

                foreach (var source in sources)
                {
                    await _articleService.GetAllArticleDataFromRssAsync(source.Id, source.RssUrl);
                    await _articleService.AddArticleTextToArticlesAsync();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel { Message = ex.Message });
            }
        }
    }
}
