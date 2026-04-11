using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBin.Models;
using SmartBin.ModelViews;
using SmartBin.Services;

namespace SmartBin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinSectionController : ControllerBase
    {
        private readonly IBinSectionService _binSectionService;
        public BinSectionController(IBinSectionService binSectionService)
        {
            _binSectionService = binSectionService;
        }

        [HttpPut("update")]
        public async Task<ActionResult<BinSectionMV>> UpdateBinSection(BinSectionMV binSection, [FromHeader(Name = "Token")] string token)
        {
            var updatedSection = await _binSectionService.UpdateBinSection(binSection, token);
            if (updatedSection == null) return NotFound();
            return Ok(updatedSection);
        }
        [HttpGet("Bin/{Id}")]
        [Authorize]
        public async Task<ActionResult<List<BinSectionMV>>> GetAllBinSections([FromRoute] int Id)
        {
            var sections = await _binSectionService.GetAllBinSections(Id);
            if (sections == null) return NotFound();
            return Ok(sections);

        }
    }
}
