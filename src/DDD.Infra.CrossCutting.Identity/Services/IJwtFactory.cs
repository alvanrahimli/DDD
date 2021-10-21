using System.Security.Claims;
using System.Threading.Tasks;
using DDD.Infra.CrossCutting.Identity.Models;

namespace DDD.Infra.CrossCutting.Identity.Services
{
    public interface IJwtFactory
    {
        Task<JwtToken> GenerateJwtToken(ClaimsIdentity claimsIdentity);
    }
}
