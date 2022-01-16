using Newtonsoft.FluentAPI.Abstracts;
using Newtonsoft.FluentAPI.Builders;
using JamaicaOpenData.SharedLibrary.Common.DTOs;

namespace JamaicaOpenData.SharedLibrary.Common.Mappings
{
    public class JoaResponseContentMapper<T>: IJsonTypeConfiguration<JoaResponseContentDto<T>> where T : class
    {
        public void Configure(JsonTypeBuilder<JoaResponseContentDto<T>> jsonTypeBuilder)
        {
            jsonTypeBuilder.Property(x => x.HelpText)
                .HasFieldName("help");

            jsonTypeBuilder.Property(x => x.IsSuccess)
                .HasFieldName("success");

            jsonTypeBuilder.Property(x => x.Result)
                .HasFieldName("result");
        }
    }
}



