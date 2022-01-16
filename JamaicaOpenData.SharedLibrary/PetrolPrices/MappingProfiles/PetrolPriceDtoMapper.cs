using JamaicaOpenData.SharedLibrary.PetrolPrices.DTOs;
using Newtonsoft.FluentAPI.Abstracts;
using Newtonsoft.FluentAPI.Builders;

namespace JamaicaOpenData.SharedLibrary.PetrolPrices.MappingProfiles
{
    public class PetrolPriceDtoMapper : IJsonTypeConfiguration<PetrolPriceDto>
    {
        public void Configure(JsonTypeBuilder<PetrolPriceDto> jsonTypeBuilder)
        {
            jsonTypeBuilder.Property(x => x.Name)
                .HasFieldName("Item");
            jsonTypeBuilder.Property(x => x.Id)
                .HasFieldName("ItemID");
            jsonTypeBuilder.Property(x => x.OutletId)
                .HasFieldName("OutletID");
            jsonTypeBuilder.Property(x => x.OutletName)
                .HasFieldName("Outlet_Name");
        }
    }
}
