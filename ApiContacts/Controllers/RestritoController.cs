using System;
using Microsoft.AspNetCore.Mvc;

namespace ApiContacts.Controllers
{
	public class RestritoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

