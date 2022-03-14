using Assignment2022_NCC.Api.Types;
using Newtonsoft.Json;

namespace Assignment2022_NCC.Api
{
    public interface INHSApiClient
    {
        public CommonHealthQuestionsApiResonse? GetCommonHealthQuestions();
    }

    public class NHSApiClient : INHSApiClient
    {
        private const string CommonHealthQuestionsApiBaseUrl = "https://api.nhs.uk/common-health-questions";
        private const string RatingsAndReviewsApiBaseUrl = "https://api.nhs.uk/comments";

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
                return HttpGetAsync<CommonHealthQuestionsApiResonse>(CommonHealthQuestionsApiBaseUrl);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public RatingsAndReviewsApiResponse? GetRatingsAndReviews(RatingsAndReviewsApiRequest request)
        {
            try
            {
                return HttpGetAsync<RatingsAndReviewsApiResponse>(RatingsAndReviewsApiBaseUrl);
            }
            catch (Exception)
            {
                return null;
            }
        }

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
