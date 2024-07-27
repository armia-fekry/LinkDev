using LinkDev.Task.Application.Contracts;
using LinkDev.Task.Application.DTO;
using LinkDev.Task.Infrastructure.Context;
using LinkDev.Task.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Task.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BranchService(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext  =applicationDbContext;
        }
        public async Task<BranchGetDto> AddBranchAsync(BranchPostDto branchDto)
        {
            try
            {
                var model = GetBranchModel(branchDto);
                if (TimeSpan.TryParse(branchDto.OpeningHour, out var openingHour) &&
                    TimeSpan.TryParse(branchDto.ClosingHour, out var closingHour))
                {
                    model.OpeningHour = openingHour;
                    model.ClosingHour = closingHour;
                }
                await _applicationDbContext.Branches.AddAsync(model);
                await _applicationDbContext.SaveChangesAsync();
                return await System.Threading.Tasks.Task.FromResult(GetBranchDto(branchDto));
            }
            catch (Exception ex)
            {
                throw;
            }

            
            Branch GetBranchModel(BranchPostDto branch) =>
                new Branch 
                {
                    BranchId = Guid.NewGuid(),
                    ManagerName = branch.ManagerName,
                    Title = branch.Title
                };
            
        }

        private BranchGetDto GetBranchDto(BranchPostDto branchDto) =>
            new BranchGetDto(branchDto.BranchId,
                branchDto.Title,
                branchDto.OpeningHour,
                branchDto.ClosingHour,
                branchDto.ManagerName);
 
            
        public async Task<bool> DeleteBranchAsync(Guid branchId)
        {
            try
            {
                if (branchId == default || branchId == Guid.Empty)
                    throw new ArgumentNullException(nameof(branchId));

                var branch = await _applicationDbContext.Branches.FindAsync(branchId);
                if (branch is null)
                    throw new Exception($"Branch With Id {branchId} Not Found");

                _applicationDbContext.Branches.Remove(branch);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public async Task<IReadOnlyList<BranchGetDto>> GetBranchesAsync(BranchesFilterParameter branchesFilter)
        {
            var branchesQuery = _applicationDbContext.Branches.AsNoTracking();
            if (branchesFilter is { pageNumber:> 0 } && branchesFilter is { pageSize :> 1} )
                branchesQuery.Skip((branchesFilter.pageNumber - 1) * branchesFilter.pageSize)
                    .Take(branchesFilter.pageSize);

            return await branchesQuery.Select(res=> 
                            new BranchGetDto(
                                res.BranchId,
                                res.Title,
                                res.OpeningHour.ToString(),
                                res.ClosingHour.ToString(),
                                res.ManagerName))
                             .ToListAsync();
                            

        }
    }
}
