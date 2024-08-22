using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SwapnaliTask.Models
{
	public class Entry
	{
		[Key]
		public int EntryID { get; set; }

		[ForeignKey("User")]
		public int UserID { get; set; }
		public virtual User User { get; set; }

		[Required]
		[StringLength(100)]
		public string Account { get; set; }

		[Required]
		[StringLength(255)]
		public string Narration { get; set; }

		[Required]
		[StringLength(10)]
		public string Currency { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? Credit { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? Debit { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime CreatedAt { get; set; }

		[Column(TypeName = "bit")]
		public bool IsDeleted { get; set; }
	}
}
