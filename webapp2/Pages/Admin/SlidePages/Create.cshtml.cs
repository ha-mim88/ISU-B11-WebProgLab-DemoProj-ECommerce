using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webapp2.Entity;
using webapp2.Data;

namespace webapp2.Pages.SlidePages;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Slide Slide { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        Slide.CreatedBy = User.Identity.Name;
        Slide.CreatedDate = DateTime.Now;

        ModelState.Remove("Slide.CreatedBy");
        ModelState.Remove("Slide.CreatedDate");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Slide.Add(Slide);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
