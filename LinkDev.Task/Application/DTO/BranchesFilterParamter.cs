namespace LinkDev.Task.Application.DTO
{
    public record BranchesFilterParameter(
        int pageSize,
        int pageNumber = 1
        )
    {
    }
}
