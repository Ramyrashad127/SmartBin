using Microsoft.EntityFrameworkCore;
using SmartBin.Models;
using SmartBin.ModelViews;

namespace SmartBin.Services
{
    public interface ISurroundingWasteService
    {
        public Task<SurroundingWasteResultMV> GetLastStateAsync(int BinId, AppUser user);
        public string AddSurroundingWasteAsync(SurroundingWasteInsertMV waste, string token);
    }
    public class SurroundingWasteService : ISurroundingWasteService
    {
        private readonly AppDbContext _context;
        public SurroundingWasteService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SurroundingWasteResultMV> GetLastStateAsync(int BinId, AppUser user)
        {
            var bin = await _context.Bins.FirstOrDefaultAsync(b => b.BinId == BinId && user.Id == b.UserId);
            if (bin == null)
                return null;
            var LastState = await _context.SurroundingWastes.Where(s => s.BinId == BinId).OrderByDescending(s => s.Timestamp).FirstOrDefaultAsync();
            if (LastState == null)
                return null;
            var result = new SurroundingWasteResultMV
            {
                Id = LastState.Id,
                WasteLevel = LastState.WasteLevel,
                ImageUrl = LastState.ImageUrl,
                DetectedObjectsCount = LastState.DetectedObjectsCount,
                AiConfidencePercentage = LastState.AiConfidencePercentage,
                Timestamp = LastState.Timestamp
            };
            return result;
        }

        public string AddSurroundingWasteAsync(SurroundingWasteInsertMV waste, string token)
        {
            var bin = _context.Bins.FirstOrDefault(b => b.IdentificationToken == token);
            if (bin == null)
                return "Bin not found";
            // Save the image and get the URL
            //var aiResult = AiAnalyse();
            return "Not implemented yet";
        }
        //public async Task<(float AiConfidencePercentage, int DetectedObjectsCoun)> AiAnalyse(Stream imageStream)
        //{

        //}
    }
}
