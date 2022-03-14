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
