using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp2.Data;
using webapp2.Entity;
using webapp2.Data; // add this

namespace webapp2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public List<Slide> HomePageSlides { get; set; }
        public void OnGet()
        {
            HomePageSlides = _context.Slide
                                .Where(a=> a.Active)
                                .OrderBy(a => a.Seq)
                                .Take(10)
                                .ToList();
        }
    }
}
