namespace API.Errors
{
    //For api/buggy/servererror
    //create a middleware so we can handle execption
    // and use the ApiException class
    // in the event that we get an execption
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string message = null, string details = null)
         : base(statusCode, message)
        {
            Details = details;

        }

        public string Details { get; set; }


    }
}