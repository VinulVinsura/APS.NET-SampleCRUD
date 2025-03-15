namespace SampleCRUD.Model
{
    public class Responce
    {

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
        public Responce(int statusCode, string message, object data )
        {
            StatusCode = statusCode;
            Message = message;
            Content = data;
        }

    
    }
}
