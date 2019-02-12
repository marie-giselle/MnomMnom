using System.ComponentModel.DataAnnotations;

namespace Mnom_Mnom.Models
{
	public class Register
	{
		[Required(ErrorMessage = "Не указан логин")]
		public string Name;

		[Required(ErrorMessage ="Не указан Email")]
		public string Email { get; set; }

		[DataType(DataType.PhoneNumber)]
		public string TelNumber { get; set; }

		[Required(ErrorMessage = "Не указан пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		public string ConfirmPassword { get; set; }
	}
}
