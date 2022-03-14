using Assignment2022_NCC.Api;
using Assignment2022_NCC.Api.Types;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment2022_NCC.Pages
{
    public class IndexModel : PageModel
    {
        private static IBasicCache<CommonHealthQuestionsApiResonse> _cache;
        private static INHSApiClient _apiClient;

        public CommonHealthQuestionsApiResonse? ApiResponse;

        static IndexModel()
        {
            _cache = new BasicCache<CommonHealthQuestionsApiResonse>();
            _apiClient = new NHSApiClient();
        }

        /*
         * Method: OnGet()
         * Called when the page is loaded or refreshed
         * This method calls off to the NHS API to get all common health questions
         * so that there is viewable content available to read immediately upon load
         */
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