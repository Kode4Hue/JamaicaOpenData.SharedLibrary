using JamaicaOpenData.SharedLibrary.Common.DTOs;
using JamaicaOpenData.SharedLibrary.PetrolPrices.DTOs;
using System.Threading.Tasks;

namespace JamaicaOpenData.SharedLibrary.Common.Services
{
    public interface IJamaicaOpenDataService
    {

       Task<JoaResultDto<PetrolPriceDto>> GetPetrolPrices(int? limit, int? pageNumber);
    }
}
