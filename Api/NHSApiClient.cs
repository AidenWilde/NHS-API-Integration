using Assignment2022_NCC.Api.Types;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Web;

namespace Assignment2022_NCC.Api
{
    public interface INHSApiClient
    {
        public CommonHealthQuestionsApiResonse? GetCommonHealthQuestions();
        public RatingsAndReviewsApiResponse? GetRatingsAndReviews(RatingsAndReviewsApiRequest request);
    }

    public struct NHSApiUrls
    {
        public const string CommonHealthQuestionsApiBaseUrl = "https://api.nhs.uk/common-health-questions";
        public const string RatingsAndReviewsApiBaseUrl = "https://api.nhs.uk/comments";
        public const string RatingsAndReviewsCommentsApiUrl = "https://api.nhs.uk/comments/Comments";
    }

    public class NHSApiClient : INHSApiClient
    {
        private HttpClient _httpClient;

        public NHSApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("subscription-key", Settings.ApiKey);
        }

        public CommonHealthQuestionsApiResonse? GetCommonHealthQuestions()
        {
            try
            {
                return HttpGetAsync<CommonHealthQuestionsApiResonse>(NHSApiUrls.CommonHealthQuestionsApiBaseUrl);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public RatingsAndReviewsApiResponse? GetRatingsAndReviews(RatingsAndReviewsApiRequest request)
        {
            if (request.IsValidRequest() is false)
                return null;

            try
            {
                var queryParameters = BuildQueryParamtersString(request);
                return HttpGetAsync<RatingsAndReviewsApiResponse>($"{NHSApiUrls.RatingsAndReviewsCommentsApiUrl}?{queryParameters}");
            }
            catch (Exception)
            {
                return null;
            }
        }

        /*
         * Method: BuildQueryParamtersString()
         * Generates formatted query parameters for a Http GET request
         */
        private string BuildQueryParamtersString(RatingsAndReviewsApiRequest request)
        {
            var queryParamters = HttpUtility.ParseQueryString(string.Empty);
            if (request.odsCode is not null)
                queryParamters["odsCode"] = request.odsCode;

            if (request.orgType is not null)
                queryParamters["orgType"] = request.orgType;

            return queryParamters.ToString();
        }

        /*
         * Method: HttpGetAsync<T>()
         * Calls a [GET] HTTP resource to retrieve data and deserializes it into the supplied object T
         */
        private T HttpGetAsync<T>(string url) where T : new()
        {
            T response = new T();
            var rawResponse = _httpClient.GetAsync(url)
                    .ContinueWith((rawResponse) =>
                    {
                        var asyncString = rawResponse.Result.Content.ReadAsStringAsync();
                        asyncString.Wait();
                        response = JsonConvert.DeserializeObject<T>(asyncString.Result);
                    });

            rawResponse.Wait();
            return response;
        }
    }
}
