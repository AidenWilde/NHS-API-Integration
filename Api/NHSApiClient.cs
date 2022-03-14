using Assignment2022_NCC.Api.Types;

namespace Assignment2022_NCC.Api
{
    public class NHSApiClient
    {
        private const string CommonHealthQuestionsApiBaseUrl = "https://api.nhs.uk/common-health-questions";

        private HttpClient _httpClient;

        public NHSApiClient()
        {
            _httpClient = new HttpClient();
        }

        public CommonHealthQuestionsApiResonse GetCommonHealthQuestions()
        {
            return new();
        }
    }
}
