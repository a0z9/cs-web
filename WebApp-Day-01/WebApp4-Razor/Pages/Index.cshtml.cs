using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp4_Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string data { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            data = $"Model Test: {GetHashCode():x}";
        }

        public void OnGet()
        {

        }
    }
}
