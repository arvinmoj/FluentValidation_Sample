using System.Linq;
using FluentValidation;

namespace Server.Validators
{
	public class UserValidator : FluentValidation.AbstractValidator<Models.User>
	{
		/// <summary>
		/// https://localhost:5001/some
		/// https://localhost:5001/some/checkvalidation
		/// </summary>
		public UserValidator() : base()
		{
			// NotNull() -> Extension Method -> using FluentValidation;

			// Step (1)

			//RuleFor(current => current.Username).NotNull();
			//RuleFor(current => current.Password).NotNull();
			//RuleFor(current => current.FullName).NotNull();

			// Step (2)

			RuleFor(current => current.Username)
				.NotNull()
				.WithErrorCode(errorCode: "10")
				.WithMessage(errorMessage: "You did not specify username (1)!")

				.NotEmpty() // New
				.WithErrorCode(errorCode: "11")
				.WithMessage(errorMessage: "You did not specify username (2)!")
				;

			// Check With Postman:
			// -----
			// { "Username": null }
			// { "Username": "" }
			// { "Username": "Dariush" }

			// Step (3)

			//RuleFor(current => current.Password)
			//	.Cascade(cascadeMode: CascadeMode.Stop) // New

			//	.NotNull()
			//	.WithMessage(errorMessage: "You did not specify {PropertyName} (1)!") // New

			//	.NotEmpty()
			//	.WithMessage(errorMessage: "You did not specify {PropertyName} (2)!") // New
			//	;

			// Check With Postman:
			// -----
			// { "Password": null }
			// { "Password": "" }
			// { "Password": "12345" }

			// Step (4)

			//RuleFor(current => current.FullName)
			//	.NotNull()
			//	.WithName(overridePropertyName: "Full Name") // New
			//	.WithMessage(errorMessage: "You did not specify {PropertyName} (1)!") // New

			//	.NotEmpty()
			//	.WithMessage(errorMessage: "You did not specify {PropertyName} (2)!") // New

			//	.Must(predicate: ContainsJustLetters) // New
			//	.WithMessage(errorMessage: "All characters of {PropertyName} should be letter!") // New
			//	;

			// Check With Postman:
			// -----
			// { "FullName": null }
			// { "FullName": "" }
			// { "FullName": "Dariush 12345" }
			// { "FullName": "Dariush Tasdighi" }
		}

		private bool ContainsJustLetters(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return true;
			}

			value =
				value.Replace(" ", string.Empty);

			// All -> Is Extension Method -> using System.Linq;
			bool result =
				value.All(char.IsLetter);

			return result;
		}
	}
}
