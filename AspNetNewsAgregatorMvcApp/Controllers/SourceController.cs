using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregatorMvcApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetNewsAgregatorMvcApp.Controllers
{
    public class SourceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISourceService _sourceService;

        public SourceController(IMapper mapper, ISourceService sourceService)
        {
            _mapper = mapper;
            _sourceService = sourceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sources = (await _sourceService.GetSourcesAsync())
                .Select(dto => _mapper.Map<SourceModel>(dto))
                .ToList();

            return View(sources);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSourceModel model)
        {
            return View();
        }
    }
}
