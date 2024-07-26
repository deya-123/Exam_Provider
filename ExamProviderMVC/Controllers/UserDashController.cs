using AutoMapper;
using ExamProviderMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Linq;

namespace ExamProviderMVC.Controllers
{

    public class UserDashController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        public UserDashController( IMapper mapper, IToastNotification notyf)
        {
            _mapper = mapper;
            _toastNotification = notyf;
        }
        public IActionResult Index()
        {
            return RedirectToAction("StatisticsPage");
        }
        public async Task<IActionResult> UsersPage()
        {
            return View(/*await _context.Users.ToListAsync()*/);
        }
        public IActionResult SchedulerExamPage() => View();
        public IActionResult HomeInfoPage() => View();
        public IActionResult AboutPage() => View();
        public IActionResult TestimonialsPage() => View();
        public IActionResult ExamsPage() => View();
        public IActionResult ExamsReservationsPage() => View();

        public IActionResult ContactsPage() => View();
      
      
        public async Task<IActionResult> Profile()
        {
            //ViewBag.Countries = _context.Countries.ToList();
            //var user = await _context.Users.FirstOrDefaultAsync(e => e.UserId == HttpContext.Session.GetInt32("userId"));

            //if (user != null)
            //{
            //    return View(_mapper.Map<User, UserProfileViewModel>(user));

            //}
            //return View(new UserProfileViewModel());
            return View(new UserProfileViewModel());
        }
    }
}
