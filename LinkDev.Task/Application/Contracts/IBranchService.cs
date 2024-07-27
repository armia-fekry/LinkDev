using LinkDev.Task.DTO;

namespace LinkDev.Task.Application.Contracts
{
    public interface IBranchService
    {
        Task<IReadOnlyList<BranchGetDto>> GetBranches(BranchesFilterParameter branchesFilter);
        Task<BranchGetDto> AddBranch(BranchPostDto branch);
        Task<bool> DeleteBranch(Guid branchId);
    }
}
