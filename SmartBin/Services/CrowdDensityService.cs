using SmartBin.Models;
using SmartBin.ModelViews;
using Microsoft.EntityFrameworkCore;
namespace SmartBin.Services
{
    public interface ICrowdDensityService
    {
        public Task<CrowdDensityResultMV> GetLastStateAsync(int BinId, AppUser user);
        public string AddCrowdDensityAsync(CrowdDensityInsertMV crowdDensity, string token);
    }
    public class CrowdDensityService : ICrowdDensityService
    {
        private readonly AppDbContext _context;
        public CrowdDensityService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CrowdDensityResultMV> GetLastStateAsync(int BinId, AppUser user)
        {
            var bin = await _context.Bins.FirstOrDefaultAsync(b => b.BinId == BinId && user.Id == b.UserId);
            if (bin == null)
                return null;
            var LastState = await _context.CrowdDensities.Where(s => s.BinId == BinId).OrderByDescending(s => s.Timestamp).FirstOrDefaultAsync();
            if (LastState == null)
                return null;
            var result = new CrowdDensityResultMV
            {
                DensityLevel = LastState.DensityLevel,
                PeopleCount = LastState.PeopleCount,
                AiConfidencePercentage = LastState.AiConfidencePercentage,
                Timestamp = LastState.Timestamp
            };
            return result;
        }
        public string AddCrowdDensityAsync(CrowdDensityInsertMV crowdDensity, string token)
        {
            var bin = _context.Bins.FirstOrDefault(b => b.IdentificationToken == token);
            if (bin == null)
                return "Bin not found";
            // Save the image and get the URL
            //var aiResult = AiAnalyse();
            return "Not implemented yet";
        }
    }
}
