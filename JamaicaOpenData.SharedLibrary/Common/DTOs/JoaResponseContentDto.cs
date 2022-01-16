namespace JamaicaOpenData.SharedLibrary.Common.DTOs
{
    public class JoaResponseContentDto<T>
    {
        public string HelpText { get; set; }
        public bool IsSuccess { get; set; }
        public JoaResultDto<T> Result { get; set; }
    }
}
