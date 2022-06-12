namespace Jwt.Authentication.Manager.Domain.Entities
{
    public class EncryptResponse
    {
        public string UserName { get; set; }
        public string EncryptedPassword { get; set; }
    }
}