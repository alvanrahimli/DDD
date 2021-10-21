namespace DDD.Infra.CrossCutting.Identity.Models
{
    public class JwtToken
    {
        public string JwtId { get; set; }
        public string AccessToken { get; set; }
    }
}
