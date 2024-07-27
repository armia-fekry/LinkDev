using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinkDev.Task.Infrastructure.Entities
{
    public class Branch
    {
        [Key]
        public Guid BranchId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeSpan OpeningHour { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeSpan ClosingHour { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string ManagerName { get; set; }


    }
}
