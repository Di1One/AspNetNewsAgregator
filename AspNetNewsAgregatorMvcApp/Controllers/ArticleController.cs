﻿using AspNetNewsAgregator.Core;
using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregatorMvcApp.Filters;
using AspNetNewsAgregatorMvcApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AspNetNewsAgregatorMvcApp.Controllers
{
    [Authorize(Roles = "User")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ISourceService _sourceService;
        private readonly IMapper _mapper;
        private int _pageSize = 5;

        public ArticleController(IArticleService articleService, IMapper mapper, ISourceService sourceService)
        {
            _articleService = articleService;
            _mapper = mapper;
            _sourceService = sourceService;
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

        [TypeFilter(typeof(ArticleCheckerActionFilter))]
        //[ServiceFilter(typeof(ArticleCheckerActionFilter))] -> registred filter in DI
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
        public async Task<IActionResult> Create()
        {
            //var model = new CreateArticleModel();

            //var sources = await _sourceService.GetSourcesAsync(); 

            //model.Sources = sources.Select(dto => new SelectListItem(dto.Name, dto.Id.ToString("G"))).ToList();

            //return View(model);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Title.ToUpperInvariant().Contains("123"))
                    {
                        ModelState.AddModelError("Title", "Article contains 123");
                        return View(model);
                    }

                    model.Id = Guid.NewGuid();
                    model.PublicationDate = DateTime.Now;

                    var dto = _mapper.Map<ArticleDto>(model);

                    await _articleService.CreateArticleAsync(dto);

                    return RedirectToAction("Index", "Article");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id != Guid.Empty)
            {
                var articleDto = await _articleService.GetArticleByIdAsync(id);

                if (articleDto == null)
                {
                    return BadRequest();
                }

                var editModel = _mapper.Map<ArticleModel>(articleDto);

                return View(editModel);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleModel model)
        {
            try
            {
                if (model != null)
                {
                    var dto = _mapper.Map<ArticleDto>(model);

                    await _articleService.UpdateArticleAsync(model.Id, dto);

                    //await _articleService.CreateArticleAsync(dto); 

                    return RedirectToAction("Index", "Article");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok();
        }
    }
}
