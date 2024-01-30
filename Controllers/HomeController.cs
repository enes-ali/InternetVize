using MessagingApp.Models;
using MessagingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;


namespace MessagingApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            /*var messages = _context.Messages
                .Where(message => message.ReciverId.Equals(userId))
                .OrderBy(m => m.sentAt)
                .Include(m => m.SentBy)
                .GroupBy(m => m.SentById)
                .Select(group => new { sentBy = group.Key })
                .ToList();*/

            var messages = _context.Messages
                .Where(message => message.ReciverId.Equals(userId) || message.SentById.Equals(userId))
                    .Include(m => m.SentBy)
                    .OrderBy(m => m.sentAt)
                    .Select(msg => new Message() { 
                        Body = msg.Body,
                        SentBy = msg.SentBy,
                    })
                    .ToList();

            Console.WriteLine(messages);

            ViewData["username"] = userId;
            ViewData["messages"] = messages;

            return View(messages);
        }

        public IActionResult SendMessage()
        {
            var users = _context.Users.Select(user => new User()
            {
                Name = user.Name,
                Id = user.Id,
            }).ToList();

            ViewData["users"] = users;

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _context.Messages.Add(new Message() { 
                SentById = userId,
                Body = model.Message,
                ReciverId = model.ReceiverId,
                sentAt = DateTime.Now,
            });
            var res = await _context.SaveChangesAsync();

            if(res != 0)
            {
                return RedirectToAction("Index");
            }

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
