using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Printing;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.MVC.Identity.Interfaces;
using TicketSalesSystem.MVC.Identity.Models;

namespace TicketSalesSystem.MVC.Identity.Controllers
{
	public class TicketController : Controller
	{
		private readonly ILogger<TicketController> _logger;
		private readonly ITicketService _ticketService;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ICurrentUserService _currentUserService;
		public TicketController(ILogger<TicketController> logger, ITicketService ticketService,
			UserManager<IdentityUser> userManager, ICurrentUserService currentUserService)
		{
			_logger = logger;
			_ticketService = ticketService;
			_userManager = userManager;
			_currentUserService = currentUserService;
		}

		public async Task<IActionResult> Index()
		{
			var id = _currentUserService.UserId;
			var res = await _ticketService.GetByUserIdAsync(id);

			return View(res);
		}

		[HttpPost]
		public async Task<IActionResult> ThankYou(TicketDTO ticket)
		{
			var id = _currentUserService.UserId;
			ticket.UserId = id;
			var res = await _ticketService.CreateAsync(ticket);

			return View();
		}

		[HttpDelete]
		public async Task<IActionResult> CancelTicket(TicketDTO ticket)
		{
			var res = await _ticketService.DeleteAsync(ticket);

			return Ok();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}