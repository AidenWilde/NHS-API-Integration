using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment2022_NCC.Pages
{
    public class IndexModel : PageModel
    {
        private static IBasicCache _cache;

        static IndexModel()
        {
            _cache = new BasicCache();
        }

        public void OnGet()
        {

        }
    }
}