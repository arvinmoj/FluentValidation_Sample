namespace Server.Controllers
{
	[Microsoft.AspNetCore.Mvc.ApiController]
	[Microsoft.AspNetCore.Mvc.Route("[controller]")]
	public class SomeController : Microsoft.AspNetCore.Mvc.ControllerBase
	{
		public SomeController() : base()
		{
		}

		[Microsoft.AspNetCore.Mvc.HttpGet]
		public Microsoft.AspNetCore.Mvc.IActionResult Get()
		{
			string message = "Hello, World!";

			return Ok(value: message);
		}

		[Microsoft.AspNetCore.Mvc.HttpPost]
		//[Microsoft.AspNetCore.Mvc.HttpPost(template: "checkvalidation")]
		public Microsoft.AspNetCore.Mvc.IActionResult
			CheckValidation([Microsoft.AspNetCore.Mvc.FromBody] Models.User user)
		{
			string message =
				$"Hello, { user.FullName }!";

			return Ok(value: message);
		}
	}
}
