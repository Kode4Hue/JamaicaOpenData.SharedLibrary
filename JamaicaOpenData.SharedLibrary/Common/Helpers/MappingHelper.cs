using JamaicaOpenData.SharedLibrary.Common.Mappings;
using JamaicaOpenData.SharedLibrary.PetrolPrices.DTOs;
using JamaicaOpenData.SharedLibrary.PetrolPrices.MappingProfiles;
using Newtonsoft.FluentAPI.Resolvers;
using Newtonsoft.Json;

namespace JamaicaOpenData.SharedLibrary.Common.Helpers
{
    public static class MappingHelper
    {

        public static void ConfigureHttpJsonSerializerSettings()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = BuildObjectsAndJsonContractMappings(),
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        private static FluentContractResolver BuildObjectsAndJsonContractMappings()
        {
            var jsonContractResolver = new FluentContractResolver();
            jsonContractResolver
                .AddConfiguration(new PetrolPriceDtoMapper());
            jsonContractResolver.AddConfiguration
                (new JoaResponseContentMapper<PetrolPriceDto>());
            return jsonContractResolver;
        }
    }
}
