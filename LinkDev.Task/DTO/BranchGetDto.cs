namespace LinkDev.Task.DTO
{
    public record BranchGetDto (Guid branchId 
        , string title ,
        TimeSpan openingHour ,
        TimeSpan closingHour,
        string mangerName)
    {
    }
}
