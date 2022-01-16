using System.Collections.Generic;

namespace JamaicaOpenData.SharedLibrary.Common.DTOs
{
    public class JoaResultDto<T>
    {
        public List<string> ResourceId { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public List<T> Records { get; set; }
    }
}
