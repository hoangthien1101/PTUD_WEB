namespace MyWebApi.ViewModel
{
    public class ResetPasswordRequest
    {
        public string ResetToken { get; set; }
        public string Password { get; set; }
    }
} 