namespace ChallengeBackend.API.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }

        public string? Message { get; set; }

        public CodeErrorResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Invalid user",
                404 => "User not found",
                405 => "Invalid input",
                500 => "Server Error",
                _ => string.Empty
            };
        }
    }
}
