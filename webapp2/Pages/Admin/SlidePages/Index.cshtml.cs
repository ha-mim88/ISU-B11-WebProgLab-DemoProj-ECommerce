using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webapp2.Entity;
using webapp2.Data;

namespace webapp2.Pages.SlidePages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Slide> Slide { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Slide = await _context.Slide.ToListAsync();
    }
}
