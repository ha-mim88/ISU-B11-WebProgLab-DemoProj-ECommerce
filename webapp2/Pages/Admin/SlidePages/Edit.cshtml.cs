using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webapp2.Entity;
using webapp2.Data;

namespace webapp2.Pages.SlidePages;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
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
        Slide = slide;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        Slide.LastModifiedBy = User.Identity.Name;
        Slide.LastModifiedDate = DateTime.Now;

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Slide).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SlideExists(Slide.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool SlideExists(int id)
    {
        return _context.Slide.Any(e => e.Id == id);
    }
}
