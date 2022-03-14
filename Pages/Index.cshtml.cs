using Assignment2022_NCC.Api;
using Assignment2022_NCC.Api.Types;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment2022_NCC.Pages
{
    public class IndexModel : PageModel
    {
        private static IBasicCache _cache;
        private static INHSApiClient _apiClient;

        public CommonHealthQuestionsApiResonse? ApiResponse;

        static IndexModel()
        {
            _cache = new BasicCache();
            _apiClient = new NHSApiClient();
        }

        public void OnGet()
        {
            if(_cache.HasValue() is false)
            {
                var apiResponse = _apiClient.GetCommonHealthQuestions();
                if (apiResponse is not null)
                    _cache.Update(apiResponse);
            }

            ApiResponse = _cache.Read();
        }
    }
}