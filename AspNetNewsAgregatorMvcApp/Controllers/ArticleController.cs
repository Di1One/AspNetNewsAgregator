using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregatorMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AspNetNewsAgregatorMvcApp.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private int _pageSize = 5;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IActionResult> Index(int page)
        {
            try
            {
                var artilces = await _articleService
                    .GetArticlesByPageNumberAndPageSizeAsync(page, _pageSize);

               if (artilces.Any())
               {
                    return View(artilces);
               }
               else
               {
                    throw new ArgumentException(nameof(page));
               }
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine} {ex.StackTrace}");
                return BadRequest();
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var dto = await _articleService.GetArticleByIdAsync(id);
            if (dto != null)
            {
                //ViewData["model"] = dto;
                //ViewBag.Model = dto;

                return View(dto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditArticle()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TestModel model)
        {
            return Ok();
        }
    }
}
