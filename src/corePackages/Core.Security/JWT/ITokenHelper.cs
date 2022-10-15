using Core.Security.Entities;

namespace Core.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);

    RefreshTokenDto CreateRefreshToken(User user, string ipAddress);
}