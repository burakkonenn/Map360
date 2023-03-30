namespace Application.Wrappers
{
    public partial class ServiceResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }


    public partial class ServiceResponse<T>:ServiceResponse
    {
        public T Data { get; set; }
    }
}
