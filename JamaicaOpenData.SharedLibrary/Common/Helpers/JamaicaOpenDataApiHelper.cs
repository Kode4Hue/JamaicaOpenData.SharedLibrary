using JamaicaOpenData.SharedLibrary.Common.DTOs;

namespace JamaicaOpenData.SharedLibrary.Common.Helpers
{
    public static class JamaicaOpenDataApiHelper<T>
    {
        public static string GetApiExceptionMessageFromResponse(
            JoaResponseContentDto<T>? responseContent, int? limit, int? pageNumber)
        {
            string apiExceptionMessage = string.Empty;

            if (responseContent != null)
            {
                apiExceptionMessage = $"Error: Failed to get petrol prices from Jamaica Open Data API. |" +
                    $"HelpText - {responseContent.HelpText} ";

                if (limit.HasValue)
                    apiExceptionMessage = $"{apiExceptionMessage} Query Parameters - limit: {limit.Value} |";

                if (pageNumber.HasValue)
                    apiExceptionMessage = $"{apiExceptionMessage}, pageNumber{pageNumber.Value} |";
            }

            return apiExceptionMessage;
        }
  
    }
}
