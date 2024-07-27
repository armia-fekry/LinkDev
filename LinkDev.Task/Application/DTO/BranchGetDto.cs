namespace LinkDev.Task.Application.DTO
{
    public record BranchGetDto(Guid branchId
        , string title,
        string openingHour,
        string closingHour,
        string mangerName)
    {
    }
}
