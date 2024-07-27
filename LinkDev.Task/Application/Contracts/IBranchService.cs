using LinkDev.Task.Application.DTO;

namespace LinkDev.Task.Application.Contracts
{
    public interface IBranchService
    {
        Task<IReadOnlyList<BranchGetDto>> GetBranchesAsync(BranchesFilterParameter branchesFilter);
        Task<BranchGetDto> AddBranchAsync(BranchPostDto branch);
        Task<bool> DeleteBranchAsync(Guid branchId);
    }
}
