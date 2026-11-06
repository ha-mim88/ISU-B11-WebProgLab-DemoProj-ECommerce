using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webapp2.Entity;
using webapp2.Data;

namespace webapp2.Pages.SlidePages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var slide = await _context.Slide.FindAsync(id);
        if (slide != null)
        {
            Slide = slide;
            _context.Slide.Remove(Slide);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
