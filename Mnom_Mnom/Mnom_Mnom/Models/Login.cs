using System.ComponentModel.DataAnnotations;

namespace Mnom_Mnom.Models
{
	public class Login
	{
		[Required(ErrorMessage ="Не указан Email или телефон")]
		public string UserKey { get; set; }

		[Required(ErrorMessage ="Не указан пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
