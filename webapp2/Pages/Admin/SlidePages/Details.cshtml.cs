using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webapp2.Entity;
using webapp2.Data;

namespace webapp2.Pages.SlidePages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Slide Slide { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var slide = await _context.Slide.FirstOrDefaultAsync(m => m.Id == id);
        if (slide is null)
        {
            return NotFound();
        }
        else
        {
            Slide = slide;
        }

        return Page();
    }
}
