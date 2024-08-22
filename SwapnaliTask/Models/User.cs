using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapnaliTask.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserID { get; set; }

		[Required]
		[StringLength(50)]
		public string Username { get; set; }

		[Required]
		[StringLength(255)]
		public string PasswordHash { get; set; }

		[Required]
		[StringLength(100)]
		public string Email { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; }

		public DateTime? LastLogin { get; set; }
	}
}
