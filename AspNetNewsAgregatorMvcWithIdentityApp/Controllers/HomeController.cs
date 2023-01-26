using AspNetNewsAgregatorMvcWithIdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mime;
using AspNetNewsAgregatorMvcWithIdentityApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspNetNewsAgregatorMvcWithIdentityApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // bad practice just for fast test
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, 
            ApplicationDbContext context)
            //RoleManager<IdentityRole> roleManager, 
            //SignInManager<IdentityUser> signInManager, 
            //UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            //_roleManager = roleManager;
            //_signInManager = signInManager;
            //_userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _context.Users.FirstOrDefaultAsync();



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}