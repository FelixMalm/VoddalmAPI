namespace VoddalmBlazor.Services.Base
{
    //Author Felix Malm
    public class Response<T>
    {
        public string Message { get; set; }
        public string ValidationErros { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}