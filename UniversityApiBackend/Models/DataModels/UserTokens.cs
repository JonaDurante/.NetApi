namespace UniversityApiBackend.Models.DataModels
{
    public class UserToken
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public string? UserName { get; set;}    
        public TimeSpan Validity { get; set; } // Tiempó de validez que tiene este token
        public string? RefreshToken { get; set; } 
        public string EmailId { get; set;}
        public Guid GuidId { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
