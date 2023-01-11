using AspNetNewsAgregator.Business.ServicesImplementations;
using AspNetNewsAgregator.Core;
using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregatorMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> IndexAsync(int page)
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
                    return View("NoArtilces");
               }
            }
            catch (Exception ex)
            {
                //logger
                throw new Exception();
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {


            return Ok();
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
