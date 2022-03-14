using Assignment2022_NCC.Api;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment2022_NCC.Pages
{
    public class IndexModel : PageModel
    {
        private static IBasicCache _cache;
        private static INHSApiClient _apiClient;

        static IndexModel()
        {
            _cache = new BasicCache();
            _apiClient = new NHSApiClient();
        }

        public void OnGet()
        {
            var response = _apiClient.GetCommonHealthQuestions();
        }
    }
}