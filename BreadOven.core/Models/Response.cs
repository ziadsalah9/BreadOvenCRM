namespace BreadOven.core.Models
{
    public class Response<T>
    {


       public T Value { get; set; }
        public string? Message { get; set; }
    }
}
