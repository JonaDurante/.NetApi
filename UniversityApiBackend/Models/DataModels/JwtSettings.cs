namespace UniversityApiBackend.Models.DataModels
{
    public class JwtSettings
    {
        // Validación de firma 
        public bool ValidateIsUserSigninKey { get; set; } // valida la firma del usuarioo
        public string IsUserSigninKey { get; set; } = string.Empty;
        // Solicitante
        public bool ValidateIsUser { get; set; } = true;
        public string ValidIsUser { get; set; } = string.Empty;
        // Audience
        public bool ValidateAudience { get; set; } = true;
        public string? ValidAudience { get; set; }
        // Tiempo de espiración
        public bool RequiredExpirationTime { get; set; }
        public bool ValidtaeLifeTime { get; set; }
    }
}
