using System.ComponentModel.DataAnnotations;

namespace LinkDev.Task.Application.DTO
{
    public class BranchPostDto
    {
        public Guid BranchId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^([01]\d|2[0-3]):([03]0|00)$", ErrorMessage = "Invalid Opening Hour")]
        public string OpeningHour { get; set; }

        [Required]
        [RegularExpression(@"^([01]\d|2[0-3]):([03]0|00)$", ErrorMessage = "Invalid Closing Hour")]
        public string ClosingHour { get; set; }

        [Required]
        public string ManagerName { get; set; }
    }
}
