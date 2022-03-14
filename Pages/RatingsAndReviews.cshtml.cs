using Assignment2022_NCC.Api;
using Assignment2022_NCC.Api.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment2022_NCC.Pages
{
    public class RatingsAndReviewsModel : PageModel
    {
        private static IBasicCache<RatingsAndReviewsApiResponse> _cache;
        private static INHSApiClient _apiClient;

        public RatingsAndReviewsApiResponse? ApiResponse;

        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        static RatingsAndReviewsModel()
        {
            _cache = new BasicCache<RatingsAndReviewsApiResponse>();
            _apiClient = new NHSApiClient();
        }

        /*
         * Method: OnPostSearch()
         * Called when the input 'submit' with asp-page-handler 'Search' is pressed
         * This method calls off to the NHS API to get all comments for an organisation by odsCode 
         * the odsCode is bound to a property called 'SearchValue'
         */
        public void OnPostSearch()
        {
            var apiResponse = _apiClient.GetRatingsAndReviews(new RatingsAndReviewsApiRequest
            {
                odsCode = SearchValue
            });
            if (apiResponse is not null)
                _cache.Update(apiResponse);

            ApiResponse = _cache.Read();
        }

        /*
         * Method: OnGet()
         * Called when the page is loaded or refreshed
         * This method calls off to the NHS API to get all comments for an organisation by a hard-coded odsCode 
         * so that there are comments available to read immediately upon load
         */
        public void OnGet()
        {
            if (_cache.HasValue() is false)
            {
                var apiResponse = _apiClient.GetRatingsAndReviews(new RatingsAndReviewsApiRequest
                {
                    odsCode = "RR8"
                });
                if (apiResponse is not null)
                    _cache.Update(apiResponse);
            }

            ApiResponse = _cache.Read();
        }
    }
}
