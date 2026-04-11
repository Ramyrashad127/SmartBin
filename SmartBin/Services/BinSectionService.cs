using SmartBin.ModelViews;
using SmartBin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace SmartBin.Services
{
    public interface IBinSectionService
    {
        public Task<BinSection> CreateBinSection(int BinId, int MaterialId);
        public Task<BinSectionMV> UpdateBinSection(BinSectionMV binSection, string token);
        public Task<List<BinSectionMV>> GetAllBinSections(int BinId);

    }
    public class BinSectionService : IBinSectionService
    {
        private readonly AppDbContext _context;
        public BinSectionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BinSection> CreateBinSection(int BinId, int MaterialId)
        {
            var binSection = new BinSection
            {
                BinId = BinId,
                MaterialId = MaterialId,
                LevelPercentage = 0,
                Weight = 0
            };
            _context.BinSections.Add(binSection);
            await _context.SaveChangesAsync();
            return binSection;
        }

        public async Task<BinSectionMV> UpdateBinSection(BinSectionMV binSection, string token)
        {
            var existingBin = await _context.Bins.FirstOrDefaultAsync(b => b.IdentificationToken == token);
            if (existingBin == null) return null;
            var existingSection = await _context.BinSections.Include(s => s.Material).FirstOrDefaultAsync(s => s.BinId == existingBin.BinId && s.Material.Name == binSection.MaterialName);
            if (existingSection == null) return null;
            existingSection.LevelPercentage = binSection.LevelPercentage;
            existingSection.Weight = binSection.Weight;
            existingSection.LastUpdated = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return new BinSectionMV
            {
                MaterialName = existingSection.Material.Name,
                LevelPercentage = existingSection.LevelPercentage,
                Weight = existingSection.Weight,
            };
        }

        public async Task<List<BinSectionMV>> GetAllBinSections(int BinId)
        {
            var existingBin = await _context.Bins.FirstOrDefaultAsync(b => b.BinId == BinId);
            if (existingBin == null) return null;
            var sections = await _context.BinSections.Where(s => s.BinId == existingBin.BinId).Include(s => s.Material).ToListAsync();
            return sections.Select(s => new BinSectionMV
            {
                MaterialName = s.Material.Name,
                LevelPercentage = s.LevelPercentage,
                Weight = s.Weight,
            }).ToList();
        }
    }
}
