# Assignment2022-NCC

Within the Settings.cs file (located Api/Types/Settings.cs) you will need to provide your own API key to be able to use this web application succesfully - otherwise you will get 404s or Unauthorized responses.

If the Settings.cs file is missing, please copy and paste the following into a new Settings.cs file in the Api/Types directory:

namespace Assignment2022_NCC.Api
{
    public struct Settings
    {
        public static string ApiKey = "";
    }
}
