using Assignment2022_NCC.Api.Types;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Assignment2022_NCC.Api
{
    public interface INHSApiClient
    {
        public CommonHealthQuestionsApiResonse? GetCommonHealthQuestions();
    }

    public class NHSApiClient : INHSApiClient
    {
        private const string CommonHealthQuestionsApiBaseUrl = "https://api.nhs.uk/common-health-questions";

        private HttpClient _httpClient;

        public NHSApiClient()
        {
            _httpClient = new HttpClient();
        }

        public CommonHealthQuestionsApiResonse? GetCommonHealthQuestions()
        {
            var commonHealthQuestionsApiResponse = new CommonHealthQuestionsApiResonse();
            _httpClient.DefaultRequestHeaders.Add("subscription-key", Settings.ApiKey);

            try
            {
                var rawResponse = _httpClient.GetAsync(CommonHealthQuestionsApiBaseUrl)
                    .ContinueWith((rawResponse) =>
                    {
                        var asyncString = rawResponse.Result.Content.ReadAsStringAsync();
                        asyncString.Wait();
                        commonHealthQuestionsApiResponse = JsonConvert.DeserializeObject<CommonHealthQuestionsApiResonse>(asyncString.Result);
                    });
                rawResponse.Wait();
                return commonHealthQuestionsApiResponse;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
