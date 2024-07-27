namespace LinkDev.Task.DTO
{
    public record BranchesFilterParameter(
        int pageSize,
        int pageNumber = 1
        )
    {
    }
}
