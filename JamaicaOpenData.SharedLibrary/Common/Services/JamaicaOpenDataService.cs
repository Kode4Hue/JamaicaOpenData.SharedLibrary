using CleanArchitecture.SharedLibrary.Http.Exceptions;
using CleanArchitecture.SharedLibrary.Http.Helpers;
using CleanArchitecture.SharedLibrary.Http.Services;
using JamaicaOpenData.SharedLibrary.Common.Constants;
using JamaicaOpenData.SharedLibrary.Common.DTOs;
using JamaicaOpenData.SharedLibrary.Common.Helpers;
using JamaicaOpenData.SharedLibrary.PetrolPrices.DTOs;
using System.Net.Http;
using System.Threading.Tasks;

namespace JamaicaOpenData.SharedLibrary.Common.Services
{
    public class JamaicaOpenDataService : BaseHttpService, IJamaicaOpenDataService
    {
        private readonly int defaultLimit = 10;
        
        public JamaicaOpenDataService(IHttpClientFactory httpClientFactory) : base(
             httpClientFactory, AppKeys.JamaicaOpenDataHttpClientName)
        {
        }

        public async Task<JoaResultDto<PetrolPriceDto>> GetPetrolPrices(int? limit, int? pageNumber)
        {
            if(!limit.HasValue)
                limit = defaultLimit;

            var resourceId = "6aadb194-5452-4e7d-aa93-93db74361955";
            var requestPath = $"search.json?resource_id={resourceId}&limit={limit.Value}";

            if (pageNumber.HasValue)
            {
                int offset =  limit.Value * pageNumber.Value;
                requestPath = $"{requestPath}&offset={offset}";
            }

            var requestMessage = GenerateHttpRequest(HttpMethod.Get, requestPath);
            var response = await MakeRequest(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApiException(
                    "Error: Unsuccessful API request to the Petrol Price endpoint.",
                    int.Parse(response.StatusCode.ToString()), 
                    response.Content);
            }

            var responseContent = await HttpClientContentHelper<JoaResponseContentDto<PetrolPriceDto>>
                .DeserializeObjectFromHttpContent(response.Content);

            if (!responseContent.IsSuccess)
            {
                var apiExceptionMessage = JamaicaOpenDataApiHelper<PetrolPriceDto>
                    .GetApiExceptionMessageFromResponse(responseContent, limit, pageNumber);

                throw new ApiException(apiExceptionMessage);
            }

            return responseContent.Result;
        }

    }
}

