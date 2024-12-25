using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ProcessingErrorsViaConveyorBelt.Controllers
{
	public class ProcessingErrors : Controller
	{
		public IActionResult Processing()
		{
			return View();
		}
	}
}