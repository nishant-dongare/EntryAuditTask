using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SwapnaliTask.Models
{
	public class Audit
	{
		[Key]
		public int AuditID { get; set; }

		[ForeignKey("Entry")]
		public int EntryID { get; set; }

		[Required]
		[StringLength(100)]
		public string TableName { get; set; }

		[Required]
		[StringLength(100)]
		public string FieldName { get; set; }

		[StringLength(255)]
		public string OldValue { get; set; }

		[Required]
		[StringLength(255)]
		public string NewValue { get; set; }

		[Required]
		public DateTime ChangedAt { get; set; }

		[Required]
		[StringLength(50)]
		public string ChangedBy { get; set; }

		// Navigation property to link to the related Entry
		public virtual Entry Entry { get; set; }
	}
}
