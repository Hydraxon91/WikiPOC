using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace wiki_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParagraphController : ControllerBase
    {
        private readonly IParagraphRepository _paragraphRepository;

        public ParagraphController(IParagraphRepository paragraphRepository)
        {
            _paragraphRepository = paragraphRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paragraph>> GetParagraph(int id)
        {
            var paragraph = await _paragraphRepository.GetByIdAsync(id);

            if (paragraph == null)
            {
                return NotFound();
            }

            return paragraph;
        }

        [HttpPost]
        public async Task<ActionResult<Paragraph>> CreateParagraph(Paragraph paragraph)
        {
            await _paragraphRepository.CreateAsync(paragraph);
            
            return CreatedAtAction(nameof(GetParagraph), new { id = paragraph.Id }, paragraph);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParagraph(int id)
        {
            await _paragraphRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
