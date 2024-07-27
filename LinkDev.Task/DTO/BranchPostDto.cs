using System.ComponentModel.DataAnnotations;

namespace LinkDev.Task.DTO
{
    public class BranchPostDto
    {
        public Guid BranchId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^([01]\d|2[0-3]):([03]0|00)$", ErrorMessage = "Invalid Opening Hour")]
        public TimeSpan OpeningHour { get; set; }

        [Required]
        [RegularExpression(@"^([01]\d|2[0-3]):([03]0|00)$", ErrorMessage = "Invalid Closing Hour")]
        public TimeSpan ClosingHour { get; set; }

        [Required]
        public string ManagerName { get; set; }
    }
}
